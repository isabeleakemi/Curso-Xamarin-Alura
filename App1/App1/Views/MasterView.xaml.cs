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
    public partial class MasterView : TabbedPage
    {
        //public MasterViewModel ViewModel { get; set; }

        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            //this.ViewModel = new MasterViewModel(usuario);
            this.BindingContext = new MasterViewModel(usuario);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil", (usuario) => 
            {
                this.CurrentPage = this.Children[1];
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
        }
    }
}
