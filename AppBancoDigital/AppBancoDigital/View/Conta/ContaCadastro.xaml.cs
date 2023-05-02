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

        private void btnCriarConta_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsVisible = true;
            act_carregando.IsRunning = true;

        }
    }
}