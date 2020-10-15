using System;

public struct engine
{
    public string name;
    public string power;
    public string Displacement;
    public string Efficiency;
}
public struct car
{
    public string Name;
    public engine NameEng;
    public string Weight;
    public string Color;
}

class mag
{
    car[] mashin;
    engine[] eng;

    public void SizeC(int n)
    {
        mashin = new car[n];
    }
    public void SizeE(int n)
    {
        eng = new engine[n];
    }
    public void AddCar(string CarName, string EngName, string weight, string color, int i)
    {
        mashin[i].Name = CarName;

        int k = 0;
        for (int j = 0; j < eng.Length; j++)
        {
            if (eng[j].name == EngName)
            {
                k = j;
                break;
            }
        }
        mashin[i].NameEng = eng[k];

        if (weight == "")
        {
            mashin[i].Weight = "N/A";
        }
        else
        {
            mashin[i].Weight = weight;
        }

        if (color == "")
        {
            mashin[i].Color = "N/A";
        }
        else
        {
            mashin[i].Color = color;
        }
    }
    public void AddEng(string Name, string pow, string dis, string eff, int i)
    {
        eng[i].name = Name;
        if (pow == "")
        {
            eng[i].power = "N/A";
        }
        else
        {
            eng[i].power = pow;
        }

        if (dis == "")
        {
            eng[i].Displacement = "N/A";
        }
        else
        {
            eng[i].Displacement = dis;
        }

        if (eff == "")
        {
            eng[i].Efficiency = "N/A";
        }
        else
        {
            eng[i].Efficiency = eff;
        }

    }
    public void PrintArr()
    {
        for (int i = 0; i < mashin.Length; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {mashin[i].Name} \n Engine: \n Eng Name: {mashin[i].NameEng.name} \n Eng power: {mashin[i].NameEng.power} \n Eng Dis: {mashin[i].NameEng.Displacement} \n Eff Eng: {mashin[i].NameEng.Efficiency} \n Car Weight: {mashin[i].Weight} \n Car Color: {mashin[i].Color}");
            Console.WriteLine();
        }
    }

}


class Program
{
    static void Main(string[] args)
    {
        int N, M;

        mag php = new mag();

        Console.WriteLine("Input Size of eng");
        N = Convert.ToInt32(Console.ReadLine());
        php.SizeE(N);

        for (int i = 0; i < N; i++)
        {
            string nname;
            string ppower;
            string dis;
            string eff;

            nname = Console.ReadLine();
            ppower = Console.ReadLine();
            dis = Console.ReadLine();
            eff = Console.ReadLine();

            php.AddEng(nname, ppower, dis, eff, i);
            Console.WriteLine();
        }
        Console.WriteLine("Input Size of car");
        M = Convert.ToInt32(Console.ReadLine());
        php.SizeC
            
            (M);

        for (int i = 0; i < M; i++)
        {
            string ccarName;
            string eengName;
            string wweight;
            string ccolor;

            ccarName = Console.ReadLine();
            eengName = Console.ReadLine();
            wweight = Console.ReadLine();
            ccolor = Console.ReadLine();

            Console.WriteLine();

            php.AddCar(ccarName, eengName, wweight, ccolor, i);
        }

        Console.WriteLine();

        php.PrintArr();

        Console.ReadLine();

    }
}

