using System;

class Koleso
{

    string[] type;
    double[] fuel;
    double[] lostFuelPerKm;
    double[] length;

    public void Size(int n)
    {
        type = new string[n];
        fuel = new double[n];
        lostFuelPerKm = new double[n];
        length = new double[n];
    }
    public void Add(string name, double fuell, double lostFuelPerKm1, int i)
    {
        type[i] = name;
        fuel[i] = fuell;
        lostFuelPerKm[i] = lostFuelPerKm1;
        length[i] = 0;
    }
    public void Ride(string name1, double len)
    {
        int i = 0;
        for (int j = 0; j < type.Length; j++)
        {
            if (type[j] == name1)
            {
                i = j;
            }
        }
        if (0 > (fuel[i] - (lostFuelPerKm[i] * len)))
        {
            Console.WriteLine("Не до бензини");

        }
        else
        {
            length[i] += len;
            fuel[i] = fuel[i] - (lostFuelPerKm[i] * len);
        }
    }
    public void Drive()
    {
        for (int i = 0; i < type.Length; i++)
        {

            if (fuel[i] < 0)
            {
                Console.WriteLine("Не до бензини");
            }
            else
            {
                Console.WriteLine($"{type[i]} {fuel[i]} {length[i]}");
            }
        }

    }
}

class Program
{
    static void Main(string[] args)
    {
        string comand = " ";
        int P;

        string name;
        double fuel, lost, lenth;

        P = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        Koleso sort = new Koleso();

        sort.Size(P);

        for (int i = 0; i < P; i++)
        {
            name = Console.ReadLine();
            fuel = Convert.ToDouble(Console.ReadLine());
            lost = Convert.ToDouble(Console.ReadLine());
            sort.Add(name, fuel, lost, i);
        }

        while (comand != "End")
        {
            comand = Console.ReadLine();
            if (comand == "Drive")
            {
                name = Console.ReadLine();
                lenth = Convert.ToDouble(Console.ReadLine());
                sort.Ride(name, lenth);
            }
        }
        sort.Drive();
        Console.ReadKey();

    }
}

