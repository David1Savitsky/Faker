using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests.Value.Generators.Primitive;

public class LongGeneratorTest
{
    private LongGenerator _longGenerator = new LongGenerator();
    private Type _type = typeof(long);
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());

    [Test]
    public void GenerateTest()
    {
        var actualResult = _longGenerator.Generate(_type, _generatorContext);

        Assert.True(actualResult is long);
        Assert.True((long)actualResult >= long.MinValue && (long)actualResult <= long.MaxValue);
    }

    [Test]
    public void CanGenerateTest()
    {
        var longResult = _longGenerator.CanGenerate(_type);
        var boolResult = _longGenerator.CanGenerate(typeof(bool));
        
        Assert.True(longResult);
        Assert.False(boolResult);
    }
}