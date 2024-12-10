namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
    public override Point Next(Point p, Direction d)
    {
        var moved = p.Next(d);
        return Exist(moved) ? moved : new Point(p.X - (moved.X - p.X), p.Y - (moved.Y - p.Y));
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var moved = p.NextDiagonal(d);
        if (Exist(moved))
        {
            return moved;
        }
        else
        {
            var bounced = new Point(p.X - (moved.X - p.X), p.Y - (moved.Y - p.Y));

            if (Exist(bounced)) { return bounced; } else { return p; }
        }
    }
}
