
namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (SizeX > 20) throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");

        if (SizeY > 20) throw new ArgumentOutOfRangeException(nameof(SizeY), "Too long");
    }

}
