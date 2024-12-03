using Simulator.Maps;

namespace Simulator;

public class Animals: IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; protected set; }
    public virtual char Symbol => 'A';
    private string description = "Unknown";
    public required string Description 
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');
    }
    public uint Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";

    public void Go(Direction direction)
    {
        if (Map == null) throw new InvalidOperationException("Animal is not on a map!");
        var newPosition = GetNewPosition(direction);
        Map.Move(this, Position, newPosition);
        Position = newPosition;
    }


    public void InitMapAndPosition(Map map, Point point)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (Map != null) throw new InvalidOperationException("This animal is already on a map.");
        if (!map.Exist(point)) throw new ArgumentException("Non-existing position for this map.");
        Map = map;
        Position = point;
        map.Add(this, point);
    }

    protected virtual Point GetNewPosition(Direction direction)
    {
        return Map.Next(Position, direction);
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
