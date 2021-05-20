using System.Windows;
using System.Windows.Controls;

namespace Mnemonic_phrase_to_PDF
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
