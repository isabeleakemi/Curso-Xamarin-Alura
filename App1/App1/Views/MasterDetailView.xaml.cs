using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1.Views
{
    public partial class MasterDetailView : MasterDetailPage
    {
        private readonly Usuario usuario;

        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.Master = new MasterView(usuario);
            
        }
    }
}
