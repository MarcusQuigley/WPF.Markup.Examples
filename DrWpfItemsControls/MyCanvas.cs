using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DrWpfItemsControls
{
   public class MyCanvas :Canvas
    {
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var size = base.ArrangeOverride(arrangeSize);
            Console.WriteLine($"myCanvas ArrangeOverride size:" +
                $"{arrangeSize.Height} - {arrangeSize.Width} after kids size:{size.Height} - {size.Width}");
            return size;
        }
        protected override Size MeasureOverride(Size constraint)
        {
            var size =  base.MeasureOverride(constraint);
            Console.WriteLine($"myCanvas MeasureOverride size:" +
           $"{constraint.Height} - {constraint.Width} after kids size:{size.Height} - {size.Width}");
            return size;
        }
    }

    public class MyWrapPanel : WrapPanel
    {
        protected override Size ArrangeOverride(Size finalSize)
        {
            var size =    base.ArrangeOverride(finalSize);
            Console.WriteLine($"myWrapPanel ArrangeOverride size:" +
                $"{finalSize.Height} - {finalSize.Width} after kids size:{size.Height} - {size.Width}");
            return size;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            var size = base.MeasureOverride(constraint);
            Console.WriteLine($"myWrapPanel MeasureOverride size:" +
            $"{constraint.Height} - {constraint.Width} after kids size:{size.Height} - {size.Width}");
            return size;
        }
    }
}
