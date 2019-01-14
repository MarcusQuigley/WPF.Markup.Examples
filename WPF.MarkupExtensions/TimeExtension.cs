using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Markup;

namespace WPF.MarkupExtensions
{
    class TimeExtension : UpdatableMarkupExtension, IDisposable
    {
        Timer _timer = null;
        public TimeExtension()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            base.UpdateValue(e.SignalTime.TimeOfDay.ToString(@"hh\:mm\:ss"));
        }

        protected override object ProvideValueInternal(IServiceProvider serviceProvider)
        {
            return (DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss"));
        }

        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
        }
    }
  
}
