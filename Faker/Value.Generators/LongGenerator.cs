using System;
using Faker.Generator;

namespace Faker.Value.Generators
{
    public class LongGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            //return context.Random.NextInt64(int.MinValue, int.MaxValue);
            throw new NotImplementedException();
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(long);
        }
    }
}