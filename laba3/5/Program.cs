using System;
using System.Text;

class DateModifier
{
    public int DateMod(char[] date1, char[] date2)
    {
        StringBuilder a11 = new StringBuilder("00"); StringBuilder b11 = new StringBuilder("00"); StringBuilder c11 = new StringBuilder("0000");
        StringBuilder a22 = new StringBuilder("00"); StringBuilder b22 = new StringBuilder("00"); StringBuilder c22 = new StringBuilder("0000");

        string a111; string b111; string c111;
        string a222; string b222; string c222;

        int diff, days1, days2;

        int a1, a2;
        int b1, b2;
        int c1, c2;

        for (int i = 0; i < 4; i++)
        {
            c11[i] = date1[i];
        }
        for (int i = 0; i < 4; i++)
        {
            c22[i] = date2[i];
        }

        for (int i = 5, j = 0; i < 7; i++, j++)
        {
            b11[j] = date1[i];
        }
        for (int i = 5, j = 0; i < 7; i++, j++)
        {
            b22[j] = date2[i];
        }

        for (int i = 8, j = 0; i < 10; i++, j++)
        {
            a11[j] = date1[i];
        }
        for (int i = 8, j = 0; i < 10; i++, j++)
        {
            a22[j] = date2[i];
        }

        a111 = Convert.ToString(a11);
        a222 = Convert.ToString(a22);

        b111 = Convert.ToString(b11);
        b222 = Convert.ToString(b22);

        c111 = Convert.ToString(c11);
        c222 = Convert.ToString(c22);

        a1 = Convert.ToInt32(a111); b1 = Convert.ToInt32(b111); c1 = Convert.ToInt32(c111);
        a2 = Convert.ToInt32(a222); b2 = Convert.ToInt32(b222); c2 = Convert.ToInt32(c222);

        days1 = (c1 * 365) + (c1 / 4);
        days2 = (c2 * 365) + (c2 / 4);

        for (int i = 1; i <= b1; i++)
        {
            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
            {
                days1 += 31;
            }
            if (i == 4 || i == 6 || i == 9 || i == 11)
            {
                days1 += 30;
            }
            if (i == 2)
            {
                days1 += 28;
            }
        }

        for (int i = 1; i <= b2; i++)
        {
            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
            {
                days2 += 31;
            }
            if (i == 4 || i == 6 || i == 9 || i == 11)
            {
                days2 += 30;
            }
            if (i == 2)
            {
                days2 += 28;
            }
        }
        days1 += a1;
        days2 += a2;

        diff = days1 - days2;
        return diff;
    }
}

class Program
{
    static void Main(string[] args)
    {
        char[] your1 = new char[10];
        char[] your2 = new char[10];

        string a, b;

        for (int i = 0; i < 10; i++)
        {
            your1[i] = Console.ReadKey().KeyChar;
        }
        Console.WriteLine();
        for (int i = 0; i < 10; i++)
        {
            your2[i] = Console.ReadKey().KeyChar;
        }

        a = Convert.ToString(your1);
        b = Convert.ToString(your2);

        DateModifier rizn = new DateModifier();

        Console.WriteLine();
        Console.WriteLine(rizn.DateMod(your1, your2));
        Console.ReadKey();


    }
}

