﻿using System.Linq;
using System.Numerics;

namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');

    }
    private int level = 1;
    public int Level 
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public abstract int Power { get; }

    public abstract string Info { get; }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
 


    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }


    public abstract string Greeting();

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";
    public string[] Go(Direction[] directions)
    {
        var output = new string[directions.Length];
        for (int i =0; i< directions.Length; i++)
        {
            output[i] = Go(directions[i]);
        }
        return output;
    }

    public string[] Go(string letters) => Go(DirectionParser.Parse(letters));

}
