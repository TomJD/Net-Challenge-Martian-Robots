using MartianRobotsChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public static class OutputHandler
    {
        public static string GenerateOuputReport(List<Robot> robots)
        {
            var fullOutputReport = new StringBuilder();

            foreach (var robot in robots)
            {
                var outputLine = $"{robot.Coordinates.X} {robot.Coordinates.Y} {GetOrientation(robot.Orientation)}";

                if (robot.IsLost)
                {
                    outputLine += " LOST";
                }

                fullOutputReport.Append(outputLine + Environment.NewLine);
            }

            return fullOutputReport.ToString();
        }

        private static char GetOrientation(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.North:
                    return 'N';
                case Orientation.South:
                    return 'S';
                case Orientation.East:
                    return 'E';
                case Orientation.West:
                    return 'W';
                default:
                    throw new ArgumentException($"orientation {orientation} has no defined char equivalent");
            }
        }
    }
}
