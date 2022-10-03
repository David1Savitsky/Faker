using System.Collections;
using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests.Value.Generators.Primitive;

public class ListGeneratorTest
{
    private ListGenerator _listGenerator = new ListGenerator();
    private Type _type = typeof(List<>);
    private GeneratorContext _generatorContext = new GeneratorContext(new Random(), new Faker());

    [Test]
    public void CanGenerateTest()
    {
        var intResult = _listGenerator.CanGenerate(_type);
        var boolResult = _listGenerator.CanGenerate(typeof(bool));
        
        Assert.True(intResult);
        Assert.False(boolResult);
    }
}