using System.Windows;
using System.Windows.Controls;

namespace MnemonicPdf
{
    /// <summary>
    /// Interaction logic for PDFPreviewWindow.xaml
    /// </summary>
    public partial class PDFPreviewWindow : Window
    {
        public PDFPreviewWindow()
        {
            InitializeComponent();
        }

        public void SetPage(Page pdfPage)
        {
            frame.Content = pdfPage;
        }
    }
}
