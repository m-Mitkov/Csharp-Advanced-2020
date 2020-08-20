using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.TypesProcedures
{
    public class TechCheck : Procedure
    {
        private const int lostEnergy = 8;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (!robot.IsChecked)
            {
                robot.IsChecked = true;
                robot.Energy -= lostEnergy;
            }

            else
            {
                robot.Energy -= lostEnergy;
            }
        }
    }
}
