using System.Net.Http.Headers;

namespace Simulator.Maps;

public class SmallSquareMap: SmallMap
{


    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }


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
