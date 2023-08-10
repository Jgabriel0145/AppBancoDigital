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
                if (txt_senha_cadastro.Text.Length >= 8)
                {
                    if (txt_senha_cadastro.Text == txt_confirmar_senha_cadastro.Text)
                    {
                        try
                        {
                            act_carregando.IsVisible = true;
                            act_carregando.IsRunning = true;

                            Model.Correntista correntista = await DataServiceCorrentista.CadastrarCorrentista(new Model.Correntista
                            {
                                nome = txt_nome_cadastro.Text,
                                email = txt_email_cadastro.Text,
                                cpf = txt_cpf_cadastro.Text,
                                data_nasc = dtpck_data_nasc_cadastro.Date,
                                senha = txt_senha_cadastro.Text,
                                data_cadastro = DateTime.Now
                            });

                            if (correntista.id != null)
                            {
                                App.DadosCorrentista = correntista;

                                Navigation.PopAsync();
                            }
                            else
                                throw new Exception("Ocorreu um erro ao salvar seu cadastro.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.StackTrace);
                            await DisplayAlert("Erro", ex.Message, "OK");
                        }
                        finally
                        {
                            act_carregando.IsRunning = false;
                            act_carregando.IsVisible = false;
                        }
                    }
                    else await DisplayAlert("Aviso", "A senha confirmada está diferente.", "OK");
                }
                else await DisplayAlert("Aviso", "A senha deve conter no mínimo 8 caracteres.", "OK");
            }
            else await DisplayAlert("Aviso", "A idade mínima para criar uma conta é 18 anos.", "OK");
        }

        private void txt_senha_cadastro_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_senha_cadastro.Text.Length <= 7) lbl_aviso_senha.IsVisible = true;
            else lbl_aviso_senha.IsVisible = false;
        }
    }
}