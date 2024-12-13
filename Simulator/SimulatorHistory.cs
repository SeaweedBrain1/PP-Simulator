using Simulator;
using Simulator.Maps;
using System.ComponentModel;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        for (int i = 0; i < _simulation.Moves.Length; i++)
        {
            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = _simulation.CurrentMappable.ToString(),
                Move = _simulation.CurrentMoveName.ToString(),
                Symbols = _simulation.Mappables.GroupBy(mappable => mappable.Position).ToDictionary(
                    group => group.Key,
                    group => group.Count() > 1 ? 'X' : group.First().Symbol
                    )
            });

            _simulation.Turn();
        }
    }

    /// <summary>
    /// State of map after single simulation turn.
    /// </summary>
    public class SimulationTurnLog
    {
        /// <summary>
        /// Text representastion of moving object in this turn.
        /// CurrentMappable.ToString()
        /// </summary>
        public required string Mappable { get; init; }
        /// <summary>
        /// Text representation of move in this turn.
        /// CurrentMoveName.ToString();
        /// </summary>
        public required string Move { get; init; }
        /// <summary>
        /// Dictionary of IMappable.Symbol on the map in this turn.
        /// </summary>
        public required Dictionary<Point, char> Symbols { get; init; }
    }
}