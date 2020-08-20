using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.TypesProcedures
{
    public class Polish : Procedure
    {
        private const int lostHappiness = 7;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= lostHappiness;
        }
    }
}
