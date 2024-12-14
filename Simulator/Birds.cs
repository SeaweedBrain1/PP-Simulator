namespace Simulator;

public class Birds : Animals
{
    public override char Symbol => CanFly ? 'B' : 'N';
    private bool canFly = true;
    public bool CanFly
    {
        get => canFly;
        init => canFly = value;
    }

    public override string Info => $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>";


    protected override Point GetNewPosition(Direction direction) => CanFly
        ? Map.Next(Map.Next(Position, direction), direction)
        : Map.NextDiagonal(Position, direction);
}


