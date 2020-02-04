using System;
using System.Collections.Generic;
using FuzzDotNet.Core;
using FuzzDotNet.Core.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuzzDotNet.Test
{
    [TestClass]
    public class NaughtyIntGeneratorTest
    {
        [TestMethod]
        public void GeneratesInt()
        {
            var generator = new NaughtyIntGenerator();
            var random = new FuzzRandom();

            var generatedValue = generator.Generate(random);

            Assert.IsTrue(generatedValue is int);
        }
    }
}
