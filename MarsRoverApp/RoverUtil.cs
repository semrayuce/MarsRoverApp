using System;

namespace MarsRoverApp
{
    public class RoverUtil
    {
        public bool CheckIfPositionExist(Plateau plateau, int X, int Y)
        {
            if (X > plateau.width || Y > plateau.height || X < 0 || Y < 0) {
                throw new Exception("The position out of plateau coordinates!");
            }
            return true;
        }
    }
}
