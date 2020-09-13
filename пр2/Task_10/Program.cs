using System;

namespace Task_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[7];
            int h = 0;
            Console.Write("Input size of array : ");
            int g = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < g; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Input difference : ");
            int d = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < g; i++)
            {
                for (int j = i+1; j < g ; j++)
                { 
                    if (arr[i]+d==arr[j] || arr[i] - d == arr[j] )
                    {
                        h++;
                    }
                }
                
            }
            Console.WriteLine(h);
            Console.ReadKey();
        }
    }
}
