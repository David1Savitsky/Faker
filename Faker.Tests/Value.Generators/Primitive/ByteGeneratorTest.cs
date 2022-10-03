using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests.Value.Generators.Primitive;

public class ByteGeneratorTest
{
    private ByteGenerator _byteGenerator = new ByteGenerator();
    private Type _type = typeof(byte);
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());

    [Test]
    public void GenerateTest()
    {
        var actualResult = _byteGenerator.Generate(_type, _generatorContext);

        Assert.True(actualResult is byte);
        Assert.True((byte)actualResult >= byte.MinValue && (byte)actualResult <= byte.MaxValue);
    }

    [Test]
    public void CanGenerateTest()
    {
        var byteResult = _byteGenerator.CanGenerate(_type);
        var boolResult = _byteGenerator.CanGenerate(typeof(bool));
        
        Assert.True(byteResult);
        Assert.False(boolResult);
    }
}