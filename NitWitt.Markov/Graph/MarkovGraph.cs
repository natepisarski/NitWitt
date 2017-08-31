using System;
using System.Collections.Generic;
using System.Linq;

namespace NitWitt.Markov.Graph
{
    public class MarkovGraph
    {
        public List<MarkovNode> Nodes { get; } = new List<MarkovNode>();

        private Random _generator = new Random();
        public MarkovGraph(string bodyText) {
            AddTokens(bodyText.Split(' ').ToList());
        }

        /// <summary>
        /// TODO: Cleanup Duplcation
        /// </summary>
        /// <param name="tokens"></param>
        public void AddTokens(List<string> tokens) {
            for(int i = 0; i + 1 < tokens.Count; i++) {
                
                var existingNode = Nodes.FirstOrDefault(n => n.Data.Equals(tokens[i]));
                var connectionNode = Nodes.FirstOrDefault(n => n.Data.Equals(tokens[i + 1])) ?? new MarkovNode(tokens[i + 1]);

                if (existingNode == null) {
                    var newNode = new MarkovNode(tokens[i]);
                    newNode.AddConnection(new MarkovEdge(1.0, connectionNode));
                    Nodes.Add(newNode);
                }
                else {
                    existingNode.AddConnection(new MarkovEdge(1.0, connectionNode));
                }
            }
        }

        public MarkovNode NodeWithData(string nodeData) =>
            Nodes.FirstOrDefault(n => n.Data.Equals(nodeData, StringComparison.InvariantCultureIgnoreCase));

        public MarkovNode RandomNode => Nodes[_generator.Next(0, Nodes.Count - 1)];

        public MarkovNode NodeWithDataOrRandom(string nodeData) => NodeWithData(nodeData) ?? RandomNode;
        
        public List<string> Generate(int tokenCount = 0, string targetNodeData = "") {
            var returned = new List<string>();
            var targetNode = NodeWithDataOrRandom(targetNodeData);
            returned.Add(targetNode.Data);
            if (tokenCount == 0) {
                return returned;
            }
            returned.AddRange(Generate(tokenCount - 1, targetNode.GetEdgeBasedOnProbability().TargetData));
            return returned;
        }

        public string GenerateSentence(int tokenCount = 0, string targetNodeData = "") {
            return Generate(tokenCount, targetNodeData).Aggregate((col, it) => $"{col} {it}");
        }
    }
}