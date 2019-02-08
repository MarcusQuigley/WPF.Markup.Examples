using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

namespace HillbergExamplesTwo
{



    [ContentProperty("Arguments")]


    public class MethodCommandTwo : Freezable, ICommand, INotifyPropertyChanged
    {
        // The name of the method to call on Invoke
        public string MethodName { get; set; }
        // When this is set, exceptions during invoke are caught, and the exception
        // is set as the Exception property
        [DefaultValue(true)]
        public bool CatchExceptions { get; set; }
        // If there is an exception during a command invoke, and CatchExceptions
        // is set, this will have the exception object.
        public Exception Exception
        {
            get { return _exception; }
            private set
            {
                _exception = value;
                FirePropertyChanged("Exception");
            }
        }

        Exception _exception;

        public FreezableCollection<MethodArgumentTwo> Arguments
        {
            get { return (FreezableCollection<MethodArgumentTwo>)GetValue(ArgumentsProperty); }
        }

        public static readonly DependencyProperty ArgumentsProperty =
 DependencyProperty.Register("Arguments", typeof(FreezableCollection<MethodArgumentTwo>), typeof(MethodCommandTwo), null);

        private static readonly DependencyProperty ElementDataContextProperty =
        DependencyProperty.Register("ElementDataContext", typeof(object), typeof(MethodCommandTwo), null);

        public object Target
        {
            get { return (object)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        public static readonly DependencyProperty TargetProperty =
    DependencyProperty.Register("Target", typeof(object), typeof(MethodCommandTwo), null);
        public MethodCommandTwo()
        {
            SetValue(ArgumentsProperty, new FreezableCollection<MethodArgumentTwo>());

            BindingOperations.SetBinding(this, ElementDataContextProperty, new Binding());

            CatchExceptions = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // We need to implement this method because we're a Freezzable subtype.
        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }
        // Implement the CanExecute members of ICommand

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)

        {
            Exception = null;
            if (CatchExceptions)
            {
                try
                {
                    ExecuteImpl(parameter);
                }
                catch (Exception e)
                {
                    if (e is TargetInvocationException)
                    {
                        if (e.InnerException != null)
                            Exception = e.InnerException;
                        else
                            Exception = e;
                    }
                    else
                        Exception = e;
                }
            }

            else
            {
                ExecuteImpl(parameter);
            }
        }
        void ExecuteImpl(object parameter)
        {
            object target = Target;
            if (target == null)
            {
                target = GetValue(ElementDataContextProperty);
            }
            // We must have a target, either from Target or DataContext
            if (target == null)
            {
                throw new InvalidOperationException("MethodCommand target not found (must set either Target or DataContext)");
            }

            MethodInfo methodInfo = target.GetType().GetMethod(MethodName);
            if (methodInfo == null)
            {
                throw new InvalidOperationException("Method '" + MethodName + "' couldn't be found on type '" + target.GetType().Name + "'");
            }

            object[] arguments = new object[Arguments.Count];

            for (int i = 0; i < Arguments.Count; i++)
                arguments[i] = Arguments[i].Value;

            methodInfo.Invoke(target, arguments);
        }
    }

    // The MethodArgument class plugs into MethodCommand.Arguments


    public class MethodArgumentTwo : Freezable // Enable ElementName and DataContext bindings
    {
        public MethodArgumentTwo() { }
        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
       DependencyProperty.Register("Value", typeof(object), typeof(MethodArgumentTwo), null);

        // We need to implement this method since we are a subtype of Freezable.  But since
        // we don't need to support cloning, we won't implement it.
        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }
    }
}
