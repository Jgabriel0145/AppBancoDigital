using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppBancoDigital.Model;
using AppBancoDigital.Service;

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
                        Model.Correntista correntista = await DataServiceCorrentista.CadastrarCorrentista(new Model.Correntista
                        {
                            Nome = txt_nome_cadastro.Text,
                            Email = txt_email_cadastro.Text,
                            Data_Cadastro = dtpck_data_nasc_cadastro.Date,
                            Cpf = txt_cpf_cadastro.Text,
                            Senha = txt_senha_cadastro.Text
                        });

                        if (correntista.Id != null)
                        {
                            await Navigation.PushAsync(new View.Acesso.Login());
                        }
                        else
                            throw new Exception("Ocorreu um erro ao salvar seu cadastro.");
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