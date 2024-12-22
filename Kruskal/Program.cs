namespace Kruskal_s_Algorithm
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of vertices: ");
            int vertices = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the edges in the format: Source Destination Weight");
            List<Edge> edges = new List<Edge>();

            while (true)
            {
                Console.Write("Enter an edge (or type 'done' to finish): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "done")
                    break;

                string[] parts = input.Split();
                if (parts.Length == 3)
                {
                    int source = int.Parse(parts[0]);
                    int destination = int.Parse(parts[1]);
                    int weight = int.Parse(parts[2]);

                    edges.Add(new Edge
                    {
                        Source = source,
                        Destination = destination,
                        Weight = weight
                    });
                }
                else
                {
                    Console.WriteLine("Invalid input format. Please enter the edge as 'Source Destination Weight'.");
                }
            }

            var result = KruskalAlgorithm.Kruskal(vertices, edges);
            List<Edge> mst = result.mst;
            int totalWeight = result.totalWeight;

            Console.WriteLine("\nEdges in the Minimum Spanning Tree:");
            foreach (var edge in mst)
            {
                Console.WriteLine($"({edge.Source}, {edge.Destination}) - Weight: {edge.Weight}");
            }

            Console.WriteLine($"Total Weight of the MST: {totalWeight}");
        }
    }

    class Edge : IComparable<Edge>
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    class DisjointSet
    {
        private int[] parent;
        private int[] rank;

        public DisjointSet(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int Find(int u)
        {
            if (parent[u] != u)
            {
                parent[u] = Find(parent[u]); // Path compression
            }
            return parent[u];
        }

        public void Union(int u, int v)
        {
            int rootU = Find(u);
            int rootV = Find(v);

            if (rootU != rootV)
            {
                // Union by rank
                if (rank[rootU] > rank[rootV])
                {
                    parent[rootV] = rootU;
                }
                else if (rank[rootU] < rank[rootV])
                {
                    parent[rootU] = rootV;
                }
                else
                {
                    parent[rootV] = rootU;
                    rank[rootU]++;
                }
            }
        }
    }

    class KruskalAlgorithm
    {
        public static (List<Edge> mst, int totalWeight) Kruskal(int vertices, List<Edge> edges)
        {
            // Sort edges by weight
            edges.Sort();

            DisjointSet ds = new DisjointSet(vertices);
            List<Edge> mst = new List<Edge>();
            int totalWeight = 0;

            foreach (var edge in edges)
            {
                // Check if the edge forms a cycle
                if (ds.Find(edge.Source) != ds.Find(edge.Destination))
                {
                    mst.Add(edge);
                    totalWeight += edge.Weight;
                    ds.Union(edge.Source, edge.Destination);
                }

                // Stop if MST contains V-1 edges
                if (mst.Count == vertices - 1)
                    break;
            }

            return (mst, totalWeight);
        }
    }



}