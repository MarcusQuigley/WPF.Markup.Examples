using System;
using System.Windows;

namespace HillbergExamples
{
    
        public class MethodArgument : Freezable
        {
            public MethodArgument() {
             
        }
 
            public object Value
            {
                get { return (object)GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }

            // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register("Value", typeof(object), typeof(MethodArgument),null);



            protected override Freezable CreateInstanceCore()
            {
                throw new NotImplementedException();
            }
        }
  
}
