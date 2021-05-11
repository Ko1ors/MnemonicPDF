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
using System.Windows.Shapes;

namespace Mnemonic_phrase_to_PDF
{
    /// <summary>
    /// Interaction logic for PDFPreviewWindow.xaml
    /// </summary>
    public partial class PDFPreviewWindow : Window
    {
        public PDFPreviewWindow(Page pdfPage)
        {
            InitializeComponent();
            frame.Content = pdfPage;
        }
    }
}
