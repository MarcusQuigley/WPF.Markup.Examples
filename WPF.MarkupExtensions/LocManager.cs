using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPF.MarkupExtensions.Properties;

namespace WPF.MarkupExtensions
{
   public class LocManager
    {
        private static ResourceManager resourceManager = null;
        public static ResourceManager ResourceManager => resourceManager ?? (resourceManager = GetResourceManager());
        static ResourceManager GetResourceManager()
        {
            Assembly asm = GetAssembly;
            if (asm!=null)
            {
                var baseName = asm.GetName().Name + ".Properties.Resources";
                ResourceManager resourceManager = new ResourceManager(baseName, asm);
                return resourceManager;
            }
            return null;
        }
       static Assembly GetAssembly => Assembly.GetEntryAssembly();

        public   List<string> SomeItems() { return Enumerable.Range(1, 3).Select(i => i.ToString()).ToList(); }

        public static IEnumerable<CultureInfo> AvailableCultures
        {
            get
            {
                List<CultureInfo> result = new List<CultureInfo>();

                ResourceManager rm = new ResourceManager(typeof(Resources));

                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
                foreach (CultureInfo culture in cultures)
                {
                    try
                    {
                       // if (culture.Equals(CultureInfo.InvariantCulture)) continue; //do not use "==", won't work

                        ResourceSet rs = rm.GetResourceSet(culture, true, false);
                        if (rs != null)
                            result.Add(culture);
                    }
                    catch (CultureNotFoundException)
                    {
                        //NOP
                    }
                }
                return result;
            }
        }

        public static CultureInfo UICulture
        {
            get => Thread.CurrentThread.CurrentUICulture;
            set
            {
                Thread.CurrentThread.CurrentUICulture = value;
                OnUICultureChanged();
            }
        }
            private static HashSet<EventHandler> uiCultureChangedHandlers = new HashSet<EventHandler>();

        public static event EventHandler UICultureChanged
        {
            add { uiCultureChangedHandlers.Add(value); }
            remove { uiCultureChangedHandlers.Remove(value); }
        }
        private static void OnUICultureChanged()
        {
            foreach (EventHandler handler in uiCultureChangedHandlers)
            {
                handler(typeof(LocManager), EventArgs.Empty);
            }
        }
    }
}
