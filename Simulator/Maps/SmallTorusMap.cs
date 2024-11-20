using Simulator.Maps;
using Simulator;

public class SmallTorusMap : Map
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        var moved = p.Next(d);
        return new Point((moved.X + SizeX) % SizeX, (moved.Y + SizeY) % SizeY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var moved = p.NextDiagonal(d);
        return new Point((moved.X + SizeX) % SizeX, (moved.Y + SizeY) % SizeY);
    }
}
