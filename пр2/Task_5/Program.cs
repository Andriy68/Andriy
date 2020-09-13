using System;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool v =true;
            char[] a1 = new char[10];
            char[] a2 = new char[10];
            Console.Write("Input size of first array : ");
            int d1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input size of second array : ");
            int d2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Array1 : ");
            for(int i = 0; i < d1; i++)
            {
                a1[i] = Convert.ToChar(Console.ReadLine());
            }
            Console.WriteLine("Array2 : ");
            for (int i = 0; i < d2; i++)
            {
                a2[i] = Convert.ToChar(Console.ReadLine());
            }

            for(int i = 0; i < d1; i++)
            {
                for(int j = 0; j < d2; j++)
                {     
                    if (a1[i] == a2[j])
                    {
                        if (i == d1 - 1 || j == d2 - 1) 
                        { 
                            if(d1 < d2) { v = true; }
                            else { v = false; }
                            break; 
                        }
                        else { i++; }
                    }
                    else
                    {
                        if (a1[i] < a2[j]) { v = true; }
                        else { v = false; }
                    }          
                }
                break;
            }
            if (v == true)
            {
                for (int i = 0; i < d1; i++)
                {
                    Console.Write(a1[i]);
                }
                Console.WriteLine(" ");
                for (int i = 0; i < d2; i++)
                {
                    Console.Write(a2[i]);
                }
            }
            else
            {
                for (int i = 0; i < d2; i++)
                {
                    Console.Write(a2[i]);
                }
                Console.WriteLine(" ");
                for (int i = 0; i < d1; i++)
                {
                    Console.Write(a1[i]);
                }
            }
            Console.ReadKey();
        }
    }
}
