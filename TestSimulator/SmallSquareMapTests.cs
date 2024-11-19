using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestSimulator;
public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        int size = 12;
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }
    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    [InlineData(-1)]

    public void
        Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException
        (int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallTorusMap(size));
    }
    [Theory]
    [InlineData(1, 2, 5, true)]
    [InlineData(1, 11, 10, false)]
    [InlineData(16, 1, 15, false)]
    [InlineData(9, 9, 10, true)]
    [InlineData(10, 10, 10, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y,
        int size, bool expectedOutput)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expectedOutput, result);
    }
    [Theory]
    [InlineData(1, 2, Direction.Up, 1, 3)]
    [InlineData(4, 5, Direction.Down, 4, 4)]
    [InlineData(6, 7, Direction.Left, 5, 7)]
    [InlineData(8, 9, Direction.Right, 9, 9)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
    [Theory]
    [InlineData(1, 19, Direction.Up, 1, 19)]
    [InlineData(1, 0, Direction.Down, 1, 0)]
    [InlineData(0, 1, Direction.Left, 0, 1)]
    [InlineData(19, 1, Direction.Right, 19, 1)]
    public void Next_ShouldReturnTheSamePoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
    [Theory]
    [InlineData(10, 10, Direction.Up, 11, 11)]
    [InlineData(10, 10, Direction.Down, 9, 9)]
    [InlineData(10, 10, Direction.Left, 9, 11)]
    [InlineData(10, 10, Direction.Right, 11, 9)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
    [Theory]
    [InlineData(9, 9, Direction.Up, 9, 9)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(9, 9, Direction.Right, 9, 9)]
    public void NextDiagonal_ShouldReturnTheSamePoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}