using System;

namespace task_15
{
    class Tool : Kvadrat
    {
        public int Horizontal { get; set; }
        public int Vertical { get; set; }

        public Tool(int a, int b)
        {
            Horizontal = a;
            Vertical = b;
        }
        public override void Mal()
        {
            for (int i = 0; i < Vertical; i++)
            {
                Console.Write("|");
                for (int j = 0; j < Horizontal; j++)
                {
                    if (i == 0 || i == Vertical - 1)
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("|\n");
            }
        }
    }
    abstract class Kvadrat
    {
        abstract public void Mal();
    }
    class Prog
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            if (s1 == "Square")
            {
                int a = Convert.ToInt32(Console.ReadLine());
                Tool figure = new Tool(a, a);
                figure.Mal();
            }
            else
            {
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                Tool figure = new Tool(a, b);
                figure.Mal();
            }
        }
    }
}
