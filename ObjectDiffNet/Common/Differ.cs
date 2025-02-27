﻿using System.Reflection;

namespace ObjectDiffNet.Common;

public class Differ : IDiffer
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="original"></param>
    /// <param name="modified"></param>
    /// <returns></returns>
    public IEnumerable<Difference> GetDifferences(object original, object modified)
    {
        List<Difference> differences = new();
        
        if (original == null || modified == null)
        {
            return differences;
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