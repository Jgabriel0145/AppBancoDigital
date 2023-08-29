using System;
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

        private void BtnCadastrar_Clicked(object sender, EventArgs e)
        {
            if (RadCpf.IsChecked == true)
            {
                pix.tipo = "CPF";
            }
        }

        private void PersonalizarChave_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (txt_chave_pix_cadastro.IsVisible ==  false) txt_chave_pix_cadastro.IsVisible = true;
            else txt_chave_pix_cadastro.IsVisible = false;
        }
    }
}