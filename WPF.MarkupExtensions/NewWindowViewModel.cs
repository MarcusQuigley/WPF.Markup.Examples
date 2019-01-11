using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.MarkupExtensions
{
    class NewWindowViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Person> _people;
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        string _dayString = string.Empty;
        ICommand _dayCommand;
        public event PropertyChangedEventHandler PropertyChanged;


        public NewWindowViewModel()
        {
            _dayCommand = new RelayCommand(GetDay);

            People = new ObservableCollection<Person>() {
                new Person(){Id=1,Name= "Marcus",City= "New York" },
                 new Person(){Id=2,Name= "Ove",City= "Stockholm" },
                  new Person(){Id=3,Name= "Jaidi",City= "Bangkok" }
            };

            var assembliesTypeName = Assembly.GetExecutingAssembly().GetTypes().Take(5).Select(t => t.FullName).ToList();
            AssemblyTypes = new AsyncObservableCollection<string>(assembliesTypeName);
        }

        protected void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

        private AsyncObservableCollection<string> _strings;// = new AsyncObservableCollection<string>();
        public AsyncObservableCollection<string> AssemblyTypes
        {
            get { return _strings; }
            set
            {
                if (_strings != value)
                {
                    _strings = value;
                    OnPropertyChanged("AssemblyTypes");
                }
            }
        }

        public ObservableCollection<Person> People
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

        public ICommand DayCommand => _dayCommand;

        public TimeSpan CurrentTime
        {
            get => currentTime;
            set
            {
                if (currentTime != value)
                {
                    currentTime = value;
                    OnPropertyChanged("CurrentTime");
                }
            }
        }

        public string DayString
        {
            get => _dayString;
            set
            {
                if (_dayString != value)
                {
                    _dayString = value;
                    OnPropertyChanged("DayString");
                }
            }
        }

        async void GetDay(object o)
        {
            Random r = new Random();
            DayString = Enum.GetName(typeof(DayOfWeek), r.Next(7));
            await UpdatePeopleAsync();
            // People[1].Name = "Joe";
        }

        Task UpdatePeopleAsync()
        {
            return Task.Run(() =>
             {
                 Thread.Sleep(400);
                 People[1].Name = "Joe";
                 AssemblyTypes.Add( "New Value");

             });

        }

    }
}
