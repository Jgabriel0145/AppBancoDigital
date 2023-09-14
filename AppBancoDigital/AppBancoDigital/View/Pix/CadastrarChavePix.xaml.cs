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
    public partial class CadastrarChavePix : ContentPage
    {
        ChavePix pix = new ChavePix();
        Conta conta_corrente = new Conta();
        Conta conta_poupanca = new Conta();
        Model.Correntista correntista = App.DadosCorrentista;
        
        public CadastrarChavePix()
        {
            InitializeComponent();
        }

        string DefinirTipoPix()
        {
            if (RadCpf.IsChecked == true)
                return "cpf";
            else
            {
                if (RadEmail.IsChecked == true)
                    return "email";
                else
                    return "";
            }
        }

        string DefinirChavePix(string tipo)
        {
            if (tipo == "email")
                return correntista.email;
            else
                if (tipo == "cpf")
                return correntista.cpf;
            else return "";
        }

        private async void BtnCadastrar_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsRunning = true;
            act_carregando.IsVisible = true;
            try
            {
                foreach (Conta contas in App.ListaContas)
                {
                    if (contas.tipo == "C")
                    {
                        conta_corrente = contas;
                    }
                    else
                    {
                        conta_poupanca = contas;
                    }
                }

                string tipo = DefinirTipoPix();
                string chave = DefinirChavePix(tipo);

                if (RadCorrente.IsChecked == true)
                {
                    pix.chave = chave;
                    pix.tipo = tipo;
                    pix.id_conta = conta_corrente.id;
                }
                else
                {
                    if (RadPoupanca.IsChecked == true)
                    {
                        pix.chave = chave;
                        pix.tipo = tipo;
                        pix.id_conta = conta_poupanca.id;
                    }
                }           
                

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
    }
}