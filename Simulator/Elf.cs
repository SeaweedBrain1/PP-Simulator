using System;
using System.Reflection.Emit;

namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    public int Agility
    {   
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }

    private int singCounter = 0;

    public override int Power => 8 * Level + 2 * Agility;
    public override string Info => $"{Name} [{Level}][{Agility}]";


    public Elf() { }
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }


    public void Sing()
    {
        singCounter++;
        Console.WriteLine($"{Name} is singing.");

        if (singCounter % 3 == 0 && agility < 10)
        {
            agility++;
            Console.WriteLine($"Agility Up ({agility-1} -> {agility})");
        }
    }
    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
    );
}
