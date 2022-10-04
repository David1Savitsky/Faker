using Faker.Checker;

namespace Faker.Tests.Checker;

public class DependencyCheckerTest
{
    private DependencyChecker _checker;
    
    [SetUp]
    public void Setup()
    {
        _checker = new();
    }
        
    [Test]
    public void AddTypeToDictionaryTest()
    {
        _checker.AddTypeToDictionary(typeof(int));

        int count = _checker._dependencyCounter[typeof(int)];
            
        Assert.True(count == 1);
    }
        
    [Test]
    public void DeleteTypeFromDictionaryTest()
    {
        _checker.AddTypeToDictionary(typeof(int));
        _checker.AddTypeToDictionary(typeof(int));
            
        _checker.DeleteTypeFromDictionary(typeof(int));
        int count = _checker._dependencyCounter[typeof(int)];
            
        Assert.True(count == 1);
    }
        
    [Test]
    public void IsMaxNestingTest()
    {
        _checker.AddTypeToDictionary(typeof(int));
            
        Assert.False(_checker.IsMaxNesting());
            
        _checker.AddTypeToDictionary(typeof(int));
        _checker.AddTypeToDictionary(typeof(int));
            
        Assert.True(_checker.IsMaxNesting());
    }
}