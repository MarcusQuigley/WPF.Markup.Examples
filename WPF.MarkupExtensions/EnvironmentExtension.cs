using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WPF.MarkupExtensions
{
    class EnvironmentExtension : MarkupExtension
    {
        public string VariableName { get; set; }

        public EnvironmentExtension(string variableName)
        {
            VariableName = variableName;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Environment.GetEnvironmentVariable(VariableName);
        }
    }
}
