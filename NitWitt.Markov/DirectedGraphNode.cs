using System.Collections.Generic;
using System.Linq;
using Bolster.API.Interface.Stateless;
using Bolster.API.Status.Stateless;
using Bolster.Base;
using Bolster.Base.Interface;

namespace NitWitt.Markov
{
    public class DirectedGraphNode<T, W, Z> where W: INodeMetadata where Z: IEdgeMetadata
    {
        public T Data { get; }

        public Maybe<W> Metadata { get; }
        
        public List<DirectedGraphEdge<T, Z, W>> Connections { get; } = new List<DirectedGraphEdge<T, Z, W>>();

        public Either<Success, Failure> AreConnectionsValid =>
            Connections.All(edge => edge.Target.Equals(this)).ToStatus();
        
        public DirectedGraphNode(T data, W metadata) {
            Data = data;
            Metadata = metadata.AsMaybe();
        }

        public void AddConnection(DirectedGraphEdge<T, Z, W> connectionToAdd)
            => Connections.Add(connectionToAdd);
    }
}