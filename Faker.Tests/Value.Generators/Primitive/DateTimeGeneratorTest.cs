using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests.Value.Generators.Primitive;

public class DateTimeGeneratorTest
{
    private DateTimeGenerator _dateTimeGenerator = new DateTimeGenerator();
    private Type _type = typeof(DateTime);
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());

    [Test]
    public void GenerateTest()
    {
        var actualResult = _dateTimeGenerator.Generate(_type, _generatorContext);

        Assert.True(actualResult is DateTime);
        Assert.True((DateTime)actualResult >= DateTime.MinValue && (DateTime)actualResult <= DateTime.MaxValue);
    }

    [Test]
    public void CanGenerateTest()
    {
        var dateTimeResult = _dateTimeGenerator.CanGenerate(_type);
        var boolResult = _dateTimeGenerator.CanGenerate(typeof(bool));
        
        Assert.True(dateTimeResult);
        Assert.False(boolResult);
    }
}