﻿using Capitulo05.ViewModels.Pecas;
using CasaDoCodigo.Models;
using Interfaces.Fotos;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo05.Views.Pecas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDView : ContentPage
    {
        private CRUDViewModel crudViewModel;

        public CRUDView()
        {
            InitializeComponent();
        }

        public CRUDView(Peca peca, string title) : this()
        {
            this.crudViewModel = new CRUDViewModel(peca);
            this.BindingContext = this.crudViewModel;
            this.Title = title;
            App.navigationPage.Popped += OnPoppedCRUDFoto;
            crudViewModel.CarregandoImagem = true;
        }

        private async Task SelecionarFotoDoAlbumAsync(Peca peca)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Álbum não suportado", "Não existe permissão para acessar o álbum de fotos", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Small
            });

            if (file == null)
                return;

            var imagePath = SaveFotoFromAlbum(peca.CaminhoImagem, file);

            crudViewModel.CaminhoImagem = imagePath;
            crudViewModel.Peca.ImagemEmBytes = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(() =>
            {
                crudViewModel.AtualizarImagemPeca();
            });

            MessagingCenter.Subscribe<string>(this, "InformacaoCRUD", async (msg) => { await DisplayAlert("Informação", msg, "ok"); });
            MessagingCenter.Subscribe<Peca>(this, "Album", async (peca) => { await SelecionarFotoDoAlbumAsync(peca); });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
            MessagingCenter.Unsubscribe<Peca>(this, "Album");
        }

        public string SaveFotoFromAlbum(string caminhoImagem, Plugin.Media.Abstractions.MediaFile file)
        {
            string nomeArquivo;
            if (string.IsNullOrEmpty(caminhoImagem) || caminhoImagem.StartsWith("http"))
            {
                nomeArquivo = String.Format("{0:ddMMyyy_HHmm}", DateTime.Now) + ".jpg";
            }
            else
            {
                File.Delete(DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(caminhoImagem));
                nomeArquivo = (caminhoImagem.LastIndexOf("/") > 0) ? caminhoImagem.Substring(caminhoImagem.LastIndexOf("/") + 1) : String.Format("{0:ddMMyyy_HHmm}", DateTime.Now) + ".jpg";
            }

            var caminhoFotos = DependencyService.Get<IFotoLoadMediaPlugin>().GetDevicePathToPhoto();
            if (!Directory.Exists(caminhoFotos))
                Directory.CreateDirectory(caminhoFotos);

            string caminhoCompleto = Path.Combine(caminhoFotos, nomeArquivo);

            using (FileStream fileStream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                file.GetStream().CopyTo(fileStream);
            }
            return DependencyService.Get<IFotoLoadMediaPlugin>().SetPathToPhoto(caminhoCompleto);
        }
        public void OnPoppedCRUDFoto(object sender, NavigationEventArgs e)
        {
            if (e.Page.GetType() == typeof(CRUDView))
            {
                if (crudViewModel.Peca.CaminhoImagem != null && crudViewModel.Peca.PecaID == Guid.Empty)
                    File.Delete(DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(crudViewModel.Peca.CaminhoImagem));

            }
            App.navigationPage.Popped -= OnPoppedCRUDFoto;
        }
    }
}