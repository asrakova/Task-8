using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8
{
    class Program
    {
        static bool NextPermutation(ref int[] a)
        {
            if (a.Length == 0) return false;
            for (var n = a.Length - 1; ;)
            {
                var n1 = n;
                if (a[--n] < a[n1])
                {
                    var m = a.Length;
                    while (a[n] >= a[--m]) ;
                    var t = a[n]; a[n] = a[m]; a[m] = t;
                    Array.Reverse(a, n1, a.Length - n1);
                    return true;
                }
                if (n == 0)
                {
                    Array.Reverse(a);
                    return false;
                }
            }
        }


        static void Main(string[] args)
        {
            //Console.WriteLine("Введите количество вершин графов");
            int n = 8;
            int[,] GraphA =
                { {0, 0, 0, 0, 1, 1, 1, 0 },
                  {0, 0, 0, 0, 1, 1, 0, 1 },
                  {0, 0, 0, 0, 1, 0, 1, 1 },
                  {0, 0, 0, 0, 0, 1, 1, 1 },
                  {1, 1, 1, 0, 0, 0, 0, 0 },
                  {1, 1, 0, 1, 0, 0, 0, 0 },
                  {1, 0, 1, 1, 0, 0, 0, 0 },
                  {0, 1, 1, 1, 0, 0, 0, 0 } };

            int[,] GraphB =
                { {0, 1, 0, 1, 1, 0, 0, 0 },
                  {1, 0, 1, 0, 0, 1, 0, 0 },
                  {0, 1, 0, 1, 0, 0, 1, 0 },
                  {1, 0, 1, 0, 0, 0, 0, 1 },
                  {1, 0, 0, 0, 0, 1, 0, 1 },
                  {0, 1, 0, 0, 1, 0, 1, 0 },
                  {0, 0, 1, 0, 0, 1, 0, 1 },
                  {0, 0, 0, 1, 1, 0, 1, 0 } };
            // Ввод матриц смежности
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine("Введите {0}ю строку графа А", i + 1);
            //    string[] num = Console.ReadLine().Split(' ');
            //    for (int j = 0; j < num.Length; j++)
            //        GraphA[i, j] = int.Parse(num[j]);
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine("Введите {0}ю строку графа B", i + 1);
            //    string[] num = Console.ReadLine().Split(' ');
            //    for (int j = 0; j < num.Length; j++)
            //        GraphB[i, j] = int.Parse(num[j]);
            //}

            int[,] graph = new int[n, n];


            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = i;
            bool por = false;
            while (!por)
            {
                por = true;
                bool ok = NextPermutation(ref a);
                if (!ok) break;
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        graph[i, j] = GraphB[a[i], a[j]];
                        if (graph[i, j] != GraphA[i, j]) por = false;
                    }
            }

            for (int i = 0; i < n; i++)
                Console.Write("{0} ", a[i] + 1);
            Console.ReadLine();
        }




        //    for (int k = n - 2; k >= 0; k--)
        //    {
        //        int n1 = k + 1;
        //        if (a[k] < a[n1])
        //        {
        //            int m = n - 1;
        //            while (a[k] >= a[m]) m--;
        //            int t = a[k]; a[k] = a[m]; a[m] = t;
        //            Array.Reverse(a, n1, n - n1);
        //        }
        //        if (k == 0)
        //        {
        //            Array.Reverse(a);
        //            break;
        //        }
        //    }

        //        
        //    
        //    }
    }
}
