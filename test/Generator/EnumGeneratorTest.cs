using FuzzDotNet;
using FuzzDotNet.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FuzzDotNet.Test.Generator
{
    [TestClass]
    public class EnumGeneratorTest
    {
        enum TestEnum
        {
            Value1,
            Value2,
        }

        [TestMethod]
        public void GeneratesEnum()
        {
            var generator = new EnumGenerator();
            var random = new FuzzRandom();

            var generatedValue = generator.Generate(Mock.Of<IFuzzContext>(), typeof(TestEnum), random);

            Assert.IsTrue(generatedValue is TestEnum);
        }
    }
}
