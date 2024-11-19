using Simulator;
using Xunit;
namespace TestSimulator;
public class ValidatorTests
{
    [Theory]
    [InlineData(2, 0, 5, 2)]
    [InlineData(-1, 0, 5, 0)]
    [InlineData(6, 0, 5, 5)]
    [InlineData(1, 1, 5, 1)]
    [InlineData(6, 1, 6, 6)]
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("test", 3, 6, '_', "Test")]
    [InlineData("too long value", 5, 10, '*', "Too long v")]
    [InlineData("short", 10, 15, '_', "Short_____")]
    [InlineData("  whitespace  ", 5, 10, '_', "Whitespace")]
    [InlineData("a                            AAAA", 5, 15, '#', "A####")]
    [InlineData("Mice           are great", 3, 15, '#', "Mice")]
    [InlineData("  ", 3, 25, '#', "###")]
    [InlineData("Puss in Boots – a clever and brave cat.", 3, 25, '#', "Puss in Boots – a clever")]
    public void Shortener_ShouldReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }
    [Fact]
    public void Shortener_ShouldHandleEmptyString()
    {
        string value = "";
        int min = 5;
        int max = 10;
        char placeholder = '_';
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal("_____", result);
    }
    [Fact]
    public void Shortener_ShouldConvertFirstCharacterToUppercase()
    {
        string value = "lowercase";
        int min = 5;
        int max = 15;
        char placeholder = '_';
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal("Lowercase", result);
    }
}