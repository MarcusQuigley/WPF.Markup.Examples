using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrWpfItemsControls
{
    public class Character : INotifyPropertyChanged
    {
        string _first = string.Empty;
        string _last = string.Empty;
        int _age = 0;
        //  Gender _gender = Gender.Unknown;
        String _gender = "Gender.Unknown";
        string _image = string.Empty;
          Point _location = new Point();

        
        public string First
        {
            get => _first;
            set
            {
                if (_first != value)
                {
                    _first = value;
                    OnPropertyChanged("First");
                }
            }
        }
        public string Last {
            get => _last;
            set
            {
                if (_last != value)
                {
                    _last = value;
                    OnPropertyChanged("Last");
                }
            }
        }
        public int Age {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged("Age");
                }
            }
        }
        public String Gender {
            get => _gender;
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }
        public string Image {
            get => _image;
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }

       
        public Point Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }



        public override string ToString()
        {
            return _first + " " + _last;
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public enum Gender
    {
        Female,
        Male,
        Unknown
    }

}
