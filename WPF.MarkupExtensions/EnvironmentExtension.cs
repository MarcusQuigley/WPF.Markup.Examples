using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WPF.MarkupExtensions
{
    [MarkupExtensionReturnType(typeof(string))]
    public class EnvironmentExtension : MarkupExtension
    {
        public string VariableName { get; set; }

        public EnvironmentExtension() { }

        public EnvironmentExtension(string variableName)
        {
            VariableName = variableName;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(VariableName))
            {
                throw new ArgumentException("Variable name can't be empty");
            }
            return Environment.GetEnvironmentVariable(VariableName);
        }
    }
}
