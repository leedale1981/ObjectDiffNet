namespace ObjectDiffNet.Common;

public record Difference(
    string PropertyName, 
    string PreviousValue,
    string NewValue,
    Type DataType);