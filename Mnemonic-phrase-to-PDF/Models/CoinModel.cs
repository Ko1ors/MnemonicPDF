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

        private Image icon;

        private Color color;

        private int wordCount;

        public List<string> Words { get; set; } = new List<string>();

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

        public Image Icon
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

        public Color Color
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
