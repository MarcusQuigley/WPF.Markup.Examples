using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace WPF.MarkupExtensions
{
    abstract class LocResourceExtension : MarkupExtension
    {
        protected WeakReference targetObjectRef;
        protected object targetProperty;

        public LocResourceExtension() { }

        public LocResourceExtension(string resourceKey)
        {
            ResourceKey = resourceKey;
        }

        public string ResourceKey { get; set; }

        public sealed override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(ResourceKey))
                throw new InvalidOperationException("ResourceKey must not be null");

            IProvideValueTarget target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (target!=null)
            {
                if(target.TargetObject!=null && target.TargetProperty!=null)
                {
                    this.targetObjectRef = new WeakReference(target.TargetObject);
                    this.targetProperty = target.TargetProperty;
                    LocManager.UICultureChanged += LocManager_UICultureChanged;
                }
            }

            return ProvideValueInternal(serviceProvider);
        }

        private void LocManager_UICultureChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            if (!targetObjectRef.IsAlive)
            {
                LocManager.UICultureChanged-= LocManager_UICultureChanged;
                return;
            }
            object value = ProvideValueInternal(null);
            if (targetProperty is DependencyProperty)
            {
                DependencyObject obj = targetObjectRef.Target as DependencyObject;
                DependencyProperty dp = targetProperty as DependencyProperty;
                obj.SetValue(dp, value);
            }
            else
            {
                object obj = targetObjectRef.Target;
                PropertyInfo prop = targetProperty as PropertyInfo;
                prop.SetValue(obj, value);
            }

        }

        public abstract object ProvideValueInternal(IServiceProvider serviceProvider);
    }
}
