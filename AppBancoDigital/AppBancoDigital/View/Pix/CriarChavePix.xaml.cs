﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppBancoDigital.Model;
using AppBancoDigital.Service;

namespace AppBancoDigital.View.Pix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriarChavePix : ContentPage
    {
        ChavePix pix = new ChavePix();
        public CriarChavePix()
        {
            InitializeComponent();
        }

        private async void BtnCadastrar_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsRunning = true;
            act_carregando.IsVisible = true;
            try
            {
                if (RadCpf.IsChecked == true) pix.tipo = "cpf";
                else
                {
                    if (RadEmail.IsChecked == true) pix.tipo = "email";
                    else
                    {
                        if (RadTelefone.IsChecked == true) pix.tipo = "telefone";
                        else
                            pix.tipo = "personalizada";
                    }
                }

                await DisplayAlert("", pix.tipo, "OK");
            }
            catch (Exception ex) 
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
            finally
            {
                act_carregando.IsVisible = false;
                act_carregando.IsRunning = false;
            }
                
        }

        private void PersonalizarChave_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (txt_chave_pix_cadastro.IsVisible ==  false) txt_chave_pix_cadastro.IsVisible = true;
            else txt_chave_pix_cadastro.IsVisible = false;
        }
    }
}