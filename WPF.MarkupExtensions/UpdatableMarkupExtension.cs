using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace WPF.MarkupExtensions
{
    public abstract class UpdatableMarkupExtension : MarkupExtension
    {
        private List<object> _targetList = new List<object>();
      //  private object _target;
        private object _targetProperty;

        public sealed override object ProvideValue(IServiceProvider serviceProvider)
        {
            var target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (target != null)
            {
                if (target.TargetObject.GetType().FullName == "System.Windows.SharedDp")
                    return this;
                _targetList.Add(target.TargetObject);
                if (_targetProperty==null)
                    _targetProperty = target.TargetProperty;
            }
            return ProvideValueInternal(serviceProvider);
        }

        protected void UpdateValue(object value)
        {
            foreach (object target in _targetList)
            {


               // if (_target != null)
                {
                    if (_targetProperty is DependencyProperty)
                    {
                        DependencyObject obj = target as DependencyObject;
                        DependencyProperty prop = _targetProperty as DependencyProperty;
                        Action updateAction = () => obj.SetValue(prop, value);
                        if (obj.CheckAccess())
                            updateAction();
                        else
                            obj.Dispatcher.Invoke(updateAction);
                    }
                    else
                    {
                        PropertyInfo prop = target as PropertyInfo;
                        prop.SetValue(target, value, null);
                    }
                 }
            }

        }

        protected abstract object ProvideValueInternal(IServiceProvider serviceProvider);

    }
}
