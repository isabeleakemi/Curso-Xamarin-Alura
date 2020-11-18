using App1.Models;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Views
{
    

    public partial class ListagemView : ContentPage
    {
        public ListagemViewModel ViewModel { get; set; }

        public ListagemView()
        {
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = this.ViewModel;

            //this.BindingContext = this;
            //listViewVeiculos.ItemsSource = this.Veiculos;
        }

        //private void listViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var veiculo = (Veiculo)e.Item;

            //DisplayAlert("Test Drive", string.Format("Você tocou no modelo '{0}', que custa {1}", veiculo.Nome, veiculo.PrecoFormatado), "ok");

        //    Navigation.PushAsync(new DetalheView(veiculo));
        //}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", (msg) => 
            {
                Navigation.PushAsync(new DetalheView(msg));
            });

            await this.ViewModel.GetVeiculos();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
