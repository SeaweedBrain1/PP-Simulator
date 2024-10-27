namespace Simulator;

internal class Creature
{
    private string? name;
    public string? Name { get; set; }

    private int level;
    public int Level {  get; set; }

    public string Info => $"{Name} - [{Level}]";

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
}
