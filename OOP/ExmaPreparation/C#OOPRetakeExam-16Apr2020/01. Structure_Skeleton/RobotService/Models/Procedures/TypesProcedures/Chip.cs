using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures.TypesProcedures
{
    public class Chip : Procedure
    {
        private const int lostHappiness = 5;

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.IsChipped)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }

            base.DoService(robot, procedureTime);

            robot.IsChipped = true;
            robot.Happiness -= lostHappiness; 
        }
    }
}
