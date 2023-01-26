using GrokkingAlgorithms.Chapter_1;
using GrokkingAlgorithms.Chapter_2;
using GrokkingAlgorithms.Chapter_3;
using GrokkingAlgorithms.Chapter_4;
using GrokkingAlgorithms.Chapter_5;
using GrokkingAlgorithms.Chapter_6;
using GrokkingAlgorithms.Chapter_8;
using GrokkingAlgorithms.Chapter_9;
using GrokkingAlgorithms.Chapter_10;
using System.Diagnostics;

namespace GrokkingAlgorithms;
internal class Program 
{
    static void Main(string[] args)
    {
        MapPoint<int> p = new MapPoint<int>(new int[2] { 16, 90 }, 5);
        MapPoint<int> q = new MapPoint<int>(new int[2] { 18, 100 }, 4);
        MapPoint<int> r = new MapPoint<int>(new int[2] { 26, 120 });
        MapPoint<int> s = new MapPoint<int>(new int[2] { 51, 180 }, 2);
        MapPoint<int>[] arr = new MapPoint<int>[4] { p, q, r, s };

        kNN<int> knn = new kNN<int>(2);
        Console.WriteLine(knn.Predict(arr, r));
        Console.ReadKey();
    }
    private static void ShowVertexes(Graph<string> graph, Vertex<string> v3)
    {
        List<Vertex<string>> neighborsV3 = graph.GetVertexList(v3);
        Console.Write(String.Concat(v3, ": "));
        Console.WriteLine(string.Join(", ", neighborsV3));
    }

    private static void ShowMatrix(Graph<string> graph)
    {
        int[,] matrix = graph.GetMatrix();
        for (int i = 0; i < graph.VCount; i++)
        {
            Console.Write(i + 1);
            for (int j = 0; j < graph.VCount; j++)
            {
                Console.Write(" | " + matrix[i, j] + " | ");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < graph.VCount * 7; i++)
            Console.Write("-");
        Console.WriteLine();
        Console.Write(" ");
        for (int i = 0; i < graph.VCount; i++)
        {
            Console.Write(" | " + (i + 1) + " | ");
        }
    }
}