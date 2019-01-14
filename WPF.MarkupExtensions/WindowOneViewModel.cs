using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.MarkupExtensions
{
    class WindowOneViewModel : BaseViewModel
    {
        AsyncObservableCollection<Person> _people;
        bool _showId;

        public WindowOneViewModel()
        {
            People = new AsyncObservableCollection<Person>() {
                new Person(){Id=1,Name= "Marcus",City= "New York" },
                 new Person(){Id=2,Name= "Ove",City= "Stockholm" },
                  new Person(){Id=3,Name= "Jaidi",City= "Bangkok" }
            };
        }

        public AsyncObservableCollection<Person> People
        {
            get => _people;
            set
            {
                if (_people != value)
                {
                    _people = value;
                    OnPropertyChanged("People");
                }
            }
        }

        public bool ShowId
        {
            get => _showId;
            set
            {
                if (_showId != value)
                {
                    _showId = value;
                    OnPropertyChanged("ShowId");
                }
            }
        }

        public void MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
