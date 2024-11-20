﻿using System.ComponentModel;
using System.Drawing;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public abstract void Add(Creature creature, Point position);
    public abstract void Remove(Creature creature, Point position);

    public abstract List<Creature>? At(int x, int y);







    public int SizeX { get; }
    public int SizeY { get; }

    private readonly Rectangle bounds;
    protected Map(int sizeX, int sizeY)
    {
        if (SizeX < 5) throw new ArgumentOutOfRangeException(nameof(SizeX), "Too narrow");

        if (SizeY < 5) throw new ArgumentOutOfRangeException(nameof(SizeY), "Too short");

        SizeX = sizeX;
        SizeY = sizeY;

        bounds = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }



    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => bounds.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}