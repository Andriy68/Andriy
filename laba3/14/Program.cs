using System;
using System.Collections.Generic;

class Cat
{
    public string name = "";

}
class Sya : Cat
{
    public double earSize = 0;

    public override string ToString()
    {
        return Convert.ToString(earSize);
    }
}
class Cya : Cat
{
    public double furSize = 0;

    public override string ToString()
    {
        return Convert.ToString(furSize);
    }
}
class Extra : Cat
{
    public int meavPow = 0;

    public override string ToString()
    {
        return Convert.ToString(meavPow);
    }
}
class Prog
{
    static void Main(string[] args)
    {

        List<Cat> cats = new List<Cat>();

        string comand = "";

        while (comand != "End")

        {
            comand = Console.ReadLine();
            if (comand == "End")
            {
                break;
            }

            if (comand == "Siamese")
            {
                Sya time1 = new Sya();
                time1.name = Console.ReadLine();
                time1.earSize = Convert.ToDouble(Console.ReadLine());
                cats.Add(time1);
            }
            if (comand == "Cymric")
            {
                Cya time2 = new Cya();
                time2.name = Console.ReadLine();
                time2.furSize = Convert.ToDouble(Console.ReadLine());
                cats.Add(time2);
            }
            if (comand == "StreetExtraordinaire")
            {
                Extra time3 = new Extra();
                time3.name = Console.ReadLine();
                time3.meavPow = Convert.ToInt32(Console.ReadLine());
                cats.Add(time3);
            }
        }
        Console.WriteLine("Wats Cat Name:");
        comand = Console.ReadLine();

        for (int i = 0; i < cats.Count; i++)
        {
            if (cats[i].name == comand)
            {

                Console.WriteLine($"{cats[i].GetType()} {cats[i].name} {cats[i].ToString()}");
            }

        }
        Console.ReadLine();








    }
}

