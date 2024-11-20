namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string letters)
    {
        List<Direction> directions = new();

        foreach (var letter in letters)
        {
            if (letter == 'u' || letter == 'U')
            {
                directions.Add(Direction.Up);
            }
            else if (letter == 'd' || letter == 'D')
            {
                directions.Add(Direction.Down);;
            }
            else if (letter == 'l' || letter == 'L')
            {
                directions.Add(Direction.Left);
            }
            else if (letter == 'r' || letter == 'R')
            {
                directions.Add(Direction.Right);
            }
        }

        return directions;
    }
}
