using System;
using System.Reflection;
using Faker.Creator;
using Faker.Generator;
using Faker.Value.Generators;

namespace Faker
{
    public class Faker : IFaker
    {

        private GeneratorContext _context;
        private DtoCreator _dtoCreator;
        private ValueGenerator _valueGenerator;
        
        public Faker()
        {
            _context = new GeneratorContext(new Random(), this);
            _dtoCreator = new DtoCreator();
            _valueGenerator = new ValueGenerator();

        }
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
        
        private object Create(Type t)
        {
            object obj;
            if (_valueGenerator.CanGenerate(t))
            {
                obj = _valueGenerator.Generate(t,_context);
            }
            else
            {
                obj = _dtoCreator.Create(t, _context);
            }

            return obj;
        }
    }
}