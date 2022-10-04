using Faker.Exceptions;
using Faker.Generator;
using Faker.Value.Generators;

namespace Faker.Tests;

public class FakerModels
{
    public class EmptyClass
    {
        
    }

    public class SimpleFieldsClass
    {
        public int? X;
        public bool? Y;
        public double? Z;

        public SimpleFieldsClass(int x, bool y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class TwoConstructorsClass
    {
        public int? X;
        public bool? Y;
        public double? Z;

        public TwoConstructorsClass(int x, bool y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public TwoConstructorsClass(int x, bool y)
        {
            X = x;
            Y = y;
        }
    }

    public class PrivateConstructorClass
    {
        public int? X;

        private PrivateConstructorClass(int x)
        {
            X = x;
        }
    }

    public class WithoutConstructorClass
    {
        public int? X;
        public bool? Y;
        public double? Z;
    }
    
    public class PropertiesClass
    {
        public int? X { get; set; }
        public bool? Y { get; set; }
        public double? Z { get; }
    }

    public class ClassWithInnerClass
    {
        public int? X;
        public bool? Y;
        public SimpleFieldsClass Z;

        public ClassWithInnerClass(int x, bool y, SimpleFieldsClass z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class RecursiveFieldClass
    {
        public RecursiveFieldClass field;
    }

    public class ListClass
    {
        public List<RecursiveFieldClass> List;
    }

    public class DateTimeClass
    {
        public DateTime? Time;
    }

    public struct SimpleFieldsStruct
    {
        public int? X;
        public bool? Y;

        public SimpleFieldsStruct(int? x, bool? y)
        {
            X = x;
            Y = y;
        }
    }
    
    public struct StructWithoutConstructor
    {
        public int? X;
        public bool? Y;
    }

    public class ConstructorWithExc
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }

        public ConstructorWithExc(string A, string B, string C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            throw new CanNotCreateTheObject();
        }

        public ConstructorWithExc(string A, string B)
        {
            this.A = A;
            this.B = B;
        }
    }
}