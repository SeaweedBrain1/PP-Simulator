
namespace Simulator.Maps;

public abstract class BigMap : Map
{
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (SizeX > 1000) throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");

        if (SizeY > 1000) throw new ArgumentOutOfRangeException(nameof(SizeY), "Too long");

    }
}
