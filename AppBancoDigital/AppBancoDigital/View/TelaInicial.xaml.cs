using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppBancoDigital.View;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaInicial : ContentPage
    {
        public TelaInicial()
        {
            InitializeComponent();

            logo_navbar.IconImageSource = ImageSource.FromResource("AppBancoDigital.Img.logo_edit.png");

            lbl_correntista.Text = App.DadosCorrentista.nome;

            /*lbl_corrente_teste.Text = App.ContaCorrente.ToString();
            lbl_poupanca_teste.Text = App.ContaPoupanca.ToString();*/
            
            BtnPix.Source = ImageSource.FromResource("AppBancoDigital.Img.pix_icone.png");
        }

        private void BtnPix_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pix.CadastrarChavePix());
        }
    }
}