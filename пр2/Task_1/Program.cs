using System;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0,b = 0;
            string c1 = Console.ReadLine();
            string c2 = Console.ReadLine();
     //      string[] h1 = s1.Split(' ');
            char[] arr1 = c1.ToCharArray();
            char[] arr2 = c2.ToCharArray();
            for(int i=0; i < arr1.Length; i++)
            {
                if (arr1[i] == arr2[i]) { b++; }
                else { break; }
                if (arr1[i]==' ')
                {
                    a++;
                }
            }
            if (a > 0)
            {
                Console.WriteLine($"{a} words ");
                Console.WriteLine("Comments : ");
                Console.Write("The largest common end is at the left ");
            }
            else
            {
                for (int i = arr1.Length-1; i >= 1; i--)
                {
                    for (int j = arr2.Length-1; j >= 1; j--)
                    {
                        if (arr1[i] == arr2[j]) 
                        {
                            b++;  
                            i--; 
                        }
                        else { break; }
                        if (arr1[i] == ' ') { a++; }
                    }
                    break;
                }
                if (a > 0)
                {
                    Console.WriteLine($"{a} words ");
                    Console.WriteLine("Comments : ");
                    Console.Write("The largest common end is at the right");
                }
                else
                {
                    Console.WriteLine($"{a} words ");
                    Console.WriteLine("Comments : ");
                    Console.Write("No common words at the left and right");
                }
            }
            Console.ReadKey();
        }
    }
}
