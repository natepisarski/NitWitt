using System;
using System.Collections.Generic;

namespace NitWitt.Markov.Graph
{
    public class MarkovEdge
    {
        public double Probability { get; set; }
        
        public MarkovNode TargetNode { get; }

        public MarkovEdge(double probability, MarkovNode target) {
            Probability = probability;
            TargetNode = target;
        }

        public bool IsConnectedTo(MarkovNode node) {
            return node == TargetNode;
        }

        public bool IsConnectedTo(string data) {
            return TargetNode.Data.Equals(data, StringComparison.InvariantCultureIgnoreCase);
        }

        public string TargetData => TargetNode.Data;

        public void AdjustProbability(int totalConnectionCount) {
            
        }
    }
}