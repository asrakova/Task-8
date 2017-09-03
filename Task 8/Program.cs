using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8
{
    class Program
    {
        static void GeneratorTests(out int[,] GraphA, out int[,] GraphB, out int n)
        {
            Random a = new Random();
            n = a.Next(2, 11);
            GraphA = new int[n, n];
            Console.WriteLine("Граф А:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        GraphA[i, j] = 0;
                    else if (i < j)
                        GraphA[i, j] = a.Next(2);
                    else GraphA[i, j] = GraphA[j, i];
                    Console.Write("{0} ", GraphA[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Граф B:");
            GraphB = new int[n, n];
            int[] peak = new int[n];
            for (int i = 0; i < n; i++)
                peak[i] = -1;
            for (int i = 0; i < n; i++)
                while (true)
                {
                    int place = a.Next(n);
                    if (peak[place] == -1)
                    {
                        peak[place] = i;
                        break;
                    }
                }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    GraphB[i, j] = GraphA[peak[i], peak[j]];
                    Console.Write("{0} ", GraphB[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Ожидаемый результат:");
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", peak[i] + 1);
            Console.WriteLine();
        }




        static bool NextPermutation(ref int[] a)
        {
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
            int[,] GraphA, GraphB;
            int n;
            GeneratorTests(out GraphA, out GraphB, out n);
            int[,] graph = new int[n, n];

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = i;

            bool por = false;
            while (!por)
            {
                por = true;
                bool ok = NextPermutation(ref a);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        graph[i, j] = GraphB[a[i], a[j]];
                        if (graph[i, j] != GraphA[i, j]) por = false;
                    }
            }

            for (int i = 0; i < n; i++)
                Console.Write("{0} ", a[i] + 1);
            Console.WriteLine();

            Console.WriteLine("Измененный граф: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0} ", graph[i, j]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
