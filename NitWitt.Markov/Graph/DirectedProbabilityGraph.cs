﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bolster.API.Interface.Mixed;
using Bolster.API.Interface.Stateless;
using Bolster.API.Status.Stateless;
using Bolster.Base;

namespace NitWitt.Markov.Graph
{
    public class DirectedProbabilityGraph
    {
        public List<MarkovNode> Nodes { get; }
        
        public int Magnitude { get; }
        
        protected Random Generator { get; } = new Random();
        
        public DirectedProbabilityGraph(int magnitude) {
            Nodes = new List<MarkovNode>();
            Magnitude = magnitude;
        }

        public MarkovNode GetRandomNode() {
            return Nodes[Generator.Next(0, Nodes.Count)];
        }
        
        public Either<Success, Failure> AddFrom(IEnumerable<string> tokens) {
            return Status.Safely(() => {
                MarkovNode lastNode = null;
                for (int i = 0; i < tokens.Count(); i++) {
                    if (i + Magnitude > tokens.Count()) {
                        return;
                    }
                    var node = new MarkovNode(
                        tokens.Skip(i).Take(Magnitude).ToList()
                    );
                    lastNode?.AddConnection(new MarkovEdge(lastNode, node));
                    lastNode = node;
                }
            });
        }

        public Either<Success, Failure> OptimizeGraph() {
            return Status.Safely(() => {
                foreach (MarkovNode node in Nodes) {
                    Nodes.ForEach(
                        otherNode => {
                            if (otherNode != node && otherNode.Data.Equals(node.Data)) {
                                otherNode.AddConnections(node.Edges.ToArray());
                            }
                        });
                }
            });
        }

        public Either<Success, Failure> MergeGraph(DirectedProbabilityGraph graph) {
            return Status.Safely(() => {
                Nodes.AddRange(graph.Nodes);
                if (OptimizeGraph().IsFailure()) {
                    throw new Exception();
                }
            });
        }
    }
}