using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using RobotService.Utilities.Messages;
using System.Linq;

namespace RobotService.Models.Garages.Garage  
{
    public class Garage : IGarage
    {
        private const int capacity = 10;
        private Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots => robots;

        public int Capacity => capacity;

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count >= this.Capacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughCapacity));
            }

            else if (robots.Any(x => x.Key == robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            else
            {
                robots.Add(robot.Name, robot);
            }
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.Any(X => X.Key == robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            else
            {
                IRobot robot = robots.First(x => x.Key == robotName).Value;
                robot.Owner = ownerName;
                robot.IsBought = true;
                robots.Remove(robotName);
            }
        }
    }
}
