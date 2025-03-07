using ObjectDiffNet.Common;

namespace ObjectDiffNet.Tests;

public class ObjectDiffTests
{
    private readonly TestClass _object1 = new()
    {
        StringProperty = "Test",
        IntProperty = 1,
        BoolProperty = true,
        DateProperty = new DateTime(2021, 1, 1),
        DecimalProperty = 1.1m,
    };
    
    private readonly TestClass _object2 = new()
    {
        StringProperty = "Test2",
        IntProperty = 2,
        BoolProperty = false,
        DateProperty = new DateTime(2021, 2, 1),
        DecimalProperty = 1.1m,
    };

    private readonly IEnumerable<Difference> _differences; 
    
    public ObjectDiffTests()
    {
        IDiffer diff = new Differ();
        _differences = diff.GetDifferences(_object1, _object2);
    }
    
    [Fact]
    public void Differences_Not_Empty()
    {
        Assert.NotEmpty(_differences);
    }
    
    [Fact]
    public void Differences_Count_Is_Correct()
    {
        Assert.Equal(4, _differences.Count());
    }
    
    [Fact]
    public void Differences_StringProperty_Has_Correct_Difference()
    {
        Assert.Contains(new( "TestClass","StringProperty", "Test", "Test2", typeof(string).ToString()), 
            _differences);
    }
    
    [Fact]
    public void Differences_IntProperty_Has_Correct_Difference()
    {
        Assert.Contains(new("TestClass","IntProperty", "1", "2", typeof(int).ToString()), 
            _differences);
    }
    
    [Fact]
    public void Differences_BoolProperty_Has_Correct_Difference()
    {
        Assert.Contains(new("TestClass","BoolProperty", "True", "False", typeof(bool).ToString()), 
            _differences);
    }
    
    [Fact]
    public void Differences_DateProperty_Has_Correct_Difference()
    {
        Assert.Contains(new("TestClass","DateProperty", "01/01/2021 00:00:00", "01/02/2021 00:00:00", typeof(DateTime).ToString()), 
            _differences);
    }
    
    [Fact]
    public void Differences_DecimalProperty_Not_In_Differences()
    {
        Assert.DoesNotContain(new("TestClass","DecimalProperty", "1.1", "1.1", typeof(decimal).ToString()), 
            _differences);
    }
}