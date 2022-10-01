using System;
using System.Collections.Generic;
using System.Reflection;
using Faker.Checker;
using Faker.Generator;
using Faker.Value.Generators;

namespace Faker
{
    public class Faker : IFaker
    {

        private GeneratorContext _context;
        private ValueGenerator _valueGenerator;
        private DependencyChecker _dependencyChecker;
        
        public Faker()
        {
            _context = new GeneratorContext(new Random(), this);
            _valueGenerator = new ValueGenerator();
            _dependencyChecker = new DependencyChecker();

        }
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
        
        private object Create(Type t)
        {
            object obj;
            _dependencyChecker.AddTypeToDictionary(t);
            if (!_dependencyChecker.IsMaxNesting())
            {
                if (_valueGenerator.CanGenerate(t))
                {
                    obj = _valueGenerator.Generate(t,_context);
                }
                else
                {
                    var setParams = new HashSet<string>();
                    obj = CreateWithConstructor(t, ref setParams); 
                    SetFields(ref obj, t, setParams);
                    SetProperties(ref obj, t, setParams);
                }  
            }
            else
            {
                obj = null;
            }
            _dependencyChecker.DeleteTypeFromDictionary(t);
            return obj;
        }

        private ConstructorInfo GetConstructorWithMaxCountOfParams(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();

            if (constructors.Length == 1)
                return constructors[0];

            int indexOfConstructorWithMaxCountOfparams = 0;

            for (int i = 1; i < constructors.Length; i++)
            {
                if (constructors[i - 1].GetParameters().Length < constructors[i].GetParameters().Length)
                    indexOfConstructorWithMaxCountOfparams = i;
            }

            return constructors[indexOfConstructorWithMaxCountOfparams];
        }

        private object CreateWithConstructor(Type t, ref HashSet<string> setParams)
        {
            ConstructorInfo constructorInfo = GetConstructorWithMaxCountOfParams(t);
            var paramValues = new object[constructorInfo.GetParameters().Length];
            for (int i = 0; i < paramValues.Length; i++)
            {
                if (_valueGenerator.CanGenerate(constructorInfo.GetParameters()[i].ParameterType))
                {
                    paramValues[i] = _valueGenerator.Generate(constructorInfo.GetParameters()[i].ParameterType, _context);
                    setParams.Add(constructorInfo.GetParameters()[i].Name);
                }
                else
                {
                    paramValues[i] = Create(constructorInfo.GetParameters()[i].ParameterType);
                }
            }
            return constructorInfo.Invoke(paramValues);
        }

        private void SetFields(ref object obj, Type t, HashSet<string> setParams)
        {
            var fields = t.GetFields();
            foreach (var field in fields)
            {
                if (!setParams.Contains(field.Name))
                {
                    if (_valueGenerator.CanGenerate(field.FieldType))
                    {
                        field.SetValue(obj, _valueGenerator.Generate(field.FieldType, _context));
                    }
                    else
                    {
                        field.SetValue(obj, Create(field.FieldType));
                    }
                }
            }
        }

        private void SetProperties(ref object obj, Type t, HashSet<string> setParams)
        {
            var properties = t.GetProperties();
            foreach (var property in properties)
            {
                if (!setParams.Contains(property.Name))
                {
                    if (property.CanWrite)
                    {
                        if (_valueGenerator.CanGenerate(property.PropertyType))
                        {
                            property.SetValue(obj, _valueGenerator.Generate(property.PropertyType, _context));
                        }
                        else
                        {
                            property.SetValue(obj, Create(property.PropertyType));
                        }
                    }
                    
                }
            }
        }
    }
}