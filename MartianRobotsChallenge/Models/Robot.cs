using System;

namespace MartianRobotsChallenge.Models
{
    public class Robot
    {
        public Coordinate Coordinates { get; set; }
        public Orientation Orientation { get; set; }
        public bool IsLost { get; set; }
        private Mars _mars;

        public Robot(Coordinate robotPosition, Orientation orientation)
        {
            Coordinates = robotPosition;
            Orientation = orientation;
        }

        public Robot(Coordinate robotPosition, Orientation orientation, Mars mars)
        {
            Coordinates = robotPosition;
            Orientation = orientation;
            _mars = mars;
        }

        private Coordinate MoveForward()
        {
            var nextRobotPosition = new Coordinate(Coordinates.X, Coordinates.Y);

            switch (Orientation)
            {
                case Orientation.North:
                    nextRobotPosition.Y++;
                    break;
                case Orientation.East:
                    nextRobotPosition.X++;
                    break;
                case Orientation.South:
                    nextRobotPosition.Y--;
                    break;
                case Orientation.West:
                    nextRobotPosition.X--;
                    break;
            }


            //Console.WriteLine($"{nextRobotPosition.X} {nextRobotPosition.Y} {Orientation}");
            if (IsPositionOutOfBounds(nextRobotPosition))
            {
                if (!_mars.IsScentedCoordinate(Coordinates))
                {
                    IsLost = true;
                    _mars.AddForbiddenCoordinate(Coordinates);
                }
            }
            else
            {
                Coordinates = nextRobotPosition;
            }

            return Coordinates;
        }

        // Rotating (turning) right, because it happens within the same grid point
        private void RotateRight()
        {
            // The last enum in Orientation.cs is West = 3, '4' does not exist so we restart at North
            if (Orientation == Orientation.West)
                Orientation = Orientation.North;
            else
                Orientation++;
        }

        private void RotateLeft()
        {
            // The first enum in Orientation.cs is North = 0, '-1' does not exist so we restart at West
            if (Orientation == Orientation.North)
                Orientation = Orientation.West;
            else
                Orientation--;
        }

        public void ExecuteInstruction(RobotInstruction instruction)
        {
            if (!IsLost)
            {
                switch (instruction)
                {
                    case RobotInstruction.Forward:
                        MoveForward();
                        break;
                    case RobotInstruction.Left:
                        RotateLeft();
                        break;
                    case RobotInstruction.Right:
                        RotateRight();
                        break;
                    default:
                        throw new ArgumentException("Forbidden instruction");
                }
            }
        }

        private bool IsPositionOutOfBounds(Coordinate coordinate) => coordinate.X > _mars.Coordinate.X || coordinate.Y > _mars.Coordinate.Y || coordinate.X < 0 || coordinate.Y < 0;
    }
}
