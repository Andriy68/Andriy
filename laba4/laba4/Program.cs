
using System;
using System.Collections.Generic;
using System.Linq;

public class tire
{
    private double pressure;
    private int age;

    public tire(double pressure, int age)
    {
        this.PRESSURE = pressure;
        this.age = age;
    }

    public int AGE
    {
        get { return age; }
        private set { age = value; }
    }

    public double PRESSURE
    {
        get { return pressure; }
        private set { pressure = value; }
    }
    public class Engine
    {
        private int speed;
        private int power;

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }

        public int Power
        {
            get { return power; }
            private set { power = value; }
        }

        public int Speed
        {
            get { return speed; }
            private set { speed = value; }
        }

        public class CARGO
        {
            private int weight;
            private string type;

            public CARGO(int weight, string type)
            {
                this.Weight = weight;
                this.Type = type;
            }

            public string Type
            {
                get { return type; }
                private set { type = value; }
            }

            public int Weight
            {
                get { return weight; }
                private set { weight = value; }
            }
            public class CAR
            {
                private string model;
                private Engine engine;
                private CARGO cargo;
                private List<tire> tires;

                public CAR(string model, Engine engine, CARGO cargo, List<tire> tires)
                {
                    this.Model = model;
                    this.ENGINE = engine;
                    this.Cargo = cargo;
                    this.Tires = tires;
                }

                public List<tire> Tires
                {
                    get { return tires; }
                    private set { tires = value; }
                }

                public CARGO Cargo
                {
                    get { return cargo; }
                    private set { cargo = value; }
                }

                public Engine ENGINE
                {
                    get { return engine; }
                    private set { engine = value; }
                }

                public string Model
                {
                    get { return model; }
                    private set { model = value; }
                }
                class Program
                {
                    static void Main(string[] args)
                    {
                        int count = int.Parse(Console.ReadLine());
                        List<CAR> cars = new List<CAR>();

                        for (int i = 0; i < count; i++)
                        {
                            var tokens = Console.ReadLine().Split();

                            string model = tokens[0];
                            int speed = int.Parse(tokens[1]);
                            int power = int.Parse(tokens[2]);
                            int weight = int.Parse(tokens[3]);
                            string type = tokens[4];
                            List<tire> tires = new List<tire>();

                            for (int j = 5; j < tokens.Length; j += 2)
                            {
                                double pressure = double.Parse(tokens[j]);
                                int age = int.Parse(tokens[j + 1]);

                                tires.Add(new tire(pressure, age));
                            }

                            Engine engine = new Engine(speed, power);
                            CARGO cargo = new CARGO(weight, type);

                            cars.Add(new CAR(model, engine, cargo, tires));
                        }

                        string command = Console.ReadLine();

                        if (command == "fragile")
                        {
                            cars
                                .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.PRESSURE < 1))
                                .Select(c => c.Model)
                                .ToList()
                                .ForEach(Console.WriteLine);
                        }
                        else if (command == "flamable")
                        {
                            cars
                                .Where(c => c.Cargo.Type == "flamable" && c.ENGINE.Power > 250)
                                .Select(c => c.Model)
                                .ToList()
                                .ForEach(Console.WriteLine);
                        }
                    }
                }
            }
        }
    }
}