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
            for (int i = 1; i <= coinModel.WordCount; i++)
                listView.Items.Add(new WordUC(i));
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
            if (coinModel.WordCount > listView.Items.Count)
            {
                for (int i = listView.Items.Count + 1; i <= coinModel.WordCount; i++)
                    listView.Items.Add(new WordUC(i));
            }
            else if (coinModel.WordCount < listView.Items.Count)
            {
                for (int i = listView.Items.Count; i > coinModel.WordCount; i--)
                    listView.Items.RemoveAt(i - 1);
            }
        }
    }
}
