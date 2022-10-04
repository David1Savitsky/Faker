using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Faker.Checker;
using Faker.Exceptions;
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
        
        public object Create(Type t)
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
                    obj = CreateWithConstructor(t); 
                    SetFields(ref obj, t);
                    SetProperties(ref obj, t);
                }  
            }
            else
            {
                obj = null;
            }
            _dependencyChecker.DeleteTypeFromDictionary(t);
            return obj;
        }

        private IOrderedEnumerable<ConstructorInfo> GetConstructors(Type type)
        {
            return type.GetConstructors().OrderByDescending(i => i.GetParameters().Length);
        }

        private object CreateWithConstructor(Type t)
        {
            IOrderedEnumerable<ConstructorInfo> constructorInfos = GetConstructors(t);
            foreach (var constructorInfo in constructorInfos)
            {
                try
                {
                    var paramValues = new object[constructorInfo.GetParameters().Length];
                    for (int i = 0; i < paramValues.Length; i++)
                    {
                        if (_valueGenerator.CanGenerate(constructorInfo.GetParameters()[i].ParameterType))
                        {
                            paramValues[i] = _valueGenerator.Generate(constructorInfo.GetParameters()[i].ParameterType, _context);
                        }
                        else
                        {
                            paramValues[i] = Create(constructorInfo.GetParameters()[i].ParameterType);
                        }
                    }
                    return constructorInfo.Invoke(paramValues);
                }
                catch (System.Exception)
                {
                    
                }
            }
            
            try
            {
                return Activator.CreateInstance(t)!;

            }
            catch (System.Exception)
            {
            }

            throw new CanNotCreateTheObject();
        }

        private void SetFields(ref object obj, Type t)
        {
            var fields = t.GetFields();
            foreach (var field in fields)
            {
                if (field.GetValue(obj) != null && field.GetValue(obj).Equals(GetDefaultObjectValueType(t))) continue;
                field.SetValue(obj,
                    _valueGenerator.CanGenerate(field.FieldType)
                        ? _valueGenerator.Generate(field.FieldType, _context)
                        : Create(field.FieldType));
            }
        }

        private void SetProperties(ref object obj, Type t)
        {
            var properties = t.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(obj) != null &&
                    property.GetValue(obj).Equals(GetDefaultObjectValueType(t))) continue;
                if (!property.CanWrite) continue;
                property.SetValue(obj,
                    _valueGenerator.CanGenerate(property.PropertyType)
                        ? _valueGenerator.Generate(property.PropertyType, _context)
                        : Create(property.PropertyType));
            }
        }

        private object GetDefaultObjectValueType(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}