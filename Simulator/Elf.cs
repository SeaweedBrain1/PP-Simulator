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
    public override string Info => $"ELF: {Name} [{Level}][{Agility}]";


    public Elf() { }
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }


    public void Sing()
    {
        singCounter++;

        if (singCounter % 3 == 0 && agility < 10)
        {
            agility++;
        }
    }
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
}
