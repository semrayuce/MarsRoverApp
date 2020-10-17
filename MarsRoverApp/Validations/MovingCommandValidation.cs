using System;
using System.Linq;

namespace MarsRoverApp
{
    class MovingCommandValidaton : IInputValidation
    {
        private char[] movingCommands;
        private char[] commands = { 'L', 'R', 'M' };

        public MovingCommandValidaton(char[] movingCommandInput)
        {
            movingCommands = movingCommandInput;
        }

        public bool isValidInput()
        {
            if (movingCommands == null || !movingCommands.Any())
            {
                throw new Exception("Commands cannot be empty!");
            }

            foreach (char command in movingCommands)
            {
                if (!commands.Contains(command))
                {
                    throw new Exception("Commands must contain 'L' or 'R' or 'M'!");
                }
            }

            return true;
        }
    }
}
