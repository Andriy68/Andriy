using System;

namespace Task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[15];
            int k = 0;
            int g = 1;
            int S = -1;
            int L = -1;
            Console.Write("Input size of array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    if (arr[i] == arr[j]) { g++; }
                    if (L < g)
                    {
                        L = g;
                        S = k;
                    }
                }
                k = i;
                g = 1;
            }
            Console.Write($"s={S} l={L}\n");
            Console.Write($"number is {arr[S]}");
            Console.ReadKey();
        }
    }
}
