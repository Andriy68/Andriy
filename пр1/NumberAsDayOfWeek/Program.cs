using System;

    class Program
    {
        static void Main(string[] args)
        {
        int  b, a;
        double j ;
        a = (int)double.Parse(Console.ReadLine());

        b = a % 7;
        if (b == 1)
        {
            Console.WriteLine("Monday");
        }
        if (b == 2)
        {
            Console.WriteLine("Tuesday");
        }
        if (b == 3)
        {
            Console.WriteLine("Wednes­day");
        }
        if (b == 4)
        {
            Console.WriteLine("Thursday");
        }
        if (b == 5)
        {
            Console.WriteLine("Friday");
        }
        if (b == 6)
        {
            Console.WriteLine("Saturday");
        }
        if (b == 7)
        {
            Console.WriteLine("Sunday");
        }
        if (b <= 0)
        {
            Console.WriteLine("Not Valid");
        }
        j = b % 1;
        if (j != 0)
        {
            Console.WriteLine("Not Valid");
        }
        Console.ReadKey();


    }
    }

