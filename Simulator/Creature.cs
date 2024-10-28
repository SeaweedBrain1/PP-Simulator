namespace Simulator;

internal class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            value = value.Trim();
            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }
            else if (value.Length > 25)
            {
                value = value.Substring(0, 25).TrimEnd();
                if (value.Length < 3)
                {
                    value = value.PadRight(3, '#');
                }
            }
            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            name = value;
        }
    }
    private int level = 1;
    public int Level 
    {
        get => level;
        init
        {
            level = value < 1 ? 1 : (value > 10 ? 10 : value);
        }
    }

    public string Info => $"{Name} - [{Level}]";

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string letters)
    {
        var directions = DirectionParser.Parse(letters);
        Go(directions);
    }
}
