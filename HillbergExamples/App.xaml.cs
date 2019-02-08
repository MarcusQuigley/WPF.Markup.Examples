using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HillbergExamples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            FreezableContext window = new FreezableContext();
            window.Show();

            
            //this.MainWindow = new FreezableContext();

            //this.StartupUri = new Uri("FreezableContext.xaml");
        }
    }
}
