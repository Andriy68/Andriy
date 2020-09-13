using System;

    class Program
    {
        static void Main(string[] args)
        {
        int a, digit, num;
        
        
        num = int.Parse(Console.ReadLine());
        a = int.Parse(Console.ReadLine());

        digit = (int)(num / (Math.Pow(10 , (a-1)))) % 10;

        if (digit == 0)
        {
            Console.WriteLine("-");
        }
        else
        {
            Console.WriteLine(digit);
        }

        Console.ReadLine();
    }
    }

