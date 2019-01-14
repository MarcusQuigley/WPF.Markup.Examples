using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows;

namespace WPF.MarkupExtensions
{
    class EventBindingExtension : MarkupExtension
    {
        public EventBindingExtension() { }

        public EventBindingExtension(string eventHandlerName)
        {
            this.EventHandlerName = eventHandlerName;
        }
        [ConstructorArgument("eventHandlerName")]
        public string EventHandlerName { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(EventHandlerName))
                throw new ArgumentException("EventHandlerName");
            var target =(IProvideValueTarget) serviceProvider.GetService(typeof(IProvideValueTarget));

            EventInfo eventInfo = target.TargetProperty as EventInfo;
            if (eventInfo==null)
                throw new InvalidOperationException("prop must be EventInfo");

            object dataContext = GetDataContext(target.TargetObject);
            if (dataContext == null)
                throw new InvalidOperationException("no dataContext found");

            var handler = GetHandler(dataContext, eventInfo, EventHandlerName);
            if (handler == null)
                throw new InvalidOperationException("no event handler found");
            return handler;

        }

        static object GetHandler(object dataContext, EventInfo eventInfo, string eventHandlerName)
        {
            Type dcType = dataContext.GetType();

            var method = dcType.GetMethod(
                eventHandlerName,
                GetParameterTypes(eventInfo));
            if (method != null)
            {
                if (method.IsStatic)
                    return Delegate.CreateDelegate(eventInfo.EventHandlerType, method);
                else
                    return Delegate.CreateDelegate(eventInfo.EventHandlerType, dataContext, method);
            }

            return null;
        }

        static Type[] GetParameterTypes(EventInfo eventInfo)
        {
            var invokeMethod = eventInfo.EventHandlerType.GetMethod("Invoke");
            return invokeMethod.GetParameters().Select(p => p.ParameterType).ToArray();
        }

        static object GetDataContext(object targetObject)
        {
            if (targetObject == null)
                throw new ArgumentNullException("targetObject");
            var depObj = (DependencyObject)targetObject;
            if (depObj == null)
                return null;

            return depObj.GetValue(FrameworkElement.DataContextProperty) ??
                depObj.GetValue(FrameworkContentElement.DataContextProperty);
        }
    }
}
