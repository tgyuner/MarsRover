using System;
using System.Linq;
using MarsRover.Enums;
using MarsRover.Models;
using System.Collections.Generic;

namespace MarsRover.Facade
{
    /// <summary>
    /// The rover facade
    /// </summary>
    public class RoverFacade
    {
        private static RoverFacade _instance;

        private RoverFacade()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static RoverFacade GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RoverFacade();
            }

            return _instance;
        }

        private CommandDetailConstant CommandRuleOperator(CommandDetailConstant commandDetail, Command command)
        {
            switch (commandDetail)
            {
                case CommandDetailConstant.YPositive:
                    switch (command)
                    {
                        case Command.R:
                            return CommandDetailConstant.XPositive;
                        case Command.L:
                            return CommandDetailConstant.XNegative;
                    }
                    break;
                case CommandDetailConstant.YNegative:
                    switch (command)
                    {
                        case Command.R:
                            return CommandDetailConstant.XNegative;
                        case Command.L:
                            return CommandDetailConstant.XPositive;
                    }
                    break;
                case CommandDetailConstant.XPositive:
                    switch (command)
                    {
                        case Command.R:
                            return CommandDetailConstant.YNegative;
                        case Command.L:
                            return CommandDetailConstant.YPositive;
                    }
                    break;
                case CommandDetailConstant.XNegative:
                    switch (command)
                    {
                        case Command.R:
                            return CommandDetailConstant.YPositive;
                        case Command.L:
                            return CommandDetailConstant.YNegative;
                    }
                    break;
                case CommandDetailConstant.Move:
                    switch (command)
                    {
                        case Command.M:
                            return CommandDetailConstant.Move;
                    }
                    break;
            }

            return CommandDetailConstant.Move;
        }

        private void CommandActionMove(CurrentMoment currentMoment, int process, ref List<int> square)
        {
            switch (currentMoment.Type)
            {
                case CommandDetailConstant.XNegative:
                    var sumXN = currentMoment.X + process;
                    if (sumXN >= 0 && sumXN < square.FirstOrDefault())
                    {
                        currentMoment.X = sumXN;
                    }
                    break;
                case CommandDetailConstant.XPositive:
                    var sumXP = currentMoment.X + process;
                    if (sumXP >= 0 && sumXP <= square.FirstOrDefault())
                    {
                        currentMoment.X = sumXP;
                    }
                    break;
                case CommandDetailConstant.YNegative:
                    var sumYN = currentMoment.Y + process;
                    if (sumYN >= 0 && sumYN < square.LastOrDefault())
                    {
                        currentMoment.Y = sumYN;
                    }
                    break;
                case CommandDetailConstant.YPositive:
                    var sumYP = currentMoment.Y + process;
                    if (sumYP >= 0 && sumYP < square.LastOrDefault())
                    {
                        currentMoment.Y = sumYP;
                    }
                    break;
            }
        }

        private void CommandActionLeftRight(CurrentMoment currentMoment, out int process)
        {
            switch (currentMoment.Type)
            {
                case CommandDetailConstant.XNegative:
                    process = -1;
                    break;
                case CommandDetailConstant.XPositive:
                    process = +1;
                    break;
                case CommandDetailConstant.YNegative:
                    process = -1;
                    break;
                case CommandDetailConstant.YPositive:
                    process = +1;
                    break;
                default:
                    process = 0;
                    break;
            }
        }

        private Compass FindDirection(CommandDetailConstant commandDetail)
        {
            switch (commandDetail)
            {
                case CommandDetailConstant.YPositive:
                    return Compass.North;
                case CommandDetailConstant.YNegative:
                    return Compass.South;
                case CommandDetailConstant.XNegative:
                    return Compass.West;
                case CommandDetailConstant.XPositive:
                    return Compass.East;
                default: return Compass.North;
                    // Pusula daima kuzeyi gösterir :)
                    // The compass always points north.
            }
        }

        private CommandDetailConstant FindAxis(Compass compass, out int process)
        {
            switch (compass)
            {
                case Compass.North:
                    process = +1;
                    return CommandDetailConstant.YPositive;
                case Compass.South:
                    process = -1;
                    return CommandDetailConstant.YNegative;
                case Compass.West:
                    process = -1;
                    return CommandDetailConstant.XNegative;
                case Compass.East:
                    process = +1;
                    return CommandDetailConstant.XPositive;
                default:
                    process = 0;
                    return CommandDetailConstant.Move;
            }
        }

        /// <summary>
        /// Rovers the move it.
        /// </summary>
        /// <param name="rover">The rover.</param>
        /// <param name="square">The square.</param>
        /// <returns></returns>
        public string RoverMoveIt(RoverModel rover, List<int> square)
        {
            var currentMoment = new CurrentMoment();
            int process;

            currentMoment.Type = FindAxis(rover.StartPosition.Compass, out process);

            currentMoment.X = rover.StartPosition.PositionX;
            currentMoment.Y = rover.StartPosition.PositionY;

            foreach (var command in rover.CommandList)
            {
                var returnCommand = CommandRuleOperator(currentMoment.Type, command);
                if (command != Command.M)
                {
                    currentMoment.Type = returnCommand;
                    CommandActionLeftRight(currentMoment, out process);
                }
                else
                {
                    CommandActionMove(currentMoment, process, ref square);
                }
            }

            // Compass
            var findDirection = FindDirection(currentMoment.Type);

            rover.StartPosition.PositionX = currentMoment.X;
            rover.StartPosition.PositionY = currentMoment.Y;
            rover.StartPosition.Compass = findDirection;

            // Ekranada yazdırabilirdim ama test methodunu kullanabilmek için string döndürüyorum.
            return (rover.StartPosition.PositionX + " " + rover.StartPosition.PositionY + " " + rover.StartPosition.Compass);
        }
    }
}