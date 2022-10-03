using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests.Value.Generators.Primitive;

public class FloatGeneratorTest
{
    private FloatGenerator _floatGenerator = new FloatGenerator();
    private Type _type = typeof(float);
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());

    [Test]
    public void GenerateTest()
    {
        var actualResult = _floatGenerator.Generate(_type, _generatorContext);

        Assert.True(actualResult is float);
        Assert.True((float)actualResult >= float.MinValue && (float)actualResult <= float.MaxValue);
    }

    [Test]
    public void CanGenerateTest()
    {
        var floatResult = _floatGenerator.CanGenerate(_type);
        var boolResult = _floatGenerator.CanGenerate(typeof(bool));
        
        Assert.True(floatResult);
        Assert.False(boolResult);
    }
}