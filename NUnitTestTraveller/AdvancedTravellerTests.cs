using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Traveller;

namespace NUnitTestTraveller
{
    public class AdvancedTravellerTests
    {
        ITraveller traveller;
        [SetUp]
        public void Setup()
        {
            traveller = new AdvancedTraveller.AdvancedTraveller();
        }
        [Test]
        public void SimpleTest()
        {
            var cells = new int[][] {
                new int[] { 0, 0, 1 },
                new int[] { 0, 1, 0 },
                new int[] { 0, 1, 0}
            };
            int result = traveller.Travel(1, cells);
            Assert.AreEqual(result, 2);
        }
        [Test]
        public void AdvancedTest()
        {
            var cells = new int[][]
            {
                new int[]{ 0, 0, 0, 1},
                new int[]{ 0, 1, 0, 1},
                new int[]{ 1, 0, 0, 1},
                new int[]{ 0, 0, 1, 1},
                new int[]{ 0, 0, 0, 0},
            };
            int result = traveller.Travel(2, cells);
            Assert.AreEqual(result, 0);
            // Продвинутый путешественник может справиться с любым лабиринтом
        }
    }
}
