using System;
using System.ComponentModel;
using  System.Collections.ObjectModel  ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DrWpfItemsControls
{
    class EforEditableCollectionViewModel : INotifyPropertyChanged
    {
        Character _selectedCharacter;
        //ObservableCollection<Character> _people;

        //public ObservableCollection<Character> People
        //{
        //    get => _people;
        //    set
        //    {
        //        if (_people != value)
        //        {
        //            _people = value;
        //        }
        //    }
        //}

        public Character SelectedCharacter {
            get => _selectedCharacter;
            set
            {
                if (_selectedCharacter != value)
                {
                    _selectedCharacter = value;
                    OnPropertyChanged("SelectedCharacter");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
     
     
}