using MartianRobotsChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public static class InputHandler
    {
        public const int MaxInstructionsLength = 100;
        public const int MaxCoordinateSize = 50;

        public static string ReadInput()
        {
            Console.WriteLine("Instruct, and then press CTRL + Z then ENTER on a New Line to Continue execution");

            var instructions = new StringBuilder();
            string currentLine = string.Empty;

            do
            {
                currentLine = Console.ReadLine();

                if (currentLine != null)
                    instructions.AppendLine(currentLine);

            } while (currentLine != null);

           return instructions.ToString();
        }

        public static void DeployRobot(string rawInput, out List<Robot> robots, out List<List<RobotInstruction>> instructions)
        {
            string[] inputArray = rawInput.Trim().Split(Environment.NewLine);
            robots = new List<Robot>();
            instructions = new List<List<RobotInstruction>>();

            var marsCoordinates = SetMarsDimensions(inputArray[0]);

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (i % 2 == 0)
                    instructions.Add(ParseRobotInstructions(inputArray[i]));
                else
                    robots.Add(ParseRobotPositions(inputArray[i], marsCoordinates));
            }
        }

        public static Robot ParseRobotPositions(string position, Mars mars)
        {
            // 1 1 E
            // 3 2 N
            // 0 3 W
            var firstLineRobotPositions = position.Split(' ');

            int robotCoordinateX = int.Parse(firstLineRobotPositions[0]);
            int robotCoordinateY = int.Parse(firstLineRobotPositions[1]);

            var robotCoordinates = new Coordinate(robotCoordinateY, robotCoordinateX);

            if (!IsCoordinateLegal(robotCoordinates))
                throw new ArgumentException($"Invalid coordinates size must not be greater than {MaxCoordinateSize}");

            var robotOrientation = ConvertInputToOrientationEnum(firstLineRobotPositions[2]);

            return new Robot(robotCoordinates, robotOrientation, mars);
        }

        public static List<RobotInstruction> ParseRobotInstructions(string instructions)
        {
            if (instructions.Length > MaxInstructionsLength)
            {
                throw new ArgumentException($"Too many instructions. You may only instruct {MaxInstructionsLength} at a time");
            }

            var instructionsList = new List<RobotInstruction>();

            foreach (var instruction in instructions)
            {
                instructionsList.Add(ConvertInputToRobotInstructionEnum(instruction));
            }

            return instructionsList;
        }

        public static Mars SetMarsDimensions(string coordinates)
        {
            var marsStringCoordinates = coordinates.Split(' ');

            int marsPosX = int.Parse(marsStringCoordinates[0]);
            int marsPosY = int.Parse(marsStringCoordinates[1]);
            
            var marsCoordinates = new Coordinate(marsPosX, marsPosY);

            if (!IsCoordinateLegal(marsCoordinates))
                throw new ArgumentException($"Invalid coordinates size must not be greater than {MaxCoordinateSize}");

            return new Mars(marsCoordinates);
        }

        public static Orientation ConvertInputToOrientationEnum(string orientationInput)
        {
            return orientationInput switch
            {
                "N" => Orientation.North,
                "E" => Orientation.East,
                "S" => Orientation.South,
                "W" => Orientation.West,
                _ => throw new ArgumentException("The provided orientation is not valid."),
            };
        }

        public static RobotInstruction ConvertInputToRobotInstructionEnum(char instructionInput)
        {
            return instructionInput switch
            {
                'L' => RobotInstruction.Left,
                'R' => RobotInstruction.Right,
                'F' => RobotInstruction.Forward,
                _ => throw new ArgumentException("The provided orientation is not valid."),
            };
        }

        private static bool IsCoordinateLegal(Coordinate coordinate)
        {
            if (coordinate.X > MaxCoordinateSize || coordinate.Y < MaxCoordinateSize)
                return false;

            return true;
        }

    }
}
