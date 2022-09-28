using System;
using Faker.Generator;

namespace Faker.Value.Generators
{
    public class FloatGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            double mantissa = (context.Random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, context.Random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(float);
        }
    }
}