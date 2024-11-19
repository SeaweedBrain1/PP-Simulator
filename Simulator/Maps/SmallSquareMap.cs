using System.Net.Http.Headers;

namespace Simulator.Maps;

public class SmallSquareMap: Map
{
    private readonly Rectangle bounds;
    public  int Size {  get; }

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "rozmiar musi byc z przedzialu 5-20");
        }

        Size = size;
        bounds = new Rectangle(0, 0, Size - 1, Size - 1);

    }

    public override bool Exist(Point p)
    {
        return bounds.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        var moved = p.Next(d);
        return Exist(moved) ? moved : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var moved = p.NextDiagonal(d);
        return Exist(moved) ? moved : p;
    }
}
