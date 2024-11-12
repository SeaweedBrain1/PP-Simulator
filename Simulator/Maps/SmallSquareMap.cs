using System.Net.Http.Headers;

namespace Simulator.Maps;

public class SmallSquareMap: Map
{
    public readonly int Size;

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "rozmiar musi byc z przedzialu 5-20");
        }

        else
        {
            Size = size;
        }
    }

    public override bool Exist(Point p)
    {
        Rectangle r = new Rectangle(new Point(0,0), new Point(Size-1, Size-1));
        return r.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        return Exist(p.Next(d)) ? p.Next(d) : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return Exist(p.NextDiagonal(d)) ? p.NextDiagonal(d) : p;
    }
}
