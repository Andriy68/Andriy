using System;

    class Program
    {
        static void Main(string[] args)
        {
        bool result;
        int a;
        a = int.Parse(Console.ReadLine());

            if((a%  9)==0|| (a % 11) == 0|| (a % 13) == 0)
            {
            result = true;
            }
            else
            {
            result = false;
            }

        Console.WriteLine(result);
        Console.ReadKey();

        }
    }

