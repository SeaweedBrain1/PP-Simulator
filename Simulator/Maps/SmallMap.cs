
namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<IMappable>?[,] _fields; 
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (SizeX > 20) throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");

        if (SizeY > 20) throw new ArgumentOutOfRangeException(nameof(SizeY), "Too long");

        _fields = new List<IMappable>?[sizeX, sizeY];
    }

    public override void Add(IMappable mappable, Point position)
    {
        PositionInMap(position);
        _fields[position.X, position.Y] ??= new List<IMappable>();
        _fields[position.X, position.Y].Add(mappable);
    }

    public override void Remove(IMappable mappable, Point position)
    {
        PositionInMap(position);
        _fields[position.X, position.Y]?.Remove(mappable);
    }

    public override List<IMappable>? At(Point position)
    {
        PositionInMap(position);
        return _fields[position.X, position.Y];
    }

    public override List<IMappable>? At(int x, int y) => At(new Point(x, y));

    private void PositionInMap(Point position)
    {
        if (!Exist(position)) throw new ArgumentException("Position outside the map!");
    }

}
