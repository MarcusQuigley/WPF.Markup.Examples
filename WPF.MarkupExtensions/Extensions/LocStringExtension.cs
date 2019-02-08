using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WPF.MarkupExtensions
{
    class LocStringExtension : LocResourceExtension
    {
        public LocStringExtension() { }

        public LocStringExtension(string resourceKey) : base(resourceKey) { }

        public override object ProvideValueInternal(IServiceProvider serviceProvider)
        {
             if (LocManager.ResourceManager != null)
                return LocManager.ResourceManager.GetString(ResourceKey);
            else
                return "(locString)";

        }
    }
}
