using Simulator.Maps;
using System.Linq;
using System.Numerics;

namespace Simulator;

public abstract class Creature
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

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


    public abstract string Greeting();

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (Map != null) throw new InvalidOperationException($"Creature is already on a map, it can't be moved to another one!");
        if (!map.Exist(position)) throw new ArgumentException("This map doesn't contain this point!");
        Map = map;
        Position = position;
        map.Add(this, position);
    }

    public string Go(Direction direction)
    {
        if (Map == null) throw new InvalidOperationException("Creature isn't on a map so it can't move!");
        var newPosition = Map.Next(Position, direction);
        Map.Move(this, Position, newPosition);
        Position = newPosition;
        return $"{Name} goes {direction.ToString().ToLower()}.";
    }
}
