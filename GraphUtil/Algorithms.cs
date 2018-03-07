using System;
using System.Collections.Generic;

namespace GraphUtil
{
    public class Algorithms
    {
        private Action<string> _logger = null;

        public Algorithms(Action<string> logger = null)
        {
            _logger = logger;
        }

        public T[] BFS<T>(Graph<T> graph, T start,T target,Func<T,T,bool> matchCriteria)
        {
            Log($"start: {start}");
            Log($"target: {target}");
           

            Dictionary<T, T> origin = new Dictionary<T, T>(); // store the node we came from for each node examined
           
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return null;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                var parent = origin.ContainsKey(vertex) ? origin[vertex] : default(T);
                Log($"checking: {vertex} , parent is {parent}");


                if (visited.Contains(vertex))
                {
                    Log("already visited");
                    continue;
                }

                if (matchCriteria(vertex, target))
                {
                    //target found
                    //build the path from start to target
                    Log("Path:");
                    var node = target;
                    Log(node.ToString());
                    Stack<T> path = new Stack<T>();
                    path.Push(target);
                    while (origin.ContainsKey(node) && !matchCriteria(origin[node], node))
                    {
                        node = origin[node];
                        path.Push(node);
                        Log(node.ToString());
                    }
                    return path.ToArray();
                    
                }

                Log("adding to visited");
                visited.Add(vertex);
                Log("Fetching children...");
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        Log($"fetch {neighbor}");
                        queue.Enqueue(neighbor);
                        if (!origin.ContainsKey(neighbor))
                        {
                            Log($"setting {vertex} as parent of {neighbor}");
                            origin[neighbor] = vertex;
                        }
                    }
                }                
            }

            return null; // found no path
        }

        private void Log(string msg)
        {
            _logger?.Invoke(msg);
        }
    }
}
