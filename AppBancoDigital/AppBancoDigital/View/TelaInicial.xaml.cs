using System;
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
                //Alterando para mostrar na interface.
                if (contas.tipo == "C") contas.tipo = "Corrente";
                else contas.tipo = "Poupança";


                lista_contas.Add(contas);

                //Desfazendo alterações.
                if (contas.tipo == "Corrente") contas.tipo = "C";
                else contas.tipo = "P";

                //lbl_corrente_teste.Text = contas.ToString();
            }
            
            BtnPix.Source = ImageSource.FromResource("AppBancoDigital.Img.pix_icone.png");
            BtnEnviarPix.Source = ImageSource.FromResource("AppBancoDigital.Img.enviar_pix.png");
            BtnReceberPix.Source = ImageSource.FromResource("AppBancoDigital.Img.pix_icone.png");
        }

        

        private void BtnPix_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pix.CadastrarChavePix());
        }

        private void OnAppering()
        {

        }

        private void BtnLogout_Clicked(object sender, EventArgs e)
        {
            App.DadosCorrentista = null;
            App.ListaContas = null;
            App.DadosPixCorrente = null;
            App.DadosPixPoupanca = null;

            App.Current.MainPage = new NavigationPage(new View.Acesso.Login());
        }

        private void BtnEnviarPix_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnReceberPix_Clicked(object sender, EventArgs e)
        {

        }
    }
}