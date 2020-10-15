using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ENGINE
{
    private string model;
    private int power;
    private int? displacement;
    private string efficiency;

    public ENGINE(string model, int power)
    {
        this.Model = model;
        this.power = power;
    }

    public ENGINE(string model, int power, int? displacement)
        : this(model, power)
    {
        this.displacement = displacement;
    }

    public ENGINE(string model, int power, string efficiency)
        : this(model, power)
    {
        this.efficiency = efficiency;
    }

    public ENGINE(string model, int power, int? displacement, string efficiency)
        : this(model, power)
    {
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public string Model
    {
        get { return model; }
        private set { model = value; }
    }


    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"  {Model}:");
        builder.AppendLine($"    Power: {power}");
        builder.AppendLine($"    Displacement: {(displacement == null ? "n/a" : displacement.ToString())}");
        builder.AppendLine($"    Efficiency: {(efficiency == null ? "n/a" : efficiency.ToString())}");

        return builder.ToString();
    }
}
public class CAR
{
    private string model;
    private ENGINE engine;
    private int? weight;
    private string color;

    public CAR(string model, ENGINE engine)
    {
        this.model = model;
        this.engine = engine;
    }

    public CAR(string model, ENGINE engine, int? weight)
        : this(model, engine)
    {
        this.weight = weight;
    }

    public CAR(string model, ENGINE engine, string color)
        : this(model, engine)
    {
        this.color = color;
    }

    public CAR(string model, ENGINE engine, int? weight, string color)
        : this(model, engine)
    {
        this.weight = weight;
        this.color = color;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"{model}:");
        builder.Append(engine);
        builder.AppendLine($"  Weight: {(weight == null ? "n/a" : weight.ToString())}");
        builder.Append($"  Color: {(color == null ? "n/a" : color)}");

        return builder.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<ENGINE> engines = new List<ENGINE>();
        List<CAR> cars = new List<CAR>();

        for (int i = 0; i < count; i++)
        {
            var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string model = tokens[0];
            int power = int.Parse(tokens[1]);

            if (tokens.Length == 2)
            {
                engines.Add(new ENGINE(model, power));
            }
            else if (tokens.Length == 3)
            {
                if (tokens[2].All(Char.IsDigit))
                {
                    int displacement = int.Parse(tokens[2]);
                    engines.Add(new ENGINE(model, power, displacement));
                }
                else
                {
                    string efficiency = tokens[2];
                    engines.Add(new ENGINE(model, power, efficiency));
                }
            }
            else if (tokens.Length == 4)
            {
                int displacement = int.Parse(tokens[2]);
                string efficiency = tokens[3];

                engines.Add(new ENGINE(model, power, displacement, efficiency));
            }
        }

        count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = tokens[0];
            ENGINE engine = engines.First(e => e.Model == tokens[1]);

            if (tokens.Length == 2)
            {
                cars.Add(new CAR(model, engine));
            }
            else if (tokens.Length == 3)
            {
                if (tokens[2].All(Char.IsDigit))
                {
                    int weight = int.Parse(tokens[2]);

                    cars.Add(new CAR(model, engine, weight));
                }
                else
                {
                    string color = tokens[2];

                    cars.Add(new CAR(model, engine, color));
                }
            }
            else if (tokens.Length == 4)
            {
                int weight = int.Parse(tokens[2]);
                string color = tokens[3];

                cars.Add(new CAR(model, engine, weight, color));
            }
        }

        cars.ForEach(Console.WriteLine);
    }
}
