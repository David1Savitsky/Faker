using System;
using Faker.Generator;

namespace Faker.value_generators
{
    public interface IValueGenerator
    {
        object Generate(Type typeToGenerate, GeneratorContext context);

        bool CanGenerate(Type type);
    }
}