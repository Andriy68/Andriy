using System;

    class Program
    {
        static void Main(string[] args)
        {
        int a;
        Boolean result;

        a = int.Parse(Console.ReadLine());

        if (a > 20 && (a % 10) == 1)
        {
            result = true;
            Console.WriteLine(result);
        }
        else
        {
            result = false;
            Console.WriteLine(result);
        }
        Console.ReadKey();
        }
    }

