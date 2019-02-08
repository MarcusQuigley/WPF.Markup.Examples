using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace DrWpfItemsControls
{
    class FindNameExtension : MarkupExtension
    {
        Character character;
        public string ElementToFind { get; set; }

        public FindNameExtension() { }
        
            public FindNameExtension(string elementToFind)
        {
            ElementToFind = elementToFind;

            character = new Character();
            character.PropertyChanged += Character_PropertyChanged;
        }

        private void Character_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
           
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //var target
            if (string.IsNullOrEmpty(ElementToFind))
                return null;

            var provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (provideValueTarget != null)
            {
                var target = provideValueTarget.TargetObject;
                var listBox = ((FrameworkElement)target).FindName(ElementToFind) as ListBox  ;
                if (listBox!=null)
                {
                    character = (Character)listBox.SelectedItem;
                    return character.First;
                }
            }
            else
            {
                throw new InvalidOperationException("no target...");
            }
            return null;
        }
    }
}
