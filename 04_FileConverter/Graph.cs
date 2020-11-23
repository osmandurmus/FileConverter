// C# program to print BFS traversal  
// from a given source vertex.  
// BFS(int s) traverses vertices  
// reachable from s.  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_FileConverter
{
    // This class represents a directed  graph using adjacency list representation  
    class Graph
    {

        // No. of vertices      
        private int _V;

        //Adjacency Lists  
        LinkedList<int>[] _adj;

        public Graph(int V)
        {
            _adj = new LinkedList<int>[V];
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new LinkedList<int>();
            }
            _V = V;
        }

        // Function to add an edge into the graph  
        public void AddEdge(int v, int w)
        {
            _adj[v].AddLast(w);

        }

        // Prints BFS traversal from a given source s  
        public List<int> BFS(int s, int destination)
        {
            // It keeps the shortest path.
            List<int> path = new List<int>();

            // Mark all the vertices as not visited(By default set as false)  
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;

            // Create a queue for BFS  
            LinkedList<int> queue = new LinkedList<int>();

            // Mark the current node as visited and enqueue it  
            visited[s] = true;
            queue.AddLast(s);

            while (queue.Any())
            {

                // Dequeue a vertex from queue and print it 
                s = queue.First();
                Console.Write(s + " ");
                queue.RemoveFirst();
                path.Add(s);

                // Get all adjacent vertices of the  
                // dequeued vertex s. If a adjacent 
                // has not been visited, then mark it  
                // visited and enqueue it  
                LinkedList<int> list = _adj[s];

                // If our destination is equal to our source, return the shortest path.
                if (s == destination) // && path.Count>1 can add at a supplement 
                    return path;


                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }

            return null;
        }
    }
}
