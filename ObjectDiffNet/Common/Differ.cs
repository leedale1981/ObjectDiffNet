using System.Reflection;

namespace ObjectDiffNet.Common;

public class Differ : IDiffer
{
    /// <summary>
    /// Returns a list of differences between two objects.
    /// </summary>
    /// <param name="original">Original object.</param>
    /// <param name="modified">Modified object.</param>
    /// <returns>IEnumerable of Differences.</returns>
    public IEnumerable<Difference> GetDifferences(object original, object modified)
    {
        List<Difference> differences = new();
        
        if (original == null || modified == null)
        {
            throw new ArgumentException("Both original and modified objects must be provided and non null.");
        }
        
        Type originalType = original.GetType();
        PropertyInfo[] properties = originalType.GetProperties();
        
        foreach (PropertyInfo property in properties)
        {
            object originalValue = property.GetValue(original);
            object modifiedValue = property.GetValue(modified);
            
            if (!Equals(originalValue, modifiedValue))
            {
                differences.Add(new(
                    originalType.Name, 
                    property.Name, 
                    originalValue.ToString(), 
                    modifiedValue.ToString(), 
                    property.PropertyType));
            }
        }

        return differences;
    }
}