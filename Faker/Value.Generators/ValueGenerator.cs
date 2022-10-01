using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Faker.Exceptions;
using Faker.Generator;

namespace Faker.Value.Generators;

public class ValueGenerator : IValueGenerator
{
    private IList<IValueGenerator> _generators;

    public ValueGenerator()
    {
        _generators = Assembly.GetExecutingAssembly().DefinedTypes
            .Where(t => t.GetInterface(nameof(IValueGenerator)) != null && t.IsClass && t != typeof(ValueGenerator))
            .Select(t => (IValueGenerator)Activator.CreateInstance(t)).ToList();
    }

    public object Generate(Type typeToGenerate, GeneratorContext context)
    {
        foreach (var generator in _generators)
        {
            if (generator.CanGenerate(typeToGenerate))
            {
                return generator.Generate(typeToGenerate, context);
            }
        }

        throw new PrimitiveGenerationException();
    }

    public bool CanGenerate(Type type)
    {
        for (int i = 0; i < _generators.Count; i++)
        {
            if (_generators[i].CanGenerate(type))
            {
                return true;
            }
        }

        return false;
    }
}