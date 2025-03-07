namespace ObjectDiffNet.Common;

public record Difference(
    string TypeName,
    string PropertyName, 
    string PreviousValue,
    string NewValue,
    string DataType);