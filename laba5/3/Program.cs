using System;
using System.Collections.Generic;
using System.Text;

namespace task_3
{
    class Chicken
    {
        private string name;
        private int age;
        public int ProductPerDay { get => CalculateProductPerDay(); }
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "" || value == " ")
                {
                    throw new Exception("Name cannot be empty");
                }
                else
                {
                    name = value;
                }
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 15)
                {
                    throw new Exception("Age should be between 0 and 15.");
                }
                else
                {
                    age = value;
                }
            }
        }
        public Chicken(string n, int a)
        {
            Name = n;
            Age = a;
        }
        private int CalculateProductPerDay()
        {
            return 1;
        }
        public void Output()
        {
            Console.WriteLine($"Chicken {Name} (age {Age}) can produce {ProductPerDay} eggs per day");
        }
    }
}

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            try
            {
                Chicken chicken = new Chicken(n, a);
                chicken.Output();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
