using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests.Value.Generators.Primitive;

public class ShortGeneratorTest
{
    private ShortGenerator _shortGenerator = new ShortGenerator();
    private Type _type = typeof(short);
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());

    [Test]
    public void GenerateTest()
    {
        var actualResult = _shortGenerator.Generate(_type, _generatorContext);

        Assert.True(actualResult is short);
        Assert.True((short)actualResult >= short.MinValue && (short)actualResult <= short.MaxValue);
    }

    [Test]
    public void CanGenerateTest()
    {
        var shortResult = _shortGenerator.CanGenerate(_type);
        var boolResult = _shortGenerator.CanGenerate(typeof(bool));
        
        Assert.True(shortResult);
        Assert.False(boolResult);
    }
}