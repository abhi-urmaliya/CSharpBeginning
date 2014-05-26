using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] G = new int[5, 5];
            for (int i = 0; i < 5; i++) {
                for (int j = i; j < 5; j++) {
                    G[i, j] = G[j, i] = int.Parse(Console.ReadLine());
                }
            }
            var visited = new bool[5];
            for (int i = 0; i < 5; i++) {
                visited[i] = false;
            }
            var s = new Item();
            s.search(G, visited, 5);
        }
    }
}
