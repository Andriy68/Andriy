using System;

namespace Task_9
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alp = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            Console.Write("Input word : ");
            string arr = Console.ReadLine();
            for (int k = 0; k < arr.Length; k++)
            {
                for(int i = 0; i < 26; i++)
                {
                    if (arr[k] == alp[i])
                    {
                        Console.WriteLine($"{alp[i]} => {i}");
                    }
                }
                
            }
            Console.ReadKey();
        }
    }
}
