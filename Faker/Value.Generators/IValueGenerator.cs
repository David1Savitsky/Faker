using System;
using Faker.Generator;

namespace Faker.Value.Generators
{
    public interface IValueGenerator
    {
        object Generate(Type typeToGenerate, GeneratorContext context);

        bool CanGenerate(Type type);
    }
}