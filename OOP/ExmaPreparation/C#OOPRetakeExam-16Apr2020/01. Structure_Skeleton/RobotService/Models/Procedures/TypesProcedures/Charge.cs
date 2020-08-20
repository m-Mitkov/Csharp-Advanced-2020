

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.TypesProcedures
{
    public class Charge : Procedure
    {
        private const int extraEnergy = 10;
        private const int extraHappiness = 12;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness += extraHappiness;
            robot.Energy += extraEnergy;
        }
    }
}
