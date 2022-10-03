using Faker.Exceptions;

namespace Faker.Tests;

public class FakerTest
{
    private IFaker _faker;
        
        [SetUp]
        public void Setup()
        {
            _faker = new Faker();
        }

        [Test]
        public void CreateInt()
        {
            Type targetType = typeof(int);
            
            var testValue = _faker.Create<int>();
            
            Assert.IsInstanceOf(targetType, testValue);
        }

        
        
        [Test]
        public void CreateEmptyClass()
        {
            Type targetType = typeof(FakerModels.EmptyClass);
            
            var testValue = _faker.Create<FakerModels.EmptyClass>();
            
            Assert.IsInstanceOf(targetType, testValue);
        }
        
        [Test]
        public void CreateSimpleFieldsClass()
        {
            Type targetType = typeof(FakerModels.SimpleFieldsClass);
            
            var testValue = _faker.Create<FakerModels.SimpleFieldsClass>();
            
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
            Assert.NotNull(testValue.Z);
        }
        
        [Test]
        public void CreateTwoConstructorsClass()
        {
            Type targetType = typeof(FakerModels.TwoConstructorsClass);
            
            var testValue = _faker.Create<FakerModels.TwoConstructorsClass>();
            
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
            Assert.NotNull(testValue.Z);
        }
        
        [Test]
        public void CreateClassWithPrivateConstructor()
        {
            Type targetType = typeof(FakerModels.PrivateConstructorClass);

            Assert.Throws<CanNotCreateTheObject>(() => _faker.Create<FakerModels.PrivateConstructorClass>());
        }
        
        [Test]
        public void CreateClassWithoutConstructor()
        {
            Type targetType = typeof(FakerModels.WithoutConstructorClass);
            
            var testValue = _faker.Create<FakerModels.WithoutConstructorClass>();
            
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
            Assert.NotNull(testValue.Z);
        }
        
        [Test]
        public void CreatePropertiesClass()
        {
            Type targetType = typeof(FakerModels.PropertiesClass);
            
            var testValue = _faker.Create<FakerModels.PropertiesClass>();
            
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
            Assert.Null(testValue.Z);
        }
        
        [Test]
        public void CreateClassWithInnerClass()
        {
            Type targetType = typeof(FakerModels.ClassWithInnerClass);
            
            var testValue = _faker.Create<FakerModels.ClassWithInnerClass>();
            
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
            Assert.NotNull(testValue.Z);
            Assert.NotNull(testValue.Z.X);
            Assert.NotNull(testValue.Z.Y);
            Assert.NotNull(testValue.Z.Z);
        }

        [Test]
        public void CreateRecursiveFieldClass()
        {
            Type targetType = typeof(FakerModels.RecursiveFieldClass);
            
            var testValue = _faker.Create<FakerModels.RecursiveFieldClass>();
            
            Assert.IsInstanceOf(targetType, testValue);
        }

        [Test]
        public void CreateListClass()
        {
            Type targetType = typeof(FakerModels.ListClass);

            var testValue = _faker.Create<FakerModels.ListClass>();

            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.List);
            Assert.NotZero(testValue.List.Count);
        }

        [Test]
        public void DateTimeClass()
        {
            Type targetType = typeof(FakerModels.DateTimeClass);

            var testValue = _faker.Create<FakerModels.DateTimeClass>();

            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.Time);
        }

        [Test]
        public void CreateSimpleStruct()
        {
            Type targetType = typeof(FakerModels.SimpleFieldsStruct);

            var testValue = _faker.Create<FakerModels.SimpleFieldsStruct>();
            
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
        }
        
        [Test]
        public void CreateStructWithoutConstructor()
        {
            Type targetType = typeof(FakerModels.StructWithoutConstructor);

            var testValue = _faker.Create<FakerModels.StructWithoutConstructor>();
            
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
        }
}