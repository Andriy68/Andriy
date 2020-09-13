using System;

    class Program
    {
        static void Main(string[] args)
        {

        int faktorial=1 , n;
        n = int.Parse(Console.ReadLine());

        for(int i=2; i<=n; i++)
        {
            faktorial = faktorial * i;
        }
        Console.WriteLine(faktorial);
        Console.ReadKey();
        }
    }

