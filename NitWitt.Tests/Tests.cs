using System;
using System.Linq;
using NitWitt.Markov;
using NitWitt.Markov.Graph;
using NUnit.Framework;

namespace NitWitt.Tests
{
    [TestFixture]
    public class TestMarkovFunctionality
    {
        public static MarkovGraph FoxGraph => new MarkovGraph("The quick brown fox jumps over the lazy dog");

        public static MarkovGraph ComplexGraph => new MarkovGraph(
            "Shall I compare thee to a summer's day? hou art more lovely and more temperate: Rough winds do shake the darling buds of May," +
            "And summer's lease hath all too short a date:Sometime too hot the eye of heaven shines,nd often is his gold complexion dimmed," +
            "And every fair from fair sometime declines,By chance, or nature's changing course untrimmed:But thy eternal summer shall not fade"
        );
        [Test]
        public static void TestGraphCreation() {
            Assert.AreEqual(8, FoxGraph.Nodes.Count);
        }

        [Test]
        public static void TestSentenceGeneration() {
            Assert.Pass(ComplexGraph.GenerateSentence(50));
        }
    }
}