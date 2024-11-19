using Simulator;
using Xunit;
namespace TestSimulator;
public class RectangleTests
{
    [Theory]
    [InlineData(2, 2, 1, 1, 1, 1, 2, 2)]
    [InlineData(2, 8, 7, 3, 2, 3, 7, 8)]
    [InlineData(-1, -1, 1, 1, -1, -1, 1, 1)]
    [InlineData(0, 0, 5, 5, 0, 0, 5, 5)]
    [InlineData(5, 5, 0, 0, 0, 0, 5, 5)]
    public void Constructor_ShouldSetCorrectCoordinates(int x1, int y1, int x2, int y2, int expectedX1, int expectedY1, int expectedX2, int expectedY2)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(expectedX1, rectangle.X1);
        Assert.Equal(expectedY1, rectangle.Y1);
        Assert.Equal(expectedX2, rectangle.X2);
        Assert.Equal(expectedY2, rectangle.Y2);
    }
    [Theory]
    [InlineData(1, 6, 1, 7)]
    [InlineData(0, 0, 0, 0)]
    [InlineData(5, 1, 6, 1)]
    [InlineData(-2, 5, -2, 5)]
    [InlineData(6, 6, -2, 6)]
    public void Constructor_InvalidRectangle_ShouldThrowArgumentException(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }
    [Theory]
    [InlineData(1, 1, 5, 5, 2, 3, true)]
    [InlineData(1, 1, 5, 5, 4, 6, false)]
    [InlineData(1, 1, 4, 5, 1, 5, true)]
    [InlineData(1, 1, 4, 5, 4, 1, true)]
    [InlineData(0, 0, 10, 10, 6, 6, true)]
    [InlineData(0, 0, 10, 10, 0, 0, true)]
    [InlineData(0, 0, 10, 10, 10, 10, true)]
    [InlineData(0, 0, 10, 10, -1, -1, false)]
    [InlineData(0, 0, 10, 10, 12, 0, false)]
    [InlineData(0, 0, 10, 10, 0, 12, false)]
    public void Contains_ShouldReturnCorrectValue(int x1, int y1, int x2, int y2, int px, int py, bool expected)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);
        var result = rectangle.Contains(point);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(0, 0, 1, 1, "(0, 0):(1, 1)")]
    [InlineData(1, 1, 0, 0, "(0, 0):(1, 1)")]
    [InlineData(6, 7, 12, 12, "(6, 7):(12, 12)")]
    [InlineData(6, 7, -12, -12, "(-12, -12):(6, 7)")]
    public void ToString_ShouldReturnCorrectFormat(int x1, int y1, int x2, int y2, string expected)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var result = rectangle.ToString();
        Assert.Equal(expected, result);
    }
}

