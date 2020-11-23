using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace _04_FileConverter
{
    public class GraphFileConverter
    {
        int v; // Number of sides of the graph

        // Adjacency list for storing which vertices are connected
        List<List<int>> adj;

        public GraphFileConverter(byte[,] adjacencyMatrix)
        {
            this.v = Convert.ToInt32(Math.Sqrt(adjacencyMatrix.Length));
            adj = new List<List<int>>(v);
            for (int i = 0; i < this.v; i++)
            {
                adj.Add(new List<int>());
            }

            for (int k = 0; k < v; k++)
            {
                for (int l = 0; l < v; l++)
                {
                    if (adjacencyMatrix[k,l] == 1)
                    {
                        addEdge(adj, k, l);
                    }
                }
            }
        }

        public void addEdge(List<List<int>> adj, int i, int j)
        {
            adj[i].Add(j);

        }

        // function to print the shortest distance and path
        // between source vertex and destination vertex
        public LinkedList<int> getShortestPath(int s, int dest)
        {
            // LinkedList to store path
            LinkedList<int> path = new LinkedList<int>();

            // predecessor[i] array stores predecessor of
            // i and distance array stores distance of i
            // from s
            int[] pred = new int[v];
            int[] dist = new int[v];

            if (BFS(s, dest, pred, dist) == false)
            {
                Console.WriteLine("Given source and destination" +
                        "are not connected");
                return path;
            }
            int crawl = dest;
            path.AddLast(crawl);
            while (pred[crawl] != -1)
            {
                path.AddLast(pred[crawl]);
                crawl = pred[crawl];
            }

            // Print distance
            Console.WriteLine("Shortest path length is: " + dist[dest]);

            // Print path
            Console.WriteLine("Path is ::");
            for (int i = path.Count - 1; i >= 0; i--)
            {
                Console.Write(path.ElementAt(i) + " ");
            }
            return path;
        }

        // a modified version of BFS that stores predecessor
        // of each vertex in array pred
        // and its distance from source in array dist
        public bool BFS(int src, int dest, int[] pred, int[] dist)
        {
            // a queue to maintain queue of vertices whose
            // adjacency list is to be scanned as per normal
            // BFS algorithm using LinkedList of Integer type
            LinkedList<int> queue = new LinkedList<int>();

            // boolean array visited[] which stores the
            // information whether ith vertex is reached
            // at least once in the Breadth first search
            bool[] visited = new bool[v];

            // initially all vertices are unvisited
            // so v[i] for all i is false
            // and as no path is yet constructed
            // dist[i] for all i set to infinity
            for (int i = 0; i < v; i++)
            {
                visited[i] = false;
                dist[i] = int.MaxValue;
                pred[i] = -1;
            }

            // now source is first to be visited and
            // distance from source to itself should be 0
            visited[src] = true;
            dist[src] = 0;
            queue.AddLast(src);

            // bfs Algorithm
            while (queue.Count != 0)
            {
                int u = queue.Last(); // TODO BAŞTAKİ ÇIKMALI kuyruktan
                queue.RemoveLast(); //TODO!!! KUYRUKTAN BAŞTAN MI ELEMENA ÇIKARILACAK SONDAN MI !!!

                for (int i = 0; i < adj[u].Count; i++)
                {
                    if (visited[adj[u][i]] == false)
                    {
                        visited[adj[u][i]] = true;
                        dist[adj[u][i]] = dist[u] + 1;
                        pred[adj[u][i]] = u;
                        queue.AddLast(adj[u][i]); 

                        // stopping condition (when we find
                        // our destination)
                        if (adj[u][i] == dest)
                            return true;
                    }
                }
            }
            return false;
        }

    }
}

    
