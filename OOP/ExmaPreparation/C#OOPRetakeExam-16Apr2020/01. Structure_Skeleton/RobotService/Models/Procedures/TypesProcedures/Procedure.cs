using System.Text;
using System.Collections.Generic;
using RobotService.Models.Robots.Contracts;
using System;
using RobotService.Utilities.Messages;
using RobotService.Models.Procedures.Contracts;

namespace RobotService.Models.Procedures.TypesProcedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IRobot> Robots;

        protected Procedure()
        {
            this.Robots = new List<IRobot>();
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType()}");

            foreach (var robot in Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InsufficientProcedureTime));
            }

            robot.ProcedureTime -= procedureTime;
            this.Robots.Add(robot);
        }
    }
}
