using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.MarkupExtensions
{
    class BindingProxy : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        //public static object GetData(DependencyObject obj)
        //{
        //    return (object)obj.GetValue(DataProperty);
        //}

        //public static void SetData(DependencyObject obj, object value)
        //{
        //    obj.SetValue(DataProperty, value);
        //}

        //// Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty DataProperty =
        //    DependencyProperty.RegisterAttached("Data", typeof(object), typeof(BindingProxy), new PropertyMetadata(null));



        public object Datad
        {
            get { return (object)GetValue(DatadProperty); }
            set { SetValue(DatadProperty, value); }
        }

        
        public static readonly DependencyProperty DatadProperty =
            DependencyProperty.Register("Datad", typeof(object), typeof(BindingProxy), new PropertyMetadata(null));



    }
}
