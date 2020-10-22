using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class people
{
    private string name;
    private decimal money;
    private List<product> products;

    public people(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    private decimal Money
    {
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public IReadOnlyCollection<product> Products
    {
        get
        {
            return this.products;
        }
    }

    public bool BuyProduct(product product)
    {
        if (this.money >= product.Cost)
        {
            this.money -= product.Cost;
            this.products.Add(product);
            return true;
        }

        return false;
    }
}
public class product
{
    private string name;
    private decimal cost;

    public product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Cost
    {
        get
        {
            return this.cost;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.cost = value;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
        List<people> persons = new List<people>();
        List<product> products = new List<product>();

        foreach (var pair in input)
        {
            var tokens = pair.Split('=');

            try
            {
                persons.Add(new people(tokens[0], decimal.Parse(tokens[1])));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        foreach (var pair in input)
        {
            var tokens = pair.Split('=');

            try
            {
                products.Add(new product(tokens[0], decimal.Parse(tokens[1])));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            var tokens = command.Split();

            string personName = tokens[0];
            string productName = tokens[1];

            var person = persons.Single(p => p.Name == personName);
            var product = products.Single(p => p.Name == productName);

            if (!person.BuyProduct(product))
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
        }

        foreach (var person in persons)
        {
            string productsBought = person.Products.Count == 0 ? "Nothing bought" : String.Join(", ", person.Products.Select(p => p.Name));

            Console.WriteLine($"{person.Name} - {productsBought}");
        }
    }
}