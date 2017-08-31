using System.Linq;
using NitWitt.Markov.Graph;

namespace NitWitt.Markov
{
    public static class Markov
    {
        public static DirectedProbabilityGraph CreateGraphFrom(string sentence, int magnitude = 1) {
            var graph = new DirectedProbabilityGraph(magnitude);
            var source = sentence.Split(' ');
            graph.AddFrom(source);
            graph.OptimizeGraph();
            return graph;
        }

        public static string GenerateSentenceFrom(this DirectedProbabilityGraph graph, int sentenceLength, string seed = null) {
            if (seed == null) {
                return graph.GetRandomNode().Generate(sentenceLength);
            }
            return graph.Nodes.FirstOrDefault(node => node.Data.Contains(seed)).Generate(sentenceLength);
        }
    }
}