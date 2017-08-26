using System;
using System.Collections.Generic;
using System.Linq;

namespace NitWitt.Markov.Graph
{
    public class MarkovNode : DirectedGraphNode<List<string>, MarkovNodeMetadata, MarkovEdgeMetadata>
    {
        private readonly Random generator = new Random((int) DateTime.UtcNow.Ticks);
        
        public MarkovNode(List<string> words, MarkovNodeMetadata data = null) : base(words, data) {
            
        }

        public List<MarkovEdge> Edges => Connections.Select(x => (MarkovEdge) x).ToList();

        public void AddConnections(params MarkovEdge[] edges) {
            foreach (var edge in edges) {
                AddConnection(edge);
            }    
        }
        
        public MarkovEdge ChooseEdgeBasedOnProbability() {
            // Each edge has metadata with a probability from 0 to 1
            double chooser = 1;
            MarkovEdge chosen = null;

            while (chosen == null || chooser <= 0) {
                
                // Randomly reduces the chooser by a number between 0 and 1
                chooser -= generator.NextDouble();
                chosen = Edges.Where(edge => {
                    if (!edge.Metadata.HasValue) {
                        return false;
                    }
                    var probability = edge.Metadata.Return().Probability;
                    
                    /*
                    * The chance that the probability is greater than the chooser (which was randomly reduced)
                    * increases if probability is higher. Thus, items with a higher probability have a higher chance
                    * of being chosen.
                    */
                    return probability >= chooser;
                    
                    // If multiple probabilities meet the criteria, the one with the lowest chance is chosen
                }).OrderBy(edge => edge.Metadata.Return().Probability).Reverse().FirstOrDefault();
            }
            return chosen;
        }

        public string Generate(int sentenceLength, string prefix = "") 
            => sentenceLength == 0 ? prefix : ChooseEdgeBasedOnProbability().MarkovTarget.Generate(sentenceLength - 1);
        
        
        public MarkovEdge ChooseRandomConnection() {
            return Edges[generator.Next(0, Connections.Count)];
        }
    }
}