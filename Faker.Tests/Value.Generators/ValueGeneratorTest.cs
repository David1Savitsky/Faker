using Faker.Exceptions;
using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests.Value.Generators;

public class ValueGeneratorTest
{
    private ValueGenerator _valueGenerator = new ValueGenerator();
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());
    
    private Type _type = typeof(char);

    [Test]
    public void GenerateValue()
    {
        var actualResult = _valueGenerator.Generate(_type, _generatorContext);

        Assert.True(actualResult is char);
        Assert.True((char)actualResult >= char.MinValue && (char)actualResult <= char.MaxValue);
        Assert.Catch<PrimitiveGenerationException>(() => _valueGenerator.Generate(typeof(IEnumerable<>), _generatorContext));
    }
        
    [Test]
    public void CanGenerateValue()
    {
        var byteResult = _valueGenerator.CanGenerate(typeof(byte));
        var stringResult = _valueGenerator.CanGenerate(typeof(string));
        var dateFormatResult = _valueGenerator.CanGenerate(typeof(IEnumerable<>));

        Assert.True(stringResult);
        Assert.True(byteResult);
        Assert.False(dateFormatResult);
    }
}