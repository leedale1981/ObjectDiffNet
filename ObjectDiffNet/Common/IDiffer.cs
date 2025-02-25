namespace ObjectDiffNet.Common;

public interface IDiffer
{
    IEnumerable<Difference> GetDifferences(object original, object modified);
}
