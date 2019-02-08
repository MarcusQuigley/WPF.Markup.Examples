using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF.MarkupExtensions
{
    class LocImageExtension : LocResourceExtension
    {
        public LocImageExtension() { }

        public LocImageExtension(string resourceKey) : base(resourceKey) { }

        public override object ProvideValueInternal(IServiceProvider serviceProvider)
        {
            Bitmap result = null;
            if (LocManager.ResourceManager != null)
            {
                //return LocManager.ResourceManager.GetObject(ResourceKey);
                result = LocManager.ResourceManager.GetObject(ResourceKey) as Bitmap; 
                return GetImageSource(result);
            }
            else
            {
                return "(LocImage)";
            }
        }

        private ImageSource GetImageSource(Bitmap bmp)
        {
            var src = Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return src;
        }
    }
}
