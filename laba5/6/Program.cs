using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class team
{
    private string name;
    private List<player> players;

    public team(string name)
    {
        this.Name = name;
        this.players = new List<player>();
    }

    internal string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    internal void AddPlayer(player player)
    {
        this.players.Add(player);
    }

    internal void RemovePlayer(string playerName)
    {
        if (!this.players.Any(p => p.Name == playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }

        this.players.Remove(this.players.First(p => p.Name == playerName));
    }

    internal int Rating
    {
        get
        {
            return this.players.Count == 0 ? 0 : Convert.ToInt32((this.players.Average(p => p.Stats)));
        }
    }
}
public class player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    internal string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    private int Endurance
    {
        get
        {
            return this.endurance;
        }

        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Endurance should be between 0 and 100.");
            }

            this.endurance = value;
        }
    }

    private int Sprint
    {
        get
        {
            return this.sprint;
        }

        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Sprint should be between 0 and 100.");
            }

            this.sprint = value;
        }
    }

    private int Dribble
    {
        get
        {
            return this.dribble;
        }

        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Dribble should be between 0 and 100.");
            }

            this.dribble = value;
        }
    }

    private int Passing
    {
        get
        {
            return this.passing;
        }

        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Passing should be between 0 and 100.");
            }

            this.passing = value;
        }
    }

    private int Shooting
    {
        get
        {
            return this.shooting;
        }

        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Shooting should be between 0 and 100.");
            }

            this.shooting = value;
        }
    }

    internal int Stats
    {
        get
        {
            return (int)Math.Round((this.Endurance + this.Dribble + this.Sprint + this.Passing + this.Shooting) / 5.0);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var teams = new List<team>();

        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            var tokens = command.Split(';');

            try
            {
                if (tokens[0] == "Team")
                {
                    teams.Add(new team(tokens[1]));
                }
                else if (tokens[0] == "Add")
                {
                    var team = teams.FirstOrDefault(t => t.Name == tokens[1]);
                    if (team == null)
                    {
                        throw new ArgumentException($"Team {tokens[1]} does not exist.");
                    }

                    var player = new player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));

                    team.AddPlayer(player);
                }
                else if (tokens[0] == "Remove")
                {
                    var team = teams.FirstOrDefault(t => t.Name == tokens[1]);
                    if (team == null)
                    {
                        throw new ArgumentException($"Team {tokens[1]} does not exist.");
                    }

                    team.RemovePlayer(tokens[2]);
                }
                else if (tokens[0] == "Rating")
                {
                    var team = teams.FirstOrDefault(t => t.Name == tokens[1]);
                    if (team == null)
                    {
                        throw new ArgumentException($"Team {tokens[1]} does not exist.");
                    }

                    Console.WriteLine($"{team.Name} - {team.Rating}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}