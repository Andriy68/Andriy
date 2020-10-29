using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class people
{
    private string firstName;
    private string lastName;
    private string bithdate;
    private List<people> parents;
    private List<people> children;

    public people()
    {
        this.children = new List<people>();
        this.parents = new List<people>();
    }

    public people(string firstName, string lastName)
        : this()
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public people(string birthdate)
        : this()
    {
        this.BirthDate = birthdate;
    }

    public string BirthDate
    {
        get { return bithdate; }
        set { bithdate = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public List<people> Children
    {
        get
        {
            return this.children;
        }

        set
        {
            this.children = value;
        }
    }

    public List<people> Parents
    {
        get
        {
            return this.parents;
        }

        set
        {
            this.parents = value;
        }
    }

    public void AddChild(people child)
    {
        this.children.Add(child);
    }

    public void AddParent(people parent)
    {
        this.parents.Add(parent);
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"{FirstName} {LastName} {BirthDate}");
        builder.AppendLine("Parents:");

        foreach (var parent in parents)
        {
            builder.AppendLine($"{parent.FirstName} {parent.LastName} {parent.BirthDate}");
        }

        builder.AppendLine("Children:");

        foreach (var child in children)
        {
            builder.AppendLine($"{child.FirstName} {child.LastName} {child.BirthDate}");
        }

        return builder.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var manInfo = Console.ReadLine().Split();
        List<people> tree = new List<people>();

        if (manInfo.Length == 1)
        {
            tree.Add(new people(manInfo[0]));
        }
        else if (manInfo.Length == 2)
        {
            tree.Add(new people(manInfo[0], manInfo[1]));
        }

        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split(new[] { ' ', '-' });

            if (tokens.Length == 2)
            {
                if (!tree.Any(p => p.BirthDate == tokens[0]))
                {
                    tree.Add(new people(tokens[0]));
                }

                var parent = tree.First(p => p.BirthDate == tokens[0]);

                if (!tree.Any(p => p.BirthDate == tokens[1]))
                {
                    tree.Add(new people(tokens[1]));
                }

                var child = tree.First(p => p.BirthDate == tokens[1]);

                parent.AddChild(child);
                child.AddParent(parent);
            }
            else if (tokens.Length == 3)
            {
                if (command.Contains("-"))
                {
                    if (Char.IsDigit(tokens[0][0]))
                    {
                        if (!tree.Any(p => p.BirthDate == tokens[0]))
                        {
                            tree.Add(new people(tokens[0]));
                        }

                        var parent = tree.First(p => p.BirthDate == tokens[0]);

                        if (!tree.Any(p => p.FirstName == tokens[1] && p.LastName == tokens[2]))
                        {
                            tree.Add(new people(tokens[1], tokens[2]));
                        }

                        var child = tree.First(p => p.FirstName == tokens[1] && p.LastName == tokens[2]);

                        parent.AddChild(child);
                        child.AddParent(parent);
                    }
                    else if (Char.IsDigit(tokens[2][0]))
                    {
                        if (!tree.Any(p => p.BirthDate == tokens[2]))
                        {
                            tree.Add(new people(tokens[2]));
                        }

                        var child = tree.First(p => p.BirthDate == tokens[2]);

                        if (!tree.Any(p => p.FirstName == tokens[0] && p.LastName == tokens[1]))
                        {
                            tree.Add(new people(tokens[0], tokens[1]));
                        }

                        var parent = tree.First(p => p.FirstName == tokens[0] && p.LastName == tokens[1]);

                        parent.AddChild(child);
                        child.AddParent(parent);
                    }
                }
                else
                {
                    var persons = tree.Where(p => (p.FirstName == tokens[0] && p.LastName == tokens[1]) || p.BirthDate == tokens[2]);

                    var children = new List<people>();
                    var parents = new List<people>();

                    foreach (var person in persons)
                    {
                        children.AddRange(person.Children);
                        parents.AddRange(person.Parents);
                    }

                    foreach (var person in persons)
                    {
                        person.FirstName = tokens[0];
                        person.LastName = tokens[1];
                        person.BirthDate = tokens[2];
                        person.Children = children;
                        person.Parents = parents;
                    }
                }
            }
            else if (tokens.Length == 4)
            {
                if (!tree.Any(p => p.FirstName == tokens[0] && p.LastName == tokens[1]))
                {
                    tree.Add(new people(tokens[0], tokens[1]));
                }

                var parent = tree.First(p => p.FirstName == tokens[0] && p.LastName == tokens[1]);

                if (!tree.Any(p => p.FirstName == tokens[2] && p.LastName == tokens[3]))
                {
                    tree.Add(new people(tokens[2], tokens[3]));
                }

                var child = tree.First(p => p.FirstName == tokens[2] && p.LastName == tokens[3]);

                parent.AddChild(child);
                child.AddParent(parent);
            }
        }

        people target = null;
        if (manInfo.Length == 1)
        {
            target = tree.First(p => p.BirthDate == manInfo[0]);
        }
        else if (manInfo.Length == 2)
        {
            target = tree.First(p => p.FirstName == manInfo[0] && p.LastName == manInfo[1]);
        }

        Console.WriteLine(target);
    }
}
