using System.Collections.Generic;

namespace MartianRobotsChallenge.Models
{
    public class Mars
    {
        public Coordinate Coordinate { get; set; }
        private List<Coordinate> forbiddenCoordinate = new List<Coordinate>();

        public Mars(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public void AddForbiddenCoordinate(Coordinate coordinate)
        {
            forbiddenCoordinate.Add(coordinate);
        }

        public bool IsScentedCoordinate(Coordinate coordinate)
        {
            return forbiddenCoordinate.Contains(coordinate);
        }
    }
}
