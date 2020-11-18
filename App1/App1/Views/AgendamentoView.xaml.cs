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
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.ViewModel;
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    DisplayAlert("Agendamento", 
        //                 string.Format(@"Veiculo: {0}
//Nome: {1}
//Fone: {2}
//E-mail: {3}
//Data Agendamento: {4}
//Hora Agendamento: {5}",
//ViewModel.Agendamento.Veiculo.Nome, ViewModel.Agendamento.Nome, ViewModel.Agendamento.Fone, ViewModel.Agendamento.Email, ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"), ViewModel.Agendamento.HoraAgendamento)
//                         , "OK");
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (msg) => 
            {
                var confirma = await DisplayAlert("Salvar Agendamento", "Deseja mesmo enviar o agendamento?", "sim", "não");

                if (confirma)
                {
                    this.ViewModel.SalvarAgendamento();
                    //DisplayAlert("Agendamento",
                    //         string.Format(@"Veiculo: {0}
//Nome: {1}
//Fone: {2}
//E-mail: {3}
//Data Agendamento: {4}
//Hora Agendamento: {5}",
//    ViewModel.Agendamento.Veiculo.Nome, ViewModel.Agendamento.Nome, ViewModel.Agendamento.Fone, ViewModel.Agendamento.Email, ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"), ViewModel.Agendamento.HoraAgendamento)
//                             , "OK");
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "ok");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Falha ao agendar o test drive! Verifique os dados e tente novamente mais tarde!", "ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");

            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");

            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}
