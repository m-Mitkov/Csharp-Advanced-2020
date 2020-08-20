using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.TypesProcedures
{
    public class Work : Procedure
    {
        private const int lostEnergy = 6;
        private const int extraHappyness = 12;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= lostEnergy;
            robot.Happiness += extraHappyness;
        }
    }
}
