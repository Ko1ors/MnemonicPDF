using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mnemonic_phrase_to_PDF.Models
{
    public class WordModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int number;

        private string word;

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

        public override string ToString()
        {
            return Word;
        }
    }
}
