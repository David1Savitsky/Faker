using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests.Value.Generators.Primitive;

public class DoubleGeneratorTest
{
    private DoubleGenerator _doubleGenerator = new DoubleGenerator();
    private Type _type = typeof(double);
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());

    [Test]
    public void GenerateTest()
    {
        var actualResult = _doubleGenerator.Generate(_type, _generatorContext);

        Assert.True(actualResult is double);
        Assert.True((double)actualResult >= double.MinValue && (double)actualResult <= double.MaxValue);
    }

    [Test]
    public void CanGenerateTest()
    {
        var dateTimeResult = _doubleGenerator.CanGenerate(_type);
        var boolResult = _doubleGenerator.CanGenerate(typeof(bool));
        
        Assert.True(dateTimeResult);
        Assert.False(boolResult);
    }
}