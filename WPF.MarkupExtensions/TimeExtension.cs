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
            base.UpdateValue(e.SignalTime.TimeOfDay.ToString());
        }

        protected override object ProvideValueInternal(IServiceProvider serviceProvider)
        {
            return (DateTime.Now.TimeOfDay.ToString());
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
    public class NetworkAvailableExtension : UpdatableMarkupExtension
    {
        public NetworkAvailableExtension()
        {
            NetworkChange.NetworkAvailabilityChanged += 
                new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
        }

        protected override object ProvideValueInternal(IServiceProvider serviceProvider)
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            UpdateValue(e.IsAvailable);
        }
    }
}
