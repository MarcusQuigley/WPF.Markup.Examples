using System;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace WPF.MarkupExtensions
{
    public abstract class UpdatableMarkupExtension : MarkupExtension
    {
        private object _target;
        private object _targetProperty;

        public sealed override object ProvideValue(IServiceProvider serviceProvider)
        {
            var target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (target != null)
            {
                _target = target.TargetObject;
                _targetProperty = target.TargetProperty;
            }
            return ProvideValueInternal(serviceProvider);
        }

        protected void UpdateValue(object value)
        {
            if (_target != null)
            {
                if (_targetProperty is DependencyProperty)
                {
                    DependencyObject obj = _target as DependencyObject;
                    DependencyProperty prop = _targetProperty as DependencyProperty;
                    Action updateAction = () => obj.SetValue(prop, value);
                    if (obj.CheckAccess())
                        updateAction();
                    else
                        obj.Dispatcher.Invoke(updateAction);
                }
                else
                {
                    PropertyInfo prop = _target as PropertyInfo;
                    prop.SetValue(_target, value, null);
                }
            }

        }

        protected abstract object ProvideValueInternal(IServiceProvider serviceProvider);

    }
}
