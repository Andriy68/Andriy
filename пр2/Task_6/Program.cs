using System;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[15];
            int j = 0;
            int g = 1;
            int S=-1;
            int L=-1;
            Console.Write("Input size of array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 1; i < n; i++)
            {
                if (arr[i] == arr[j]) { g++; }
                else { 
                    j = i;
                    g = 1;
                }
                if (L < g) { 
                    L = g; 
                    S = j;
                }
            }
            Console.Write($"s={S} l={L} arr[s]={arr[S]}\n");
            for (int i = S; i < S + L; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.ReadKey();
        }
    }
}
