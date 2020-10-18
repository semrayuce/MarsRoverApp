using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean isNewRover = true;
            var plateauPoints = Console.ReadLine().Trim().Split(' ');
            Plateau plateau = new Plateau();
            PlateauCoordinationValidaton plateauCoordinationValidaton = new PlateauCoordinationValidaton(plateauPoints.ToArray());
            if (plateauCoordinationValidaton.isValidInput())
            {
                plateau.width = Convert.ToInt16(plateauPoints[0]);
                plateau.height = Convert.ToInt16(plateauPoints[1]);
                plateau.rovers = new List<Rover>();
            }

            while (isNewRover)
            {
                var startPositions = Console.ReadLine().Trim().Split(' ');
                Rover rover = new Rover();
                StartPositionValidaton startPositionValidaton = new StartPositionValidaton(startPositions, plateau);
                if (startPositionValidaton.isValidInput())
                {
                    rover.X = Convert.ToInt16(startPositions[0]);
                    rover.Y = Convert.ToInt16(startPositions[1]);
                    rover.direction = (DirectionsEnum)Enum.Parse(typeof(DirectionsEnum), startPositions[2]);
                }
                plateau.rovers.Add(rover);
                var movingCommands = Console.ReadLine().ToUpper().ToCharArray();
                MovingCommandValidaton movingCommandValidaton = new MovingCommandValidaton(movingCommands);
                if (movingCommandValidaton.isValidInput())
                {
                    rover.StartMoving(plateau, movingCommands);
                }

                Console.WriteLine("Do you want to go on with new rover? Please select Y or N");
                isNewRover = Console.ReadLine() == "Y" ? true : false;
            }

            foreach (Rover rover in plateau.rovers)
            {
                Console.WriteLine($"{rover.X} {rover.Y} {rover.direction.ToString()}");
            }
        }
    }
}
