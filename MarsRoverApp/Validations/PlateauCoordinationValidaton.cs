using System;
using System.Linq;

namespace MarsRoverApp
{
    class PlateauCoordinationValidaton : IInputValidation
    {
        private string[] coordinate;

        public PlateauCoordinationValidaton(string[] coordinateInput)
        {
            coordinate = coordinateInput;
        }

        public bool isValidInput()
        {
            if (coordinate == null || coordinate.Count() != 2)
            {
                throw new Exception("Plateau coordinates cannot be empty!");
            }

            foreach (string input in coordinate)
            {
                var number = 0;
                if ((int.TryParse(input, out number)) == false)
                {
                    throw new Exception("Plateau coordinates must be integer values!");
                }
            }

            return true;
        }
    }
}
