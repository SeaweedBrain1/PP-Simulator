using Simulator.Maps;
using Simulator;
using System.Text;
namespace SimConsole;
internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        SmallSquareMap squareMap = new(5);
        SmallTorusMap torusMap = new(8, 6);
        BigBounceMap bounceMap = new(8, 6);
        List<IMappable> creatures = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 3 },
            new Birds { Description = "Eagles", Size = 2, CanFly = true },
            new Birds { Description = "Ostriches", Size = 2, CanFly = false }
        };
        List<Point> points = new()
        {
            new Point(2, 3),
            new Point(4, 4),
            new Point(1, 1),
            new Point(5, 5),
            new Point(0, 0)
        };
        string moves = "luludlulldllullrdllr";
        Simulation simulation = new Simulation(bounceMap, creatures, points, moves);
        //MapVisualizer mapVisualizer = new MapVisualizer(bounceMap);
        //Console.WriteLine("SIMULATION!");
        //Console.WriteLine();
        //Console.WriteLine("Starting positions:");
        //mapVisualizer.Draw();
        //var turn = 1;
        //while (!simulation.Finished)
        //{
        //    ConsoleKeyInfo key = Console.ReadKey(intercept: true);
        //    Console.WriteLine($"Turn {turn}");
        //    Console.WriteLine($"{simulation.CurrentMappable} moves {simulation.CurrentMoveName}");
        //    if (key.Key == ConsoleKey.Spacebar)
        //    {
        //        simulation.Turn();
        //        mapVisualizer.Draw();
        //        turn++;
        //    }
        //}



        SimulationHistory simulationHistory = new(simulation);

        //for (int i = 0; i < simulation.Moves.Length; i++)
        //{
        //    Console.WriteLine($"Tura: {i + 1}\n");
        //    Console.WriteLine(simulationHistory.TurnLogs[i].Mappable);
        //    Console.WriteLine(simulationHistory.TurnLogs[i].Move);
        //    foreach (KeyValuePair<Point, char> kvp in simulationHistory.TurnLogs[i].Symbols)
        //    {
        //        Console.WriteLine($"Postition: {kvp.Key}, Symbol: {kvp.Value}");
        //    }
        //    Console.WriteLine("\n");
        //}


        LogVisualizer logVisualizer = new(simulationHistory);
        for (int i = 0; i < simulation.Moves.Length; i++)
        {
            logVisualizer.Draw(i);
            Console.WriteLine($"{simulationHistory.TurnLogs[i].Mappable} moves {simulationHistory.TurnLogs[i].Move}");
        }
    }
}
