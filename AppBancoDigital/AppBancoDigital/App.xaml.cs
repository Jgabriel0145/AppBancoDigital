using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBancoDigital.View;
using AppBancoDigital.Model;

namespace AppBancoDigital
{
    public partial class App : Application
    {
        public static Model.Correntista DadosCorrentista { get; set; }
        public static List<Model.Conta> ListaContas { get; set; }
        public static ChavePix DadosPixCorrente { get; set; }
        public static ChavePix DadosPixPoupanca { get; set; }

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
