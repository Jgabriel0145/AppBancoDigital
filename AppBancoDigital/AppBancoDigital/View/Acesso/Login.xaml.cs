﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View.Acesso
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            img_logo.Source = ImageSource.FromResource("AppBancoDigital.Img.logo.png");
        }

        private void BtnLinkCadastrarCorrentista_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Correntista.Cadastro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}