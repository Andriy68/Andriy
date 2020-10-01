using System;

class Ros
{
    string[] name;
    double[] pay;
    string[] posada;
    string[] viddil;
    string[] email;
    string[] age;

    string[] sorted;
    double[] sum;
    string[] vid;


    public void Size(int N)
    {
        name = new string[N];
        pay = new double[N];
        posada = new string[N];
        viddil = new string[N];
        email = new string[N];
        age = new string[N];
    }


    public void Add(string name1, double pay1, string posada1, string viddil1, string email1, string age1, int poz)
    {
        name[poz] = name1;
        pay[poz] = pay1;
        posada[poz] = posada1;
        viddil[poz] = viddil1;

        email[poz] = email1;
        if (email[poz] == "")
        {
            email[poz] = "n/a";
        }

        age[poz] = age1;
        if (age[poz] == "")
        {
            age[poz] = "-1";
        }
    }

    public void Sort()
    {
        int j = 0;
        for (int i = 0; i < name.Length - 1; i++)
        {
            if (viddil[i] == viddil[i + 1])
            {
                continue;
            }
            else
            {
                j++;
            }
        }
        vid = new string[j];

        for (int i = 0, k = 0; i < name.Length - 1 && k < vid.Length; i++)
        {
            if (i == 0)
            {
                vid[k] = viddil[i];
                continue;
            }
            if (viddil[i] == viddil[i + 1])
            {
                continue;
            }
            else
            {
                k++;
                vid[k] = viddil[i];
            }
        }

        sum = new double[vid.Length];

        for (int i = 0; i < vid.Length; i++)
        {
            for (int p = 0; p < viddil.Length; p++)
            {
                if (vid[i] == viddil[p])
                {
                    sum[i] += pay[p];
                }
            }
        }



    }


    public void Make()
    {
        int max_ind = 0;
        double max = 0;

        for (int i = 0; i < sum.Length; i++)
        {
            if (sum[i] > max)
            {
                max = sum[i];
                max_ind = i;
            }
        }
        Console.WriteLine($"Max sqad {viddil[max_ind]} sum {max}");
        for (int i = 0; i < viddil.Length; i++)
        {
            if (viddil[i] == vid[max_ind])
            {
                Console.WriteLine($"{name[i]} {pay[i]} {posada[i]} {viddil[i]} {email[i]} {age[i]}");
            }
        }

    }
}
class Program
{
    static void Main(string[] args)
    {
        int P;

        string[] name;
        double[] pay;
        string[] posada;
        string[] viddil;
        string[] email;
        string[] age;

        Ros sort = new Ros();

        Console.WriteLine("Input N size: ");
        P = Convert.ToInt32(Console.ReadLine());

        sort.Size(P);

        name = new string[P];
        pay = new double[P];
        posada = new string[P];
        viddil = new string[P];
        email = new string[P];
        age = new string[P];


        Console.WriteLine("");

        for (int i = 0; i < P; i++)
        {
            name[i] = Console.ReadLine();
            pay[i] = Convert.ToDouble(Console.ReadLine());
            posada[i] = Console.ReadLine();
            viddil[i] = Console.ReadLine();
            email[i] = Console.ReadLine();
            age[i] = Console.ReadLine();

            sort.Add(name[i], pay[i], posada[i], viddil[i], email[i], age[i], i);
            Console.WriteLine("");
        }

        sort.Sort();
        sort.Make();

        Console.ReadKey();


    }
}

