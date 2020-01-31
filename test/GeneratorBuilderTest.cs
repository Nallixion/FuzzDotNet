﻿using System;
using System.Collections.Generic;
using System.Text;
using FuzzDotNet.Core.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuzzDotNet.Test
{
    [TestClass]
    public class GeneratorBuilderTest
    {
        [TestMethod]
        public void WrongType()
        {
            Assert.ThrowsException<ArgumentException>(() => GeneratorBuilder.BuildGenerator(typeof(int)));
        }

        public class WrongArgumentTypeClass : IGenerator
        {
            public WrongArgumentTypeClass(string argument)
            {
            }

            public object? Generate(Random random)
            {
                return null;
            }
        }

        [TestMethod]
        public void WrongArgumentType()
        {
            Assert.ThrowsException<ArgumentException>(() => GeneratorBuilder.BuildGenerator(typeof(WrongArgumentTypeClass), 20));
        }
    }
}
