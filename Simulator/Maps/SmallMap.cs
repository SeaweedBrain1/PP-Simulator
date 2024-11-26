
namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<Creature>?[,] _fields; 
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (SizeX > 20) throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");

        if (SizeY > 20) throw new ArgumentOutOfRangeException(nameof(SizeY), "Too long");

        _fields = new List<Creature>?[sizeX, sizeY];
    }

    public override void Add(Creature creature, Point position)
    {
        PositionInMap(position);
        _fields[position.X, position.Y] ??= new List<Creature>();
        _fields[position.X, position.Y].Add(creature);
    }

    public override void Remove(Creature creature, Point position)
    {
        PositionInMap(position);
        _fields[position.X, position.Y]?.Remove(creature);
    }

    public override List<Creature>? At(Point position)
    {
        PositionInMap(position);
        return _fields[position.X, position.Y];
    }

    public override List<Creature>? At(int x, int y) => At(new Point(x, y));

    private void PositionInMap(Point position)
    {
        if (!Exist(position)) throw new ArgumentException("Position outside the map!");
    }

}
