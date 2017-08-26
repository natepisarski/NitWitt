using Bolster.Base;
using Bolster.Base.Interface;

namespace NitWitt.Markov
{
    public class DirectedGraphEdge<T, W, Z> where W: IEdgeMetadata where Z: INodeMetadata
    {
        public DirectedGraphNode<T, Z, W> Source { get; }
        
        public DirectedGraphNode<T, Z, W> Target { get; }

        public Maybe<W> Metadata { get; }
        
        public DirectedGraphEdge(DirectedGraphNode<T, Z, W> source, DirectedGraphNode<T, Z, W> target, W metadata) {
            Source = source;
            Target = target;
            Metadata = metadata.AsMaybe();
        }
    }
}