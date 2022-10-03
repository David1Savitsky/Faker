using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests.Value.Generators.Primitive;

public class IntGeneratorTest
{
    private IntGenerator _intGenerator = new IntGenerator();
    private Type _type = typeof(int);
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());

    [Test]
    public void GenerateTest()
    {
        var actualResult = _intGenerator.Generate(_type, _generatorContext);

        Assert.True(actualResult is int);
        Assert.True((int)actualResult >= int.MinValue && (int)actualResult <= int.MaxValue);
    }

    [Test]
    public void CanGenerateTest()
    {
        var intResult = _intGenerator.CanGenerate(_type);
        var boolResult = _intGenerator.CanGenerate(typeof(bool));
        
        Assert.True(intResult);
        Assert.False(boolResult);
    }
}