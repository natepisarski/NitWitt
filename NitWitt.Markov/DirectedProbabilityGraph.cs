using System.Collections.Generic;
using System.Linq;
using Bolster.API.Interface.Stateless;
using Bolster.API.Status.Stateless;
using Bolster.Base;

namespace NitWitt.Markov
{
    public class MarkovNode : DirectedGraphNode<List<string>, MarkovNodeMetadata, MarkovEdgeMetadata>
    {
        public MarkovNode(List<string> words, MarkovNodeMetadata data = null) : base(words, data) {
            
        }
    }

    public class MarkovEdge : DirectedGraphEdge<List<string>, MarkovEdgeMetadata, MarkovNodeMetadata>
    {
        public MarkovEdge(MarkovNode source, MarkovNode target, MarkovEdgeMetadata data = null) : base(source, target,
            data) {
            
        }
    }
}