﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppBancoDigital.Service;

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

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            act_buscando.IsVisible = true;
            act_buscando.IsRunning = true;
            try
            {
                Model.Correntista correntista = await DataServiceCorrentista.LoginAsync(new Model.Correntista
                {
                    cpf = txt_cpf_login.Text,
                    senha = txt_senha_login.Text
                });

                if (correntista.id != null)
                {
                    //Model.Conta conta_corrente = await DataServiceConta.ProcurarContaCorrente(correntista);
                    //Model.Conta conta_poupanca = await DataServiceConta.ProcurarContaPoupanca(correntista);

                    App.DadosCorrentista = correntista;
                    //App.ContaCorrente = conta_corrente;
                    //App.ContaPoupanca = conta_poupanca;

                    App.Current.MainPage = new NavigationPage(new View.TelaInicial());
                }
                else
                    throw new Exception("Dados inválidos.");
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erro.", ex.Message, "OK");
            }
            finally
            {
                act_buscando.IsVisible = false;
                act_buscando.IsRunning = false;
            }
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

        private void BtnExibirSenha_Clicked(object sender, EventArgs e)
        {
            if (txt_senha_login.IsPassword == true) txt_senha_login.IsPassword = false;
            else txt_senha_login.IsPassword = true;
        }
    }
}