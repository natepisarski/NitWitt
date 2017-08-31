using System;
using System.Linq;
using NUnit.Framework;

namespace NitWitt.Tests
{
    [TestFixture]
    public class TestMarkovFunctionality
    {
        [Test]
        public static void TestGraphGeneration() {
            var graph = Markov.Markov.CreateGraphFrom("The Quick Brown Fox Jumps Over The Lazy Dog");
            Assert.AreEqual(8, graph.Nodes.Count);
        }
    }
}