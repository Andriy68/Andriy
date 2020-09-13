using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[20];
            int[] b = new int[20];
            int[] c = new int[20];
            int g = 0;
            Console.Write("you will have array`s size (k*4)\n Input k : ");
            int k = Convert.ToInt32(Console.ReadLine());
            int n = k * 4;
            Console.WriteLine("Array : ");
            for(int i = 0; i < n; i++)
            {
                a[i]= Convert.ToInt32(Console.ReadLine());
            }
            for (int i = k-1; i >= 0; i--)
            {
                b[g]=a[i];
                g++;
            }
            for (int i = n-1; i >= 2 * k + k; i--)
            {
                b[g] = a[i];
                g++;
            }
            g = 0;
            for (int i = k; i < 2 * k + k; i++)
            {
                c[g] = a[i];
                g++;
            }

            Console.Write("Array1:");
            for (int s = 0; s < n / 2; s++)
            {
                Console.Write($"{b[s]} ");
            }
            Console.WriteLine(" ");
            Console.Write("Array2:");
            for (int s = 0; s < n / 2; s++)
            {
                Console.Write($"{c[s]} ");
            }
            Console.WriteLine(" ");

            Console.Write("Sum:");
            for (int s = 0; s < n/2; s++)
            {
                Console.Write($"{b[s]+c[s]} ");
            }
            Console.ReadKey();
        }
    }
}
