using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots.TypesRobots
{
    public class HouseholdRobot : Robot
    {
        public HouseholdRobot(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }
    }
}
