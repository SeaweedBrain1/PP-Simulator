namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');

    }
    private int level = 1;
    public int Level 
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public abstract int Power { get; }

    public abstract string Info { get; }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
 


    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }


    public abstract void SayHi();

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
