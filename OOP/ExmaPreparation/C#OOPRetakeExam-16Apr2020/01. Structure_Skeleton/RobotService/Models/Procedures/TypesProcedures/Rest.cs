using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.TypesProcedures
{
    public class Rest : Procedure
    {
        private const int lostHappiness = 3;
        private const int extraEnergy = 10;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= lostHappiness;
            robot.Energy += extraEnergy;
        }
    }
}
