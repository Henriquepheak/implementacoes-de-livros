﻿using Modulo1.Dal;
using Modulo1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.Clientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientesSearchPage : ContentPage
    {
        private ClienteDAL dalClientes = new ClienteDAL();
        private Label displayValue;
        private Label keyValue;
        private IEnumerable<Cliente> clientes;

        public ClientesSearchPage(Label keyValue, Label displayValue)
        {
            InitializeComponent();
            clientes = dalClientes.GetAll();
            this.keyValue = keyValue;
            this.displayValue = displayValue;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            lvClientes.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                lvClientes.ItemsSource = clientes;
            else
                lvClientes.ItemsSource = clientes.Where(i => i.Nome.Contains(e.NewTextValue));

            lvClientes.EndRefresh();
        }

        public async void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var cliente = (o as ListView).SelectedItem as Cliente;
            this.keyValue.Text = cliente.ClienteId.ToString();
            this.displayValue.Text = cliente.Nome;
            await Navigation.PopAsync();
        }
    }
}