using Mnemonic_phrase_to_PDF.Models;
using System.Windows;

namespace Mnemonic_phrase_to_PDF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CoinModel coinModel;
        private PDFPage PDFPage;

        public MainWindow()
        {
            InitializeComponent();
            coinModel = Resources["coinModel"] as CoinModel;
            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateWordCount();
        }

        private void GeneratePDFClick(object sender, RoutedEventArgs e)
        {
            PDFPage = new PDFPage(coinModel);
        }

        private void PreviewClick(object sender, RoutedEventArgs e)
        {
            if (PDFPage != null)
            {
                new PDFPreviewWindow(PDFPage).Show();
            }
        }

        private void UpdateWordCount()
        {
            if (coinModel.WordCount > coinModel.Words.Count)
            {
                for (int i = coinModel.Words.Count + 1; i <= coinModel.WordCount; i++)
                    coinModel.Words.Add(new WordModel() { Number = i, Word = "test"});
            }
            else if (coinModel.WordCount < coinModel.Words.Count)
            {
                for (int i = coinModel.Words.Count; i > coinModel.WordCount; i--)
                    coinModel.Words.RemoveAt(i - 1);
            }
            listView.Items.Refresh();
        }
    }
}
