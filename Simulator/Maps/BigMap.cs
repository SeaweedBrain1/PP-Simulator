
namespace Simulator.Maps;

public abstract class BigMap : Map
{
    Dictionary<Point, List<IMappable>> _fields;
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (SizeX > 1000) throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");

        if (SizeY > 1000) throw new ArgumentOutOfRangeException(nameof(SizeY), "Too long");

        _fields = new Dictionary<Point, List<IMappable>>();
    }

    public override void Add(IMappable mappable, Point position)
    {
        PositionInMap(position);
        AddPositionToDict(position);
        _fields[position].Add(mappable);
    }
    public override void Remove(IMappable mappable, Point position)
    {
        PositionInMap(position);
        if (_fields.ContainsKey(position))
        {
            _fields[position].Remove(mappable);
            if (_fields[position].Count == 0)
            {
                _fields.Remove(position);
            }
        }
    }
    public override List<IMappable>? At(Point position)
    {
        PositionInMap(position);
        AddPositionToDict(position);
        return _fields[position];
    }

    public override List<IMappable>? At(int x, int y) => At(new Point(x, y));

    private void AddPositionToDict(Point position)
    {
        if (!_fields.ContainsKey(position))
        {
            _fields[position] = new List<IMappable>();
        }
    }
}
