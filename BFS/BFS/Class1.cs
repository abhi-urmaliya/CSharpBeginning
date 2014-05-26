using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class Item
    {
        public void search(int[,] a, bool[] v, int n)
        {
            var BFSqueue = new Queue<int>();
            BFSqueue.Enqueue(0);
            v[0] = true;
            /*for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    Console.Write("{0}, ", a[i,j].ToString());
                }
            }*/
            bool flag = true;
            int k;
            while (true)
            {
                k = BFSqueue.Dequeue();
                Console.Write("{0}, ", k.ToString());
                for (int j = 0; j < n; j++)
                {
                    //Console.Write("Enqueue loop entered.\n");
                    if (a[k, j] == 1 && v[j] == false && BFSqueue.Contains(j) == false)
                    {
                        BFSqueue.Enqueue(j);
                        //Console.Write("{0} enqueued!\n", j.ToString());
                    }
                }
                v[k] = true;
                for (int i = 0; i < n; i++)
                {
                    flag &= v[i];
                    //Console.Write(flag.ToString());
                }
                if (!flag)
                {
                    continue;
                }
                else
                    break;
            }
        }
    }
}
