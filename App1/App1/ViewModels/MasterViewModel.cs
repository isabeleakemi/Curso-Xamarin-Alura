using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class MasterViewModel
    {

        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }


        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }

        private readonly Usuario usuario;

        public ICommand EditarPerfilCommand { get; private set; }

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;

            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });
        }
    }
}
