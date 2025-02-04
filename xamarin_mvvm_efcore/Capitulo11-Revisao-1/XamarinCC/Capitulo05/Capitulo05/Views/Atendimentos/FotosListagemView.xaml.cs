﻿using Capitulo05.Controls;
using Capitulo05.ViewModels.Atendimentos;
using CasaDoCodigo.Devices.Interfaces;
using CasaDoCodigo.Models;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Capitulo05.Views.Atendimentos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FotosListagemView : ContentPage
    {
        private FotosListagemViewModel viewModel;
        private double width;
        private double height;
        private bool forcarLandscape;
        public FotosListagemView(Atendimento atendimento)
        {
            InitializeComponent();
            BindingContext = viewModel = new FotosListagemViewModel(atendimento);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            App.navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(false);
            App.navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(false);

            forcarLandscape = true;

            DependencyService.Get<IOrientation>().Landscape();

            await viewModel.AtualizarFotosAsync();

            CriaFramesFotos();

            MessagingCenter.Subscribe<AtendimentoFoto>(this, "Mostrar", async (foto) => { await Navigation.PushAsync(new FotosCRUDView(foto, "Foto Atendimento")); });
            MessagingCenter.Subscribe<FotoListContainerControl>(this, "Remover", async (container) => { await RemoverContainerAsync(container); });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            App.navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);
            App.navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            MessagingCenter.Unsubscribe<AtendimentoFoto>(this, "Mostrar");
            MessagingCenter.Unsubscribe<FotoListContainerControl>(this, "Remover");

            DependencyService.Get<IOrientation>().Portrait();
            forcarLandscape = false;
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (this.height > this.Width && forcarLandscape)
                    DependencyService.Get<IOrientation>().Landscape();
            }
        }
        private void CriaFramesFotos()
        {
            var fotos = viewModel.FotosAtendimento.Where(f => !f.JaExibidaNaListagem).ToList();
            foreach (var f in fotos)
            {
                Frame frameFoto = new Frame();
                frameFoto.Margin = 10;
                frameFoto.BorderColor = Color.Black;
                frameFoto.CornerRadius = 15;
                frameFoto.WidthRequest = (width > height ? width * 0.85 : height * 0.85);
                frameFoto.HeightRequest = (height > width ? height * 0.50 : width * 0.50);

                var fotoContainer = new FotoListContainerControl(f);

                Label observacoes = new Label();
                observacoes.Text = f.Observacoes;
                observacoes.WidthRequest = frameFoto.WidthRequest * 0.30;
                FlexLayout.SetAlignSelf(observacoes, FlexAlignSelf.Center);

                FlexLayout flexLayout = new FlexLayout();
                flexLayout.Direction = FlexDirection.Row;
                flexLayout.JustifyContent = FlexJustify.SpaceAround;

                flexLayout.Children.Add(fotoContainer);
                flexLayout.Children.Add(observacoes);

                frameFoto.Content = flexLayout;

                f.JaExibidaNaListagem = true;

                flexLayoutFotos.Children.Add(frameFoto);
            }
        }
        private async Task RemoverContainerAsync(FotoListContainerControl container)
        {
            if (await DisplayAlert("Confirmação", $"Confirma remoção da foto?", "Yes", "No"))
            {
                await viewModel.EliminarFotoAsync(container.Foto);
                (container.Parent.Parent as Frame).IsVisible = false;
                await DisplayAlert("Informação", "Foto do Atendimento removida com sucesso", "Ok");
            }
            else
            {
                await ReposicionamentoDaImagemNoContainerAsync(container);
            }
            return;
        }
        private async Task ReposicionamentoDaImagemNoContainerAsync(FotoListContainerControl container)
        {

            // Definição de variáveis que auxiliarão no processo de exibição da imagem no local original
            var image = container.Content as Image;
            var currentScale = 1;
            var width = container.Width;
            var height = container.Height;
            double xOffset = 0, yOffset = 0;

            // Obtenção da posição X para centralizar a imagem
            if (image.Width * currentScale < width && width > height)
                xOffset = (width - image.Width * currentScale) / 2 - container.Content.X;
            else
                xOffset = System.Math.Max(System.Math.Min(0, xOffset), -System.Math.Abs(image.Width * currentScale - width));

            // Obtenção da posição Y para centralizar a imagem
            if (image.Height * currentScale < height && image.Height > width)
                yOffset = (height - image.Height * currentScale) / 2 - container.Content.Y;
            else
                yOffset = System.Math.Max(System.Math.Min((image.Height - (height)) / 2, yOffset), -System.Math.Abs((image.Height * currentScale - height - (image.Height - height) / 2)));
            await container.Content.TranslateTo(xOffset, yOffset, 500, Easing.BounceOut);
        }
    }
}