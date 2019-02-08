using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HillbergExamples
{
    class File : INotifyPropertyChanged
    {
        public File()
        {

        }

        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public void Rename(string newName)
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;


        public ICommand SomeCommand { get; }
 

    }
}
