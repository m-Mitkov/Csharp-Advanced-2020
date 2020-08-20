﻿using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService
{
    public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;

        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }

        public string Name { get; }
        public int Happiness
        {
            get { return happiness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHappiness));
                }

                this.happiness = value;
            }
        }
        public int Energy
        {
            get { return energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidEnergy));
                }

                this.energy = value;
            }
        }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; } = "Service";
        public bool IsBought { get; set; } = false;
        public bool IsChipped { get; set; } = false;
        public bool IsChecked { get; set; } = false;

        public override string ToString()
        {
            return $" Robot type: {GetType().Name} - {this.Name} - " +
                $"Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
