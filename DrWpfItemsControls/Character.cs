using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrWpfItemsControls
{
    public class Character : INotifyPropertyChanged, IEditableObject
    {
        Character _cachedCopy = null;
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
        public string Gender {
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

        public void BeginEdit()
        {
            _cachedCopy = new Character();
            _cachedCopy._first = _first;
            _cachedCopy._last = _last;
            _cachedCopy._image = _image;
            _cachedCopy._gender = _gender;
        }

        public void EndEdit()
        {
            _cachedCopy = null;
        }

        public void CancelEdit()
        {
           if (_cachedCopy!=null)
            {
                First = _cachedCopy._first;
                Last = _cachedCopy._last;
                Gender = _cachedCopy._gender;
                Image = _cachedCopy._image;

            }
            _cachedCopy = null;
        }
    }

    public enum Gender
    {
        Female,
        Male,
        Unknown
    }

}
