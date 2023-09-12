﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppBancoDigital.View;
using AppBancoDigital.Model;
using System.Collections.ObjectModel;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaInicial : ContentPage
    {
        ObservableCollection<Conta> lista_contas = new ObservableCollection<Conta>();

        public TelaInicial()
        {
            InitializeComponent();

            logo_navbar.IconImageSource = ImageSource.FromResource("AppBancoDigital.Img.logo_edit.png");

            lbl_correntista.Text = App.DadosCorrentista.nome;

            lst_contas.ItemsSource = lista_contas;

            foreach (Conta contas in App.ListaContas)
            {
                Console.WriteLine("_____________________________");
                Console.WriteLine(contas.data_cadastro);
                Console.WriteLine("_____________________________");

                lista_contas.Add(contas);

                //lbl_corrente_teste.Text = contas.ToString();
            }
            
            //BtnPix.Source = ImageSource.FromResource("AppBancoDigital.Img.pix_icone.png");
        }

        

        private void BtnPix_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pix.CadastrarChavePix());
        }

        private void OnAppering()
        {

        }
    }
}