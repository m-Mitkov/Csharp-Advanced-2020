using RobotService.Core.Contracts;
using RobotService.Models.Garages.Garage;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Robots.TypesRobots;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using RobotService.Models.Procedures.TypesProcedures;
using RobotService.Models.Procedures.Contracts;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage;
        private Dictionary<IProcedure, IRobot> historyDatabase;

        public Controller()
        {
            this.garage = new Garage();
            this.historyDatabase = new Dictionary<IProcedure, IRobot>();
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotToDoProcedure(robotName);
            Procedure procedure = new Charge();
            procedure.DoService(robot, procedureTime);
            AddProcedureToRobot(robotName, procedureTime, procedure);

            return String.Format(OutputMessages.ChargeProcedure, robot.Name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotToDoProcedure(robotName);
            Procedure procedure = new Chip();
            procedure.DoService(robot, procedureTime);
            AddProcedureToRobot(robotName, procedureTime, procedure);

            return String.Format(OutputMessages.ChipProcedure, robot.Name);
        }

        public string History(string procedureType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(procedureType);

            foreach (var (procedure, robot) in historyDatabase)
            {
                if (procedure.GetType().Name.Equals(procedureType))
                {
                    sb.AppendLine(String.Format(OutputMessages.RobotInfo, robot.GetType().Name, robot.Name, robot.Happiness, robot.Energy));
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;

            if (robotType == nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }

            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }

            else if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }

            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            garage.Manufacture(robot);
            return String.Format(OutputMessages.RobotManufactured, robot.Name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotToDoProcedure(robotName);
            Procedure procedure = new Polish();
            procedure.DoService(robot, procedureTime);
            AddProcedureToRobot(robotName, procedureTime, procedure);

            return String.Format(OutputMessages.PolishProcedure, robot.Name);
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotToDoProcedure(robotName);
            Procedure procedure = new Rest();
            procedure.DoService(robot, procedureTime);
            AddProcedureToRobot(robotName, procedureTime, procedure);

            return String.Format(OutputMessages.RestProcedure, robot.Name);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robotToSell = garage.Robots.GetValueOrDefault(robotName);

            if (robotToSell != default)
            {
                garage.Sell(robotName, ownerName);
            }

            if (robotToSell.IsChipped)
            {
                return String.Format(OutputMessages.SellChippedRobot, ownerName);
            }

            else
            {
                return String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotToDoProcedure(robotName);
            Procedure procedure = new TechCheck();
            procedure.DoService(robot, procedureTime);
            AddProcedureToRobot(robotName, procedureTime, procedure);

            return String.Format(OutputMessages.TechCheckProcedure, robot.Name);
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotToDoProcedure(robotName);
            Procedure procedure = new Work();
            procedure.DoService(robot, procedureTime);
            AddProcedureToRobot(robotName, procedureTime, procedure);

            return String.Format(OutputMessages.WorkProcedure, robot.Name, procedureTime);
        }

        private IRobot GetRobotToDoProcedure(string robotName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots.GetValueOrDefault(robotName);

            return robot;
        }

        private void AddProcedureToRobot(string robotName, int procedureTime, IProcedure procedure)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots.GetValueOrDefault(robotName);
            historyDatabase.Add(procedure, robot);
        }
    }
}
