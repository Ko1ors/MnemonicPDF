using Microsoft.Win32;
using MnemonicPdf.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MnemonicPdf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CoinModel coinModel;
        private PDFPreviewWindow window;


        public MainWindow()
        {
            InitializeComponent();
            coinModel = Resources["coinModel"] as CoinModel;
            SetPageFormats();
            window = new PDFPreviewWindow();
            window.Closing += Window_Closing;
        }

        private void SetPageFormats()
        {
            coinModel.Formats.Add(new PageFormat() { Name = "A4", Height = 29.7m, Width = 21m, Unit = "cm" });
            coinModel.Formats.Add(new PageFormat() { Name = "10X15", Height = 15m, Width = 10m, Unit = "cm" });

            coinModel.SelectedPageFormat = coinModel.Formats.FirstOrDefault();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (sender as Window).Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void SelectIconClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select an icon";
            dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            if (dialog.ShowDialog() == true)
            {
                coinModel.Icon = new Uri(dialog.FileName);
            }
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

        private void bipClick(object sender, RoutedEventArgs e)
        {
            var bips = Properties.Resources.bip.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (bips.Any())
                coinModel.Words.Where(w => string.IsNullOrWhiteSpace(w.Word) || !bips.Contains(w.Word)).ToList().ForEach(w => w.IsBIPValid = false);
        }

        private void GeneratePDFClick(object sender, RoutedEventArgs e)
        {
            window.SetPage(new PDFPage(coinModel.Clone()));
        }

        private void PreviewClick(object sender, RoutedEventArgs e)
        {
            if (window.frame.Content != null)
            {
                window.Show();
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (window.frame.Content != null)
            {
                PrintDialog dialog = new PrintDialog();
                var page = window.frame.Content as PDFPage;
                if (dialog.ShowDialog() == true)
                {
                    dialog.PrintVisual(page.grid, "PDF phrase");
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
