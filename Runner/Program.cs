using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        //Lab4a();
        //Creature c = new Elf("Elandor", 5, 3);
        //Console.WriteLine(c);  // ELF: Elandor [5]
        //Lab4b();
        //lab5a();
        //Lab5b();
        Orc o = new Orc();
        Console.WriteLine(Orc.Go("UDL"));
    }

    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }

    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }

    static void lab5a()
    {
        try
        {
            Rectangle rectangle1 = new Rectangle(7, 8, 1, 2);
            Rectangle rectangle2 = new Rectangle(new Point(2, 2), new Point(1, 1));

            Console.WriteLine($"rectangle1: {rectangle1}, rectangle2: {rectangle2}");

            Point pointInside = new Point(3, 4);
            Point pointOutside = new Point(-1, 0);

            Console.WriteLine($"Punkt {pointInside} wewnatrz prostokata {rectangle1}: {rectangle1.Contains(pointInside)}");
            Console.WriteLine($"Punkt {pointOutside} wewnatrz prostokata {rectangle1}: {rectangle1.Contains(pointOutside)}");
        }
        catch (ArgumentException error)
        {
            Console.WriteLine(error.Message);
        }
    }

    static void Lab5b()
    {
        try
        {
            SmallSquareMap map = new SmallSquareMap(10);

            Console.WriteLine(map.Exist(new Point(5, 5)));  // True
            Console.WriteLine(map.Exist(new Point(10, 10))); // False

            Point start = new Point(4, 4);
            Console.WriteLine(map.Next(start, Direction.Up));     // (4, 5)
            Console.WriteLine(map.Next(start, Direction.Right));  // (5, 4)
            Console.WriteLine(map.Next(new Point(9, 9), Direction.Right));  // (9, 9)

            Console.WriteLine(map.NextDiagonal(start, Direction.Up));   // (5, 5)
            Console.WriteLine(map.NextDiagonal(new Point(0, 0), Direction.Left));  // (0, 0)
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
