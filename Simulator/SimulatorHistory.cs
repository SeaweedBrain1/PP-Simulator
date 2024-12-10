using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Simulator;
public class SimulationHistory
{
    private readonly List<State> history = new();
    public void SaveState(int turn, Dictionary<IMappable, Point> positions, IMappable currentMappable, Direction? currentMove) =>
        history.Add(new State
        {
            Turn = turn,
            Positions = new Dictionary<IMappable, Point>(positions),
            CurrentMappable = currentMappable,
            CurrentMove = currentMove
        });
    public void ShowState(int turn)
    {
        if (turn < 0 || turn >= history.Count)
        {
            throw new ArgumentOutOfRangeException("This Simulation doesn't have this turn!");
        }
        var state = history[turn];
        Console.WriteLine($"Turn: {turn}");
        if (state.CurrentMappable != null && state.CurrentMove.HasValue) Console.WriteLine($"{state.CurrentMappable.ToString()} moved {state.CurrentMove}");

        foreach (var entry in state.Positions) Console.WriteLine($"{entry.Key} is at {entry.Value}");
    }
    private class State
    {
        public int Turn { get; set; }
        public Dictionary<IMappable, Point> Positions { get; set; } = new();
        public IMappable? CurrentMappable { get; set; }
        public Direction? CurrentMove { get; set; }
    }
}