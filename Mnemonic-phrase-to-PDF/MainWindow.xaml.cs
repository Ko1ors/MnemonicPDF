using Mnemonic_phrase_to_PDF.Models;
using System.Windows;
using System.Windows.Controls;

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

        private void PasteClick(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                var words = Clipboard.GetText(TextDataFormat.Text).Split(" ");
                coinModel.WordCount = words.Length;
                UpdateWordCount();
                for (int i = 0; i < words.Length; i++)
                {
                    coinModel.Words[i].Word = words[i];
                }
            }
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

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (PDFPage != null)
            {
                PrintDialog dialog = new PrintDialog();
                if (dialog.ShowDialog() == true)
                {
                    dialog.PrintVisual(PDFPage.grid, "PDF phrase");
                }
            }
        }

        private void UpdateWordCount()
        {
            if (coinModel.WordCount > coinModel.Words.Count)
            {
                for (int i = coinModel.Words.Count + 1; i <= coinModel.WordCount; i++)
                    coinModel.Words.Add(new WordModel() { Number = i });
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
