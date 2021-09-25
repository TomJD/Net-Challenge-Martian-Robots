namespace MartianRobotsChallenge.Models
{
    public enum Orientation
    {
        // In this particular order, clockwise, keeps RobotInstruction.cs rotations (left or right) working as they are ordered according to rotation
        // and thus, we simply add or subtract 1 to turn one way or the other, always respecting the order.
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }
}
