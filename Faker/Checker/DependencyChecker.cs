using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Checker;

public class DependencyChecker
{
    const int MAX_NESTING = 2;
    public Dictionary<Type, int> _dependencyCounter = new(); 
    
    public void AddTypeToDictionary(Type type)
    {
        if (_dependencyCounter.ContainsKey(type))
        {
            _dependencyCounter[type] += 1;
        }
        else
        {
            _dependencyCounter.Add(type, 1);
        }
    }

    public void DeleteTypeFromDictionary(Type type)
    {
        if (_dependencyCounter.ContainsKey(type) && _dependencyCounter[type] > 1)
        {
            _dependencyCounter[type] -= 1;
        }
        else
        {
            _dependencyCounter.Remove(type);
        }
    }

    public bool IsMaxNesting()
    {
        foreach (var typeCount in _dependencyCounter.Values)
        {
            if (typeCount > MAX_NESTING)
                return true;
        }
        return false;
    }
    
}