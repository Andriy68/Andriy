using System;

public struct uchen
{
    public string name;
    public string type;
    public string pokemon;
    public int hp;
    public int budget;
    public int NofP;
}
class trener
{
    uchen[] trenerr;

    public void SizeAndAdd(string nam, string poker, string typer, int Hp, int i)
    {
        if (i == 0)
            trenerr = new uchen[i + 1];
        Array.Resize(ref trenerr, i + 1);


        trenerr[i].name = nam;
        trenerr[i].pokemon = poker;
        trenerr[i].type = typer;
        trenerr[i].hp = Hp;
        trenerr[i].budget = 0;
        trenerr[i].NofP = 1;
    }

    public void Tour(string udar)
    {

        for (int i = 0; i < trenerr.Length; i++)
        {
            if (trenerr[i].type == udar)
            {
                trenerr[i].budget++;
            }
            else
            {
                trenerr[i].hp = trenerr[i].hp - 10;
                if (trenerr[i].hp <= 0)
                {
                    trenerr[i].NofP--;
                }
            }
        }

    }
    public void ends()
    {
        for (int i = 0; i < trenerr.Length; i++)
        {
            for (int j = 0, h = 0; j < trenerr.Length; j++)
            {
                if (trenerr[i].name == trenerr[j].name && i != j)
                {
                    trenerr[i].budget = (trenerr[i].budget + trenerr[j].budget);
                    trenerr[j].budget = trenerr[i].budget;

                    trenerr[i].NofP = (trenerr[i].NofP + trenerr[j].NofP);
                    trenerr[i].NofP = trenerr[i].NofP;
                }
            }
        }
        for (int i = 0; i < trenerr.Length; i++)
        {
            Console.WriteLine(trenerr[i].name + " " + trenerr[i].budget + " " + trenerr[i].NofP);
        }

    }

}
class Prog
{
    static void Main(string[] args)
    {

        trener body = new trener();

        int i = 0;
        string comand = " ";

        while (comand != "Tournament")
        {
            comand = Console.ReadLine();

            if (comand != "Tournament")
            {


                string name = comand;
                string pok = Console.ReadLine();
                string typ = Console.ReadLine();
                int HP = Convert.ToInt32(Console.ReadLine());

                body.SizeAndAdd(name, pok, typ, HP, i);
                i++;
            }
            else
            {
                break;
            }


        }
        while (comand != "End")
        {

            comand = Console.ReadLine();

            if (comand != "End")
                body.Tour(comand);
            else
            {
                break;
            }

        }
        body.ends();

        Console.ReadLine();


    }
}

