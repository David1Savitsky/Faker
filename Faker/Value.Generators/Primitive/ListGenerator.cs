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
            var listObject = (IList)Activator.CreateInstance(typeToGenerate);

            var length = context.Random.Next(10);
            
            /*var executeMethod = context.Faker
                .GetType()
                .GetMethod("Create")?
                .MakeGenericMethod(genericTypeArgument);*/
            

            for (int i = 0; i < length; i++)
            {
                //typeToGenerate.GetMethod("Add")?.Invoke(listObject, obj);
                listObject.Add(context.Faker.Create(genericTypeArgument));
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