using System;
using System.Text;
using Faker.Generator;

namespace Faker.Value.Generators
{
    public class StringGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var str = new StringBuilder();
            var strLength = context.Random.Next(0, 10);
            for (int i = 0; i < strLength; i++)
            {
                str.Append((char) context.Random.Next(0, 255));
            }

            return str.ToString();
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(string);
        }
    }
}