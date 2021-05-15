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
    /// Логика взаимодействия для WordUC.xaml
    /// </summary>
    public partial class WordUC : UserControl
    {
        public static readonly DependencyProperty WordProperty = DependencyProperty.Register("Word", typeof(string), typeof(WordUC), new FrameworkPropertyMetadata("Word"));

        public WordModel Word
        {
            get { return GetValue(WordProperty) as WordModel; }
            set { SetValue(WordProperty, value); }
        }

        public WordUC()
        {
            InitializeComponent();
        }
    }
}
