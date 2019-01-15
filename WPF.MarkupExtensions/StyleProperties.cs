using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPF.MarkupExtensions
{
    public static class StyleProperties
    {
        public static Brush GetBackBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BackBrushProperty);
        }

        public static void SetBackBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(BackBrushProperty, value);
        }

        public static readonly DependencyProperty BackBrushProperty =
            DependencyProperty.RegisterAttached("BackBrush", typeof(Brush), typeof(StyleProperties), new PropertyMetadata(Brushes.Black));

        public static int GetAPWidth(DependencyObject obj)
        {
            return (int)obj.GetValue(APWidthProperty);
        }

        public static void SetAPWidth(DependencyObject obj, int value)
        {
            obj.SetValue(APWidthProperty, value);
        }
        
        public static readonly DependencyProperty APWidthProperty =
            DependencyProperty.RegisterAttached("APWidth", typeof(int), typeof(StyleProperties), new PropertyMetadata(0));
 
    }
}
