using System;
using System.Collections;
using System.Linq;
using Faker.Generator;

namespace Faker.Value.Generators
{
    public class ListGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var genericTypeArgument = typeToGenerate.GenericTypeArguments[0];
            var listObject = Activator.CreateInstance(typeToGenerate);

            var length = context.Random.Next(10);
            
            var executeMethod = context.Faker
                .GetType()
                .GetMethod("Create")?
                .MakeGenericMethod(genericTypeArgument);

            for (int i = 0; i < length; i++)
            {
                var obj = new []{
                    executeMethod?.Invoke(context.Faker, new object[]{})
                };
                
                typeToGenerate.GetMethod("Add")?.Invoke(listObject, obj);
            }

            return listObject;
        }

        public bool CanGenerate(Type type)
        {
            var interfaces = type.GetInterfaces();
            return interfaces.Contains(typeof(IList)) && type.IsGenericType;
        }
    }
}