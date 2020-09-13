using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, g, r=0;
            int[] a = new int[20];
            int[] sum= new int [20];
            Console.WriteLine("Input size of array : ");
            n = Convert.ToInt32(Console.ReadLine());
            for (int j = 0; j < n; j++)
            {
                sum[j] = 0;
            }
            Console.WriteLine("Input number of rotates : ");
            g = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Now you must input all elements of array:");
            for (int i = 0; i < n; i++)
            {
                a[i]= Convert.ToInt32(Console.ReadLine());
            }
            for (r = 1; r <= g; r++)
            {
                for(int i = 0; i < n; i++)
                {
                    sum[(i + r) % n] += a[i];
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{sum[i]} ");
            }
            Console.ReadKey();
        }
    }
}
