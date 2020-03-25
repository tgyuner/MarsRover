using MarsRover.Enums;
using MarsRover.Facade;
using MarsRover.Models;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        // Tugay ÜNER 
        // https://github.com/tgyuner
        // https://www.codewars.com/users/tgyuner

        static void Main(string[] args)
        {
            Console.WriteLine("Values are filled automatically.");

            RoverFacade roverFacade = RoverFacade.GetInstance();

            var squarerRequest = new RoverRequest
            {
                Square = new SquareModel
                {
                    PositionX = 5,
                    PositionY = 5
                },
                RoverModels = new List<RoverModel>
                {
                    new RoverModel
                    {
                        StartPosition = new StartPosition
                        {
                            PositionX = 1,
                            PositionY = 2,
                            Compass = Compass.North
                        },
                        CommandList = new List<Command>{(Command.L), (Command.M) , (Command.L) , (Command.M), (Command.L), (Command.M), (Command.L), (Command.M), (Command.M) }
                    },
                    new RoverModel
                    {
                        StartPosition = new StartPosition
                        {
                            PositionX = 3,
                            PositionY = 3,
                            Compass = Compass.East
                        },
                        CommandList = new List<Command>{(Command.M), (Command.M) , (Command.R) , (Command.M), (Command.M), (Command.R), (Command.M), (Command.R), (Command.R), (Command.M) }
                    }
                }
            };

            var square = new List<int> { squarerRequest.Square.PositionX, squarerRequest.Square.PositionY + 1 };

            foreach (var rover in squarerRequest.RoverModels)
            {
                var result = roverFacade.RoverMoveIt(rover, square);

                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}
