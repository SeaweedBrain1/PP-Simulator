using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
namespace Simulator;
public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }
    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }
    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }
    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }
    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;
    /// <summary>
    /// Current turn counter.
    /// </summary>
    private int counter = 0;
    /// <summary>
    /// Valid moves list.
    /// </summary>
    private HashSet<char> validMoves = new HashSet<char> { 'u', 'd', 'r', 'l' };
    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature
    {
        get => Creatures[counter % Creatures.Count];
    }
    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            var direction = DirectionParser.Parse(Moves[counter % Moves.Length].ToString());
            if (direction.Any()) return direction[0].ToString().ToLower();
            return string.Empty;
        }
    }
    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
            throw new ArgumentException("Creatures list can't be empty!");

        if (positions == null || positions.Count != creatures.Count)
            throw new ArgumentException("Number of positions does not equal the number of creatures.");

        if (string.IsNullOrWhiteSpace(moves))
            throw new ArgumentException("Moves string can't be null or empty.");

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures;
        Positions = positions;
        Moves = ValidateMoves(moves);
        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].InitMapAndPosition(map, positions[i]);
        }
    }
    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished.");
        var direction = DirectionParser.Parse(Moves[counter % Moves.Length].ToString())[0];
        CurrentCreature.Go(direction);
        counter++;
        if (counter >= Moves.Length) Finished = true;
    }
    /// <summary>
    /// Validates moves input.
    /// </summary>
    private string ValidateMoves(string moves) => new string(moves.Where(c => validMoves.Contains(Char.ToLower(c))).ToArray());
}
