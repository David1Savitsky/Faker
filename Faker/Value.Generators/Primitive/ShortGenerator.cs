using System;
using Faker.Generator;

namespace Faker.Value.Generators
{
    public class ShortGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return (short)context.Random.Next(short.MinValue, short.MaxValue);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(short);
        }
    }
}