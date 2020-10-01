using System;

class People
{
    private string name;
    private int age;

    public string Name
    {
        set
        {
            name = value;
        }
        get
        {
            return name;
        }
    }
    public int Age
    {
        set
        {

            if (value > 0)
                age = value;
        }
        get
        {
            return age;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        People a = new People();
        People b = new People();
        People c = new People();

        Console.WriteLine("Імя і Вік");
        a.Name = Console.ReadLine();
        a.Age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Імя і Вік");
        b.Name = Console.ReadLine();
        b.Age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Імя і Вік");
        c.Name = Console.ReadLine();
        c.Age = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine($"Имя : {a.Name} Вик : {a.Age}");
        Console.WriteLine($"Имя : {b.Name} Вик : {b.Age}");
        Console.WriteLine($"Имя : {c.Name} Вик : {c.Age}");

        Console.ReadKey();

    }
}
