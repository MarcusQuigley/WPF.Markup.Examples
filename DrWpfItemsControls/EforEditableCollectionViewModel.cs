using System;
using System.ComponentModel;
using  System.Collections.ObjectModel  ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrWpfItemsControls
{
    class EforEditableCollectionViewModel : INotifyPropertyChanged
    {
        Character _selectedCharacter;
        RelayCommand _commitCommand;
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

            public RelayCommand CommitCommand
        {
            get
            {
                if (_commitCommand == null)
                {
                    _commitCommand = new RelayCommand(Commit);
                }
                return _commitCommand;
            }
        }



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

        void Commit(object o)
        {

        }
    }
     
     
}