using MnemonicPdf.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MnemonicPdf
{
    /// <summary>
    /// Interaction logic for PDFPage.xaml
    /// </summary>
    public partial class PDFPage : Page
    {

        public PDFPage()
        {
            InitializeComponent();
        }

        public PDFPage(CoinModel coin)
        {
            InitializeComponent();
            DataContext = coin;
            Title = ToString();

            if (coin.GenerateQRForAddress && !string.IsNullOrWhiteSpace(coin.Address))
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                var qrCode = new QRCode(qrGenerator.CreateQrCode(coin.Address,QRCodeGenerator.ECCLevel.Q));
                qrAddress.Source = ConvertToBitmapImage(qrCode.GetGraphic(20));
            }
            if (coin.GenerateQRForPhrase && coin.Words != null && coin.Words.Count > 0)
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                var qrCode = new QRCode(qrGenerator.CreateQrCode(string.Join(" ", coin.Words), QRCodeGenerator.ECCLevel.Q));
                qrPhrase.Source = ConvertToBitmapImage(qrCode.GetGraphic(10));
            }
        }

        private static BitmapImage ConvertToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        public override string ToString()
        {
            return DataContext?.ToString();
        }
    }
}
