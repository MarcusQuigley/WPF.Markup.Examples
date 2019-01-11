using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.MarkupExtensions
{
    class NewWindowViewModel : INotifyPropertyChanged
    {
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        string _dayString = string.Empty;
        ICommand _dayCommand;
        public event PropertyChangedEventHandler PropertyChanged;


        public NewWindowViewModel()
        {
            _dayCommand = new RelayCommand(GetDay);
        }
        protected void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

        public ICommand DayCommand   => _dayCommand;
 
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

        public string DayString { get => _dayString;
                set {
                if (_dayString != value)
                {
                    _dayString = value;
                    OnPropertyChanged("DayString");
                }
            } }

        void GetDay(object o)
        {
            Random r = new Random();
            DayString = Enum.GetName(typeof(DayOfWeek), r.Next(7));
        }

    }
}
