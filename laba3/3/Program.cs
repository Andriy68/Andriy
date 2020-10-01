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

class Family
{
    People[] data;

    public void Sizer(int n)
    {
        data = new People[n];
        for (int i = 0; i < n; i++)
            data[i] = new People();
    }

    public void AddMembr(int age, string name, int i)
    {

        data[i].Age = age;
        data[i].Name = name;

    }

    public People FindMaxAge()
    {
        int max = 1, poz = 0;

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].Age > max)
            {
                max = data[i].Age;
                poz = i;
            }
        }
        return data[poz];
    }

}
class Program
{
    static void Main(string[] args)
    {
        int n;
        int rik;
        string nams;
        People max = new People();
        n = Convert.ToInt32(Console.ReadLine());

        Family a = new Family();

        a.Sizer(n);

        for (int i = 0; i < n; i++)
        {
            rik = Convert.ToInt32(Console.ReadLine());
            nams = Console.ReadLine();
            a.AddMembr(rik, nams, i);
        }

        Console.WriteLine();
        max = a.FindMaxAge();
        Console.WriteLine();
        Console.WriteLine($"{max.Age} {max.Name}");
        Console.ReadKey();

    }
}

