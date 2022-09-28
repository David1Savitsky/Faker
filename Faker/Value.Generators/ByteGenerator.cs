using System;
using Faker.Generator;

namespace Faker.Value.Generators
{
    public class ByteGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.Next(0, 255);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(byte);
        }
    }
}