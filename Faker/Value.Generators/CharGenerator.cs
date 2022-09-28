using System;
using Faker.Generator;

namespace Faker.Value.Generators
{
    public class CharGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (char)context.Random.Next(0, 255);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(char);
        }
    }
}