using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faker.Value.Generators;

public class GeneratorsList
{
    public List<IValueGenerator> _generators = Assembly.GetExecutingAssembly().DefinedTypes
        .Where(t => t.GetInterface(nameof(IValueGenerator)) != null && t.IsClass && t != typeof(ValueGenerator))
        .Select(t => (IValueGenerator)Activator.CreateInstance(t)).ToList();
    
}