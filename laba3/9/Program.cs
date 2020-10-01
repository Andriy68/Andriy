using System;

struct UP
{
    public string name;
    public int len;
    public int hig;
    public int x;
    public int y;
}
class Figur
{
    public UP figura;

    public void Add(string name1, int len11, int hig11, int x, int y)
    {
        figura.name = name1;
        figura.len = len11;
        figura.hig = hig11;
        figura.x = x;
        figura.y = y;
    }

    public bool Down(Figur druge1, Figur druge2)
    {
        if (((Math.Max(druge1.figura.x, druge2.figura.x) - Math.Min(druge1.figura.x, druge2.figura.x) <= Math.Min(druge1.figura.len, druge2.figura.len) && ((Math.Max(druge1.figura.y, druge2.figura.y) - Math.Min(druge1.figura.y, druge2.figura.y) <= Math.Min(druge1.figura.hig, druge2.figura.hig))))))
        {

            return true;
        }


        return false;
    }

}
class Program
{
    static void Main(string[] args)
    {

        int N, NN;

        int len1, hig1, x, y;

        string name;

        string nam1, nam2;

        Figur[] drug;
        N = Convert.ToInt32(Console.ReadLine());
        NN = Convert.ToInt32(Console.ReadLine());

        drug = new Figur[N];

        for (int i = 0; i < N; i++)
        {
            name = Console.ReadLine();
            len1 = Convert.ToInt32(Console.ReadLine());
            hig1 = Convert.ToInt32(Console.ReadLine());
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());

            drug[i] = new Figur();
            drug[i].Add(name, len1, hig1, x, y);

        }

        for (int i = 0; i < NN; i++)
        {
            nam1 = Console.ReadLine();
            nam2 = Console.ReadLine();

            for (int j = 0; j < N; j++)
            {
                for (int f = 0; f < N; f++)
                {
                    if (nam1 == drug[j].figura.name && nam2 == drug[f].figura.name)
                    {
                        Console.WriteLine(drug[i].Down(drug[j], drug[f]));
                    }
                }
            }

        }

        Console.ReadKey();

    }
}

