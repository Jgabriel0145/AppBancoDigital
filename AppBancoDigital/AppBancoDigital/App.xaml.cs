using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBancoDigital.View;

namespace AppBancoDigital
{
    public partial class App : Application
    {
        public static Model.Correntista DadosCorrentista { get; set; }
        public static Model.Conta ContaCorrente { get; set; }
        public static Model.Conta ContaPoupanca { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.Acesso.Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
