using System;
using Faker.Generator;

namespace Faker.Value.Generators
{
    public class IntGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.Next();
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(int);
        }
    }
}