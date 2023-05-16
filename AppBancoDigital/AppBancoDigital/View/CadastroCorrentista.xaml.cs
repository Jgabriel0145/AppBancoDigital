using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppBancoDigital.Service;
using AppBancoDigital.Model;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroCorrentista : ContentPage
    {
        Correntista correntista = new Correntista();
        public CadastroCorrentista()
        {
            InitializeComponent();

            dtpck_data_nasc_cadastro.MaximumDate = DateTime.Now;
        }

        private async void BtnCadastrarCorrentista_Clicked(object sender, EventArgs e)
        {
            if ((DateTime.Now.Year - dtpck_data_nasc_cadastro.Date.Year) >= 18)
            {
                if (txt_senha_cadastro.Text == txt_confirmar_senha_cadastro.Text)
                {
                    try
                    {
                        correntista.Nome = txt_nome_cadastro.Text;
                        correntista.Cpf = txt_cpf_cadastro.Text;
                        correntista.Data_Nasc = dtpck_data_nasc_cadastro.Date;
                        correntista.Senha = txt_senha_cadastro.Text;

                        await DataServiceCorrentista.CadastrarCorrentista(correntista);
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