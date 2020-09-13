using System;

    class Program
    {
        static void Main(string[] args)
        {
        float a, b, c;
        a = float.Parse(Console.ReadLine());
        b = float.Parse(Console.ReadLine());
        c = float.Parse(Console.ReadLine());
        float avrg = ((a + b)/2) *c ;
        Math.Round(avrg, 1);

        Console.WriteLine(avrg);
        Console.ReadKey();
        }
    }

