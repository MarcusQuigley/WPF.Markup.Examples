using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DrWpfItemsControls
{
    public static class Utilities
    {
        public static T VisualTreeWalkerFindChild<T>(DependencyObject current, string childName = "") where T : FrameworkElement
        {
            if (current == null)
                return null;

            T foundChild = null;
            var childrenCount = VisualTreeHelper.GetChildrenCount(current);
            if (childrenCount >0)
            {
                for (int i = 0; i < childrenCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(current, i);
                    T childType = child as T;
                    if (childType == null)
                    {
                        foundChild = VisualTreeWalkerFindChild<T>(child, childName);
                        if (foundChild != null)
                            break;
                    }
                    else if( !string.IsNullOrEmpty(childName))
                    {
                        var frameworkElement = child as FrameworkElement;
                        if (frameworkElement!=null && frameworkElement.Name.Equals(childName))
                        {
                            foundChild = child as T;
                            break;
                        }
                    }
                    else
                    {
                        foundChild = (T)child;
                    }

                }
            }

           
            return foundChild;
        }
    }
}
