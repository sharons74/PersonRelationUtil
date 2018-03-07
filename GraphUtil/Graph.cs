using System;
using System.Collections.Generic;
using System.Text;

namespace GraphUtil
{

    public class Graph<T>
    {
        private Action<string> _logger = null;
                
        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges, Action<string> logger = null)
        {
            _logger = logger;

            Log("Building Graph");

            Log("Vertices:");
            foreach (var vertex in vertices)
                AddVertex(vertex);
            Log("Edges:");
            foreach (var edge in edges)
                AddEdge(edge);
        }

        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public void AddVertex(T vertex)
        {
            Log(vertex.ToString());
            AdjacencyList[vertex] = new HashSet<T>();
        }

        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                Log($"{edge.Item1} <-> {edge.Item1}");
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }

        private void Log(string msg)
        {
            _logger?.Invoke(msg);
        }

    }
}
