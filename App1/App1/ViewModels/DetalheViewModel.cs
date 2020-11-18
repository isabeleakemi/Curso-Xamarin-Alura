using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class DetalheViewModel : BaseViewModel
    {
        public Veiculo Veiculo { get; set; }

        public string TextoFreioABS
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", Veiculo.FREIO_ABS);
            }
        }

        public string TextoArCondicionado
        {
            get
            {
                return string.Format("Ar Condicionado - R$ {0}", Veiculo.AR_CONDICIONADO);
            }
        }

        public string TextoMP3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", Veiculo.MP3_PLAYER);
            }
        }

        //bool temFreioABS;
        public bool TemFreioABS
        {
            get
            {
                return Veiculo.TemFreioABS;
            }
            set
            {
                Veiculo.TemFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

                //if (temFreioABS)
                //    DisplayAlert("Freio ABS", "Ligado!", "Ok");
                //else
                //    DisplayAlert("Freio ABS", "Desligado!", "Ok");
            }
        }

        //bool temArCondicionado;
        public bool TemArCondicionado
        {
            get
            {
                return Veiculo.TemArCondicionado;
            }
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

                //if (temFreioABS)
                //    DisplayAlert("Freio ABS", "Ligado!", "Ok");
                //else
                //    DisplayAlert("Freio ABS", "Desligado!", "Ok");
            }
        }

        //bool temMP3Player;
        public bool TemMP3Player
        {
            get
            {
                return Veiculo.TemMP3Player;
            }
            set
            {
                Veiculo.TemMP3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

                //if (temFreioABS)
                //    DisplayAlert("Freio ABS", "Ligado!", "Ok");
                //else
                //    DisplayAlert("Freio ABS", "Desligado!", "Ok");
            }
        }

        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;

            }
        }

        public DetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send(veiculo, "Proximo");
            });
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged([CallerMemberName]string name = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}

        public ICommand ProximoCommand { get; set; }
    }
}
