using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF.MarkupExtensions
{
    public class SettingBindingExtension : Binding
    {
        public SettingBindingExtension()
        : this(string.Empty)
        { }

        public SettingBindingExtension(string path)
            : base(path)
        {
            Initialize();
        }

        private void Initialize()
        {
            base.Source = Properties.Settings.Default;
        }
    }
}
