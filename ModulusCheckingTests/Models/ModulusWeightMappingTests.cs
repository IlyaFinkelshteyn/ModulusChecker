﻿using System;
using System.Linq;
using ModulusChecking.Models;
using NUnit.Framework;

namespace ModulusCheckingTests.Models
{
    public class ModulusWeightMappingTests
    {
        [Test]
        [TestCase("123456 001234 MOD11 2 1 2 1 2 1 2 1 2 1 2 1 2 1", ModulusAlgorithm.Mod11)]
        [TestCase("123456 001234 MoD11 2 1 2 1 2 1 2 1 2 1 2 1 2 1", ModulusAlgorithm.Mod11)]
        [TestCase("123456 001234 MOD10 2 1 2 1 2 1 2 1 2 1 2 1 2 1", ModulusAlgorithm.Mod10)]
        [TestCase("123456 001234 mod10 2 1 2 1 2 1 2 1 2 1 2 1 2 1", ModulusAlgorithm.Mod10)]
        [TestCase("123456 001234 DBLAL 2 1 2 1 2 1 2 1 2 1 2 1 2 1", ModulusAlgorithm.DblAl)]
        [TestCase("123456 001234 dBlAl 2 1 2 1 2 1 2 1 2 1 2 1 2 1", ModulusAlgorithm.DblAl)]
        [TestCase("123456 001234 PLOPPY 2 1 2 1 2 1 2 1 2 1 2 1 2 1", ModulusAlgorithm.DblAl, ExpectedException = typeof(ArgumentException))]
        public void CanAddAlgorithm(string row, ModulusAlgorithm expected)
        {
            var actual = new ModulusWeightMapping(row);
            Assert.NotNull(actual);
            Assert.AreEqual(expected,actual.Algorithm);
        }

        [Test]
        public void CanLoadWeightingValues()
        {
            var actual = new ModulusWeightMapping("230872 230872 DBLAL    2    1    2    1    2    1    2    1    2    1    2    1    2    1");
            var expectedWeightValues = new[] {2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1};
            for(var i = 0; i<actual.WeightValues.Count(); i++)
            {
                Assert.AreEqual(actual.WeightValues.ElementAt(i),expectedWeightValues[i]);
            }
        }
    }
}
