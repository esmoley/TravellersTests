using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Traveller;

namespace NUnitTestTraveller
{
    public class SimpleTravellerTests
    {
        ITraveller traveller;
        [SetUp]
        public void Setup()
        {
            traveller = new SimpleTraveller.SimpleTraveller();
        }
        [Test]
        public void SimpleTest()
        {
            var cells = new int[][] {
                new int[] { 0, 0, 1 },
                new int[] { 0, 1, 0 },
                new int[] { 0, 1, 0}
            };
            
            int result = traveller.Travel(1,cells);
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
            Assert.AreEqual(result, 4);
            // Должно быть 4, т.к. обычный путешественник идет вниз, но если внизу оплата, он пытается двигаться вправо.
            // Итак он заплатит на ячейках (1,1),(2,1) и (2,3),(3,4). Лабиринты ему не по зубам
        }
    }
}
