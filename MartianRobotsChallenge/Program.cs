using Application;
using MartianRobotsChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobotsChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("##################################################");
            Console.WriteLine("#                                                #");
            Console.WriteLine("#  Welcome to the Martian Robots Command Center. #");
            Console.WriteLine("#                                                #");
            Console.WriteLine("#           Project by Thomas Day                #");
            Console.WriteLine("#            DCSL GuideSmiths Ltd                #");
            Console.WriteLine("#                                                #");
            Console.WriteLine("##################################################");


            // Read user input
            var allInput = InputHandler.ReadInput();

            List<Robot> robots;
            List<List<RobotInstruction>> robotInstructions;
            InputHandler.DeployRobot(allInput, out robots, out robotInstructions);
                       

            var commandCenter = new EarthControlCenter(robots);
            for (int i = 0; i < commandCenter.Robots.Count; i++)
                commandCenter.ControlRobot(i, robotInstructions[i]);

            var outputReport = OutputHandler.GenerateOuputReport(robots);
            Console.Write(outputReport);
        }
    }
}
