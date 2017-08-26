using System.Collections.Generic;

namespace NitWitt.Markov.Graph
{
    public class MarkovEdge : DirectedGraphEdge<List<string>, MarkovEdgeMetadata, MarkovNodeMetadata>
    {
        public MarkovEdge(MarkovNode source, MarkovNode target, MarkovEdgeMetadata data = null) : base(source, target,
            data) {
            
        }

        public MarkovNode MarkovSource => (MarkovNode) Source;
        public MarkovNode MarkovTarget => (MarkovNode) Target;
    }
}