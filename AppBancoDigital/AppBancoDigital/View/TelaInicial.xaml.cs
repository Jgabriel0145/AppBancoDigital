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

            lbl_correntista.Text = App.DadosCorrentista.nome;
            logo_navbar.IconImageSource = ImageSource.FromResource("AppBancoDigital.Img.logo.png");
            btn_icone_pix.Source = ImageSource.FromResource("AppBancoDigital.Img.pix_icone.png");
        }
    }
}