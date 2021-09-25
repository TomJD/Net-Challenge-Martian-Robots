namespace MartianRobotsChallenge.Models
{
    public class Coordinate
    {
        // Pair of Integers. It is a Coordinate so it is (x,y) format
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
