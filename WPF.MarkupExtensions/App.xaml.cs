using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF.MarkupExtensions.Properties;

namespace WPF.MarkupExtensions
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Exit += ((s,e)=> Settings.Default.Save() );
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            throw new NotImplementedException();
        }

        //protected override void OnExit(ExitEventArgs e)
        //{
        //    base.OnExit(e);
        //    Settings.Default.Save();
        //}
    }
}
