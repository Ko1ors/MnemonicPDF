using Mnemonic_phrase_to_PDF.Models;
using System;
using System.Collections.Generic;
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

namespace Mnemonic_phrase_to_PDF
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
        }
    }
}
