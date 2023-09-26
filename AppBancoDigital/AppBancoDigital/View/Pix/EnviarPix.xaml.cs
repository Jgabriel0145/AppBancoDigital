using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using QRCoder;

namespace AppBancoDigital.View.Pix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnviarPix : ContentPage
    {
        public EnviarPix()
        {
            InitializeComponent();
        }

        private void BtnGerarQRCode_Clicked(object sender, EventArgs e)
        {
            string teste = "Chave de transferência: jao@gmail.com";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrData = qrGenerator.CreateQrCode(teste, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrData);
            byte[] qrCodeBytes = qrCode.GetGraphic(20);
            img_qrcode.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        }
    }
}