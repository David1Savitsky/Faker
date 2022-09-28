using System;
using Faker.Generator;

namespace Faker.Value.Generators
{
    public class BoolGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return 1 == context.Random.Next(0, 1);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(bool);
        }
    }
}