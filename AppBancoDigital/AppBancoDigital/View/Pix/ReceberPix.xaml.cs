﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View.Pix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReceberPix : ContentPage
    {
        public ReceberPix()
        {
            InitializeComponent();
        }

        private void BtnLerQRCode_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pix.LerQrCode());
        }
    }
}