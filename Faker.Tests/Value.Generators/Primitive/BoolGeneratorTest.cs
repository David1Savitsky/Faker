using Faker.Generator;
using Faker.Value.Generators;
using Moq;

namespace Faker.Tests.Value.Generators.Primitive;

public class BoolGeneratorTest
{
    private BoolGenerator _boolGenerator = new BoolGenerator();
    private Type _type = typeof(bool);
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());

    [Test]
    public void GenerateTest()
    {
        var actualResult = _boolGenerator.Generate(_type, _generatorContext);

        Assert.True(actualResult is bool);
        Assert.True((bool)actualResult || !(bool)actualResult);
    }

    [Test]
    public void CanGenerateTest()
    {
        var boolResult = _boolGenerator.CanGenerate(_type);
        var byteResult = _boolGenerator.CanGenerate(typeof(byte));
        
        Assert.True(boolResult);
        Assert.False(byteResult);
    }
}