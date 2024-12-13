using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private readonly Rectangle bounds;
    public int SizeX { get; }
    public int SizeY { get; }

    private Dictionary<Point, List<IMappable>> _fields;

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(SizeX), "Too narrow");

        if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(SizeY), "Too short");

        SizeX = sizeX;
        SizeY = sizeY;

        bounds = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        _fields = new Dictionary<Point, List<IMappable>>();
    }

    public virtual void Add(IMappable mappable, Point position)
    {
        PositionInMap(position);
        AddPositionToDict(position);
        _fields[position].Add(mappable);
    }
    public virtual void Remove(IMappable mappable, Point position)
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
    public void Move(IMappable mappable, Point positionFrom, Point positionTo)
    {
        if (!Exist(positionFrom) || !Exist(positionTo)) throw new ArgumentException("Map doesn't contain one of the points!");
        Add(mappable, positionTo);
        Remove(mappable, positionFrom);
    }

    public virtual List<IMappable>? At(Point position)
    {
        PositionInMap(position);
        AddPositionToDict(position);
        return _fields[position];
    }

    public virtual List<IMappable>? At(int x, int y) => At(new Point(x, y));

    public virtual void PositionInMap(Point position)
    {
        if (!Exist(position)) throw new ArgumentException("Position outside the map!");
    }

    private void AddPositionToDict(Point position)
    {
        if (!_fields.ContainsKey(position))
        {
            _fields[position] = new List<IMappable>();
        }
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => bounds.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}