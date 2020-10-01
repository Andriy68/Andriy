using System;

class People
{
    private int age = 1;
    private string name = "NoName";

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
        int N, j = 0;
        People[] mas;
        People temp = new People();
        N = Convert.ToInt32(Console.ReadLine());
        mas = new People[N];
        for (int i = 0; i < N; i++)
        {

            mas[i] = new People();
            mas[i].Name = Console.ReadLine();
            mas[i].Age = Convert.ToInt32(Console.ReadLine());
            if (mas[i].Age > 30)
            {
                j++;
            }

        }
        People[] sorted = new People[j];

        for (int i = 0, k = 0; i < N; i++)
        {
            if (mas[i].Age > 30)
            {
                sorted[k] = new People();
                sorted[k] = mas[i];
                k++;
            }
        }

        for (int i = 0; i < j; i++)
        {
            for (int h = 0; h < j; h++)
            {
                if (sorted[i].Name[0] < sorted[h].Name[0])
                {
                    temp = sorted[i];
                    sorted[i] = sorted[h];
                    sorted[h] = temp;
                }
            }
        }

        for (int i = 0; i < j; i++)
        {
            Console.WriteLine($"Name: {sorted[i].Name} Age: {sorted[i].Age}");
        }

        Console.ReadKey();

    }
}

