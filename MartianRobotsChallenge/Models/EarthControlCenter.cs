using System.Collections.Generic;

namespace MartianRobotsChallenge.Models
{
    public class EarthControlCenter
    {
        public List<Robot> Robots { get; set; }

        public EarthControlCenter(List<Robot> robots)
        {
            Robots = robots;
        }

        public void CreateRobot(Robot robot)
        {
            Robots.Add(robot);
        }

        public void ControlRobot(int currentRobot, List<RobotInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                Robots[currentRobot].ExecuteInstruction(instruction);
            }
        }
    }
}
