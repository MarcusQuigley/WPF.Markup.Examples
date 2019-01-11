using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.MarkupExtensions
{
    class NewWindowViewModel : INotifyPropertyChanged
    {
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

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
    }
}
