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

namespace HillbergExamples
{
    public class MethodCommand : Freezable, ICommand, INotifyPropertyChanged
    {
        Exception _exception;


        public MethodCommand()
        {
             SetValue(ArgumentsProperty, new FreezableCollection<MethodArgument>());

            // Set a default Binding onto the private ElementDataContextProperty.
            // A default binding just binds to the inherited DataContext.  This is how
            // MethodCommand typically gets the object on which to invoke the method.

            BindingOperations.SetBinding(this, ElementDataContextProperty, new Binding());
            CatchExceptions = true;
        }

        public string MethodName { get; set; }
        [DefaultValue(true)]
        public bool CatchExceptions { get; set; }

        public Exception Exception
        {
            get => _exception;
            set
            {
                if (_exception != value)
                {
                    _exception = value;
                    OnPropertyChanged("Exception");
                }
            }
        }

        public FreezableCollection<MethodArgument> Arguments   
        {
            get { return (FreezableCollection<MethodArgument>)GetValue(ArgumentsProperty); }
            set { SetValue(ArgumentsProperty, value); }
        }

        public static readonly DependencyProperty ArgumentsProperty =
            DependencyProperty.Register("Arguments", typeof(FreezableCollection<MethodArgument>), 
                typeof(MethodCommand), null);

        private static readonly DependencyProperty ElementDataContextProperty =
            DependencyProperty.Register("ElementDataContext", typeof(object), typeof(MethodCommand), new PropertyMetadata(null));

        public object Target
        {
            get { return (object)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }
 
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(object), typeof(MethodCommand), new PropertyMetadata(null));


        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

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
                target = GetValue(ElementDataContextProperty);
            if (target == null)
                throw new InvalidOperationException("MethodCommand Target not found");

            MethodInfo methodInfo = target.GetType().GetMethod(MethodName);
            if (methodInfo==null)
                throw new InvalidOperationException("Method '" + MethodName + "' couldn't be found on type '" + target.GetType().Name + "'");

            object[] arguments = new object[Arguments.Count];
            for (int i = 0; i < Arguments.Count; i++)
            {
                arguments[i] = Arguments[i].Value;
            }

            methodInfo.Invoke(target, arguments);

        }

        protected void OnPropertyChanged(string property)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

           
        }

        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }
    }
}
