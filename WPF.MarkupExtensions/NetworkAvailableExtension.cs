using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WPF.MarkupExtensions
{
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
