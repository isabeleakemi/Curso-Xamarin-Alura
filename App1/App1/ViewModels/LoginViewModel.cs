﻿using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class LoginViewModel
    {
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(async () =>
            {
                //MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
                var loginService = new LoginService();
                await loginService.FazerLogin(new Login(usuario, senha));
            }, () =>
            {
                return !string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha);
            });
        }
    }
}
