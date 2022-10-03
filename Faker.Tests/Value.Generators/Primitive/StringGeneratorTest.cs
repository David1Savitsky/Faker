using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests.Value.Generators.Primitive;

public class StringGeneratorTest
{
    private StringGenerator _stringGenerator = new StringGenerator();
    private Type _type = typeof(string);
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());

    [Test]
    public void GenerateTest()
    {
        var actualResult = _stringGenerator.Generate(_type, _generatorContext);

        Assert.True(actualResult is string);
        foreach (var ch in (string)actualResult)
        {
            Assert.True(ch >= char.MinValue && ch <= char.MaxValue);
        }
    }

    [Test]
    public void CanGenerateTest()
    {
        var stringResult = _stringGenerator.CanGenerate(_type);
        var boolResult = _stringGenerator.CanGenerate(typeof(bool));
        
        Assert.True(stringResult);
        Assert.False(boolResult);
    }
}