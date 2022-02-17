using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mnemonic_phrase_to_PDF.Models
{
    public class CoinModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;

        private Uri icon;

        private System.Windows.Media.Brush color;

        private int wordCount;

        private string address;

        private bool generateQRForAddress;

        private bool generateQRForPhrase;


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

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public bool GenerateQRForAddress
        {
            get
            {
                return generateQRForAddress;
            }
            set
            {
                if (generateQRForAddress != value)
                {
                    generateQRForAddress = value;
                    OnPropertyChanged("GenerateQRForAddress");
                }
            }
        }

        public bool GenerateQRForPhrase
        {
            get
            {
                return generateQRForPhrase;
            }
            set
            {
                if (generateQRForPhrase != value)
                {
                    generateQRForPhrase = value;
                    OnPropertyChanged("GenerateQRForPhrase");
                }
            }
        }

        public bool AddressIsSetted => !string.IsNullOrWhiteSpace(Address);


        public CoinModel Clone()
        {
            return new CoinModel() { Words = Words, WordCount = WordCount, Name = Name, Color = Color, Icon = Icon, GenerateQRForPhrase = GenerateQRForPhrase, GenerateQRForAddress = GenerateQRForAddress, Address = Address };
        }

        private void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        public override string ToString()
        {
            return $"{Name} - {WordCount} words";
        }
    }
}
