using System;
using System.Linq;

namespace MarsRoverApp
{
    class StartPositionValidaton : IInputValidation
    {
        private string[] startPosition;
        string[] directions = { "N", "S", "E", "W" };
        Plateau plateau = new Plateau();

        public StartPositionValidaton(string[] startPositionInput, Plateau plateauValues)
        {
            startPosition = startPositionInput;
            plateau = plateauValues;
        }

        public bool isValidInput()
        {
            if (startPosition == null || startPosition.Count() != 3)
            {
                return false;
            }

            var number = 0;
            if ((int.TryParse(startPosition[0], out number)) == false)
            {
                throw new Exception("The starting coordinates must be integer values!");
            }
            else if (number > plateau.width)
            {
                throw new Exception("The starting X point can not be bigger than plateau's width!");
            }

            if ((int.TryParse(startPosition[1], out number)) == false)
            {
                throw new Exception("The starting coordinates must be integer values!");
            }
            else if (number > plateau.height)
            {
                throw new Exception("The starting Y point can not be bigger than plateau's height!");
            }


            if (!directions.Contains(startPosition[2]))
            {
                throw new Exception("Starting position's direction must contain 'N' or 'S' or 'E' or 'W'!");
            }
            return true;
        }
    }
}
