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
    public partial class DetalheView : ContentPage
    {
        
        public Veiculo Veiculo { get; set; }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            //this.Title = veiculo.Nome;
            this.Veiculo = veiculo;
            this.BindingContext = new DetalheViewModel(veiculo);
        }

        //private void buttonProximo_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo", (msg) =>
            {
                Navigation.PushAsync(new AgendamentoView(msg));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }
    }
}
