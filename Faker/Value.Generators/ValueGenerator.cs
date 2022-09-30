using System;
using System.Collections.Generic;
using Faker.Exceptions;
using Faker.Generator;

namespace Faker.Value.Generators;

public class ValueGenerator : IValueGenerator
{
    private IList<IValueGenerator> _generators;

    public ValueGenerator()
    {
        _generators = new GeneratorsList()._generators;
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