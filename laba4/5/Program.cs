using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class bag
{
    private List<Item> bag1;
    private long capacity;
    private long current;

    public bag(long capacity)
    {
        this.capacity = capacity;
        bag1 = new List<Item>();
    }

    public long GoldItemsValue
    {
        get
        {
            return bag1.Where(i => i is gold).Sum(i => i.Value);
        }
    }

    public long CashItemsValue
    {
        get
        {
            return bag1.Where(i => i is cash).Sum(i => i.Value);
        }
    }

    public long GemItemsValue
    {
        get
        {
            return bag1.Where(i => i is gem).Sum(i => i.Value);
        }
    }

    public void AddGoldItem(gold item)
    {
        if (capacity >= current + item.Value)
        {
            var goldItems = GetGoldItems();
            if (goldItems.Any(gi => gi.Key == item.Key))
            {
                goldItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
            }
            else
            {
                bag1.Add(item);
            }

            current += item.Value;
        }
    }

    public void AddGemItem(gem item)
    {
        if (capacity >= current + item.Value && GoldItemsValue >= GemItemsValue + item.Value)
        {
            var gemItems = GetGemItems();
            if (gemItems.Any(gi => gi.Key == item.Key))
            {
                gemItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
            }
            else
            {
                bag1.Add(item);
            }
            current += item.Value;
        }
    }

    public void AddCashItem(cash item)
    {
        if (capacity >= current + item.Value && GemItemsValue >= CashItemsValue + item.Value)
        {
            var cashItems = GetCashItems();
            if (cashItems.Any(gi => gi.Key == item.Key))
            {
                cashItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
            }
            else
            {
                bag1.Add(item);
            }
            current += item.Value;
        }
    }

    public List<Item> GetCashItems()
    {
        return bag1.Where(i => i is cash).ToList();
    }

    public List<Item> GetGoldItems()
    {
        return bag1.Where(i => i is gold).ToList();
    }

    public List<Item> GetGemItems()
    {
        return bag1.Where(i => i is gem).ToList();
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        var dictionary = bag1.GroupBy(i => i.GetType().Name).ToDictionary(g => g.Key, g => g.ToList());

        foreach (var kvp in dictionary.OrderByDescending(kv => kv.Value.Sum(i => i.Value)))
        {
            if (kvp.Key == "CashItem")
            {
                builder.AppendLine($"<Cash> ${kvp.Value.Sum(i => i.Value)}");
            }
            else if (kvp.Key == "GemItem")
            {
                builder.AppendLine($"<Gem> ${kvp.Value.Sum(i => i.Value)}");
            }
            else if (kvp.Key == "GoldItem")
            {
                builder.AppendLine($"<Gold> ${kvp.Value.Sum(i => i.Value)}");
            }

            foreach (var item in kvp.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
            {
                builder.AppendLine($"##{item.Key} - {item.Value}");
            }
        }

        return builder.ToString().TrimEnd();
    }
}


public class cash : Item
{
    public cash(string key, long value)
    {
        Key = key;
        Value = value;
    }
}

public class gem : Item
{
    public gem(string key, long value)
    {
        Key = key;
        Value = value;
    }
}
public class gold : Item
{
    public gold(string key, long value)
    {
        Key = key;
        Value = value;
    }
}
public abstract class Item
{
    public string Key { get; protected set; }
    public long Value { get; protected set; }

    public void IncreaseValue(long value)
    {
        Value += value;
    }
}


class Program
{
    static void Main(string[] args)
    {
        long capacity = long.Parse(Console.ReadLine());
        var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var bag = new bag(capacity);

        for (int i = 0; i < input.Length; i += 2)
        {
            string key = input[i];
            long value = long.Parse(input[i + 1]);

            InsertItem(key, value, bag);
        }

        Console.WriteLine(bag.ToString());
    }

    private static void InsertItem(string key, long value, bag bag)
    {
        if (key.Length == 3)
        {
            cash cash = new cash(key, value);
            bag.AddCashItem(cash);
        }
        else if (key.Length >= 4 && key.ToLower().EndsWith("gem"))
        {
            gem gem = new gem(key, value);
            bag.AddGemItem(gem);
        }
        else if (key.ToLower().Equals("gold"))
        {
            gold gold = new gold(key, value);
            bag.AddGoldItem(gold);
        }
    }
}