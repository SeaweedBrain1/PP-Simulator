namespace Simulator;

internal class Birds : Animals
{
    private bool canFly = true;
    public bool CanFly
    {
        get => canFly;
        init => canFly = value;
    }

    public override string Info()
    {
        string flyAbility = CanFly ? "fly+" : "fly-";
        return $"{Description} ({flyAbility}) <{Size}>";
    }
}


