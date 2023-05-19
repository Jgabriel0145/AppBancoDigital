using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View.Correntista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();

            dtpck_data_nasc_cadastro.MaximumDate = DateTime.Now;
        }

        private async void BtnCadastrar_Clicked(object sender, EventArgs e)
        {
            if ((DateTime.Now.Year - dtpck_data_nasc_cadastro.Date.Year) >= 18)
            {
                if (txt_senha_cadastro.Text == txt_confirmar_senha_cadastro.Text)
                {
                    try
                    {
                        
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Erro", ex.Message, "OK");
                    }
                }
                else await DisplayAlert("Aviso", "A senha confirmada está diferente.", "OK");

            }
            else await DisplayAlert("Aviso", "A idade mínima para criar uma conta é 18 anos.", "OK");
        }
    }
}