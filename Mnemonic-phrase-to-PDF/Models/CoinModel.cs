using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Controls;

namespace Mnemonic_phrase_to_PDF.Models
{
    public class CoinModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;

        private Uri icon;

        private System.Windows.Media.Brush color;

        private int wordCount;

        public List<WordModel> Words { get; set; } = new List<WordModel>();

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }

        }

        public Uri Icon
        {
            get
            {
                return icon;
            }
            set
            {
                if (icon != value)
                {
                    icon = value;
                    OnPropertyChanged("Icon");
                }
            }

        }

        public System.Windows.Media.Brush Color
        {
            get
            {
                return color;
            }
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged("Color");
                }
            }

        }

        public int WordCount
        {
            get
            {
                return wordCount;
            }
            set
            {
                if (wordCount != value)
                {
                    wordCount = value;
                    OnPropertyChanged("WordCount");
                }
            }

        }

        private void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
