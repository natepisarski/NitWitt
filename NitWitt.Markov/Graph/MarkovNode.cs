using System;
using System.Collections.Generic;
using System.Linq;

namespace NitWitt.Markov.Graph
{
    public class MarkovNode
    {
        public string Data { get; }

        public List<MarkovEdge> Connections { get; set; } = new List<MarkovEdge>();

        public int ConnectionCount => Connections.Count;
        
        public int TotalAdded { get; private set; }
        
        private readonly Random _generator = new Random();
        
        public MarkovNode(string data) {
            Data = data;
        }

        public void AddConnection(MarkovEdge edge) {
            TotalAdded++;
            var existingConnection = Connections.FirstOrDefault(c => c.IsConnectedTo(edge.TargetData));
            if (existingConnection != null) {
                existingConnection.Probability += (1.0 / TotalAdded);
            }
            edge.Probability = 1.0 / TotalAdded;
            Connections.Add(edge);
        }

        public MarkovEdge GetEdgeBasedOnProbability() {
            double chooser = 1.0;
            MarkovEdge chosen = null;
            
            while (chosen == null && chooser > 0.0) {
                chooser -= _generator.NextDouble();
                var possibleEdges = Connections.Where(e => e.Probability >= chooser);
                if (possibleEdges.Any()) {
                    chosen = possibleEdges.OrderBy(e => e.Probability).FirstOrDefault();
                }
            }
            return chosen;
        }
    }
}