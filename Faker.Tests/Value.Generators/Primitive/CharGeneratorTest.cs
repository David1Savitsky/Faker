using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests.Value.Generators.Primitive;

public class CharGeneratorTest
{
    private CharGenerator _charGenerator = new CharGenerator();
    private Type _type = typeof(char);
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());

    [Test]
    public void GenerateTest()
    {
        var actualResult = _charGenerator.Generate(_type, _generatorContext);

        Assert.True(actualResult is char);
        Assert.True((char)actualResult >= char.MinValue && (char)actualResult <= char.MaxValue);
    }

    [Test]
    public void CanGenerateTest()
    {
        var charResult = _charGenerator.CanGenerate(_type);
        var boolResult = _charGenerator.CanGenerate(typeof(bool));
        
        Assert.True(charResult);
        Assert.False(boolResult);
    }
}