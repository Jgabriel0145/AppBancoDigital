using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View.Conta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContaCadastro : ContentPage
    {
        public ContaCadastro()
        {
            InitializeComponent();
        }

        private async void btnCriarConta_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsVisible = true;
            act_carregando.IsRunning = true;

            try
            {

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
            finally
            {
                act_carregando.IsRunning = false;
                act_carregando.IsVisible = false;
            }

        }
    }
}