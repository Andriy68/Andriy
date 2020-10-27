using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class pizza
{
    private string name;
    private dough dough;
    private List<topping> toppings;

    public pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<topping>();
    }

    private string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public dough Dough
    {
        set
        {
            this.dough = value;
        }
    }

    public void AddTopping(topping topping)
    {
        if (this.toppings.Count == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

        this.toppings.Add(topping);
    }

    public double Calories()
    {
        double sum = 0;
        sum += this.dough.calories();
        this.toppings.ForEach(t => sum += t.calories());

        return sum;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Calories():f2} Calories.";
    }
}
public class dough
{
    private const int BaseCaloriesPerGram = 2;

    private static object[] allowedFlourTypes = {
        new { FlourType = "white", CaloriesModifier = 1.5 },
        new { FlourType = "wholegrain", CaloriesModifier = 1.0 }
    };

    private static object[] allowedBakingTechniqueTypes = {
        new { BakingTechnique = "crispy", CaloriesModifier = 0.9 },
        new { BakingTechnique = "chewy", CaloriesModifier = 1.1 },
        new { BakingTechnique = "homemade", CaloriesModifier = 1.0 }
    };

    private string flourType;
    private string bakingTechnique;
    private int weight;

    public dough(string flourType, string bakingTechnique, int weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    private string FlourType
    {
        get
        {
            return this.flourType;
        }

        set
        {
            if (!allowedFlourTypes.Any(
                ft => (string)ft.GetType().GetProperty("FlourType").GetValue(ft, null) == value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    private string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }

        set
        {
            if (!allowedBakingTechniqueTypes.Any(
                bt => (string)bt.GetType().GetProperty("BakingTechnique").GetValue(bt, null) == value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    private int Weight
    {
        get
        {
            return this.weight;
        }

        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.weight = value;
        }
    }

    public double calories()
    {
        var ftObject = allowedFlourTypes.First(ft => (string)ft.GetType().GetProperty("FlourType").GetValue(ft, null) == this.FlourType.ToLower());
        var ftModifier = (double)ftObject.GetType().GetProperty("CaloriesModifier").GetValue(ftObject, null);

        var btObject = allowedBakingTechniqueTypes.First(bt => (string)bt.GetType().GetProperty("BakingTechnique").GetValue(bt, null) == this.BakingTechnique.ToLower());
        var btModifier = (double)btObject.GetType().GetProperty("CaloriesModifier").GetValue(btObject, null);

        return BaseCaloriesPerGram * ftModifier * btModifier * this.Weight;
    }
}

public class topping
{
    private const int BaseCaloriesPerGram = 2;

    private static object[] allowedToppingTypes = {
        new { ToppingType = "meat", CaloriesModifier = 1.2 },
        new { ToppingType = "veggies", CaloriesModifier = 0.8 },
        new { ToppingType = "cheese", CaloriesModifier = 1.1 },
        new { ToppingType = "sauce", CaloriesModifier = 0.9 }
    };

    private string toppingType;
    private int weight;

    public topping(string toppingType, int weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    private string ToppingType
    {
        get
        {
            return this.toppingType;
        }

        set
        {
            if (!allowedToppingTypes.Any(
                tt => (string)tt.GetType().GetProperty("ToppingType").GetValue(tt, null) == value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.toppingType = value;
        }
    }

    private int Weight
    {
        get
        {
            return this.weight;
        }

        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double calories()
    {
        var ttObject = allowedToppingTypes.First(tt => (string)tt.GetType().GetProperty("ToppingType").GetValue(tt, null) == this.ToppingType.ToLower());
        var ttModifier = (double)ttObject.GetType().GetProperty("CaloriesModifier").GetValue(ttObject, null);

        return BaseCaloriesPerGram * ttModifier * this.Weight;
    }
}
class Program
{
    static void Main(string[] args)
    {
        try
        {
            var tokens = Console.ReadLine().Split();
            pizza pizza = new pizza(tokens[1]);
            tokens = Console.ReadLine().Split();
            pizza.Dough = new dough(tokens[1], tokens[2], int.Parse(tokens[3]));

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                tokens = command.Split();
                pizza.AddTopping(new topping(tokens[1], int.Parse(tokens[2])));
            }

            Console.WriteLine(pizza);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}