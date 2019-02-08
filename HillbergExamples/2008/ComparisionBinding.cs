//
// ComparisonBinding is a Binding that should be used in a DataTrigger.Binding.
// It supports a comparison operator and a comparand, so that you can use it as a
// conditional DataTrigger.  The trick is to set {x:Null} as the DataTrigger.Value.
// E.g.:
//
//  <DataTrigger Value={x:Null}
//               Binding={h:ComparisonBinding Width, EQ, 100}"
//
// The operator can be EQ, LT, LTE, GT, GTE.
//
using System.Windows.Data;

public class ComparisonBinding : Binding
{
    // Default constructor
    public ComparisonBinding(): this(null, ComparisonOperators.EQ, null)
    {
    }
    // Construction with an operator & comparand
    public ComparisonBinding(string path, ComparisonOperators op, object comparand)
    : base(path)
    {
        RelativeSource = RelativeSource.Self;
        Comparand = comparand;
        Operator = op;
        Converter = new ComparisonConverter(this);
    }
    // Operator and comparand
    public ComparisonOperators Operator { get; set; }
    public object Comparand { get; set; }
}
// Supported types of comparisons

public enum ComparisonOperators
{
    EQ = 0,
    GT,
    GTE,
    LT,
    LTE
}
