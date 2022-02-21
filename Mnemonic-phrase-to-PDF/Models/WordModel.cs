using System;
using System.ComponentModel;
using System.Windows.Media;

namespace Mnemonic_phrase_to_PDF.Models
{
    public class WordModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int number;

        private string word;

        private bool isBIPValid;

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }

        }

        public string Word
        {
            get
            {
                return word;
            }
            set
            {
                if (word != value)
                {
                    word = value;
              
                    OnPropertyChanged("Word");
                    if (!IsBIPValid)
                    {
                        IsBIPValid = true;
                        OnPropertyChanged("BorderBrush");
                    }
                }
            }

        }

        public bool IsBIPValid
        {
            get 
            {
                return isBIPValid;
            }
            set 
            {
                if (isBIPValid != value)
                {
                    isBIPValid = value;
                    OnPropertyChanged("BorderBrush");
                }
            }
        }

        public Brush BorderBrush => isBIPValid ? new SolidColorBrush(Colors.Gray) : new SolidColorBrush(Colors.Red);

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
            return Word;
        }
    }
}
