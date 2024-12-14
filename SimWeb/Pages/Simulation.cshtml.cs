using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
public class SimulationModel : PageModel
{
    public SimulationHistory SimulationHistory { get; private set; }
    public int CurrentTurn { get; private set; }
    public int MaxTurn => SimulationHistory.TurnLogs.Count - 1;

    public SimulationModel()
    {
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
        SimulationHistory = new SimulationHistory(simulation);
        CurrentTurn = 0;
    }

    public void OnGet(int? turn)
    {
        CurrentTurn = turn ?? 0;
    }

    public void OnPostChangeTurn(string direction, int? turn)
    {
        CurrentTurn = turn ?? 0;

        if (direction == "prev" && CurrentTurn > 0)
        {
            CurrentTurn--;
        }
        else if (direction == "next" && CurrentTurn < MaxTurn)
        {
            CurrentTurn++;
        }
    }
}
