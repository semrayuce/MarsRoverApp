using System.Collections.Generic;

namespace MarsRoverApp
{
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionsEnum direction { get; set; }
        RoverUtil roverUtil = new RoverUtil();

        public Rover()
        {
            X = Y = 0;
            direction = DirectionsEnum.N;
        }

        private void Rotate90DegreeToLeft()
        {
            switch (this.direction)
            {
                case DirectionsEnum.N:
                    this.direction = DirectionsEnum.W;
                    break;
                case DirectionsEnum.S:
                    this.direction = DirectionsEnum.E;
                    break;
                case DirectionsEnum.E:
                    this.direction = DirectionsEnum.N;
                    break;
                case DirectionsEnum.W:
                    this.direction = DirectionsEnum.S;
                    break;
                default:
                    break;
            }
        }

        private void Rotate90DegreeToRight()
        {
            switch (this.direction)
            {
                case DirectionsEnum.N:
                    this.direction = DirectionsEnum.E;
                    break;
                case DirectionsEnum.S:
                    this.direction = DirectionsEnum.W;
                    break;
                case DirectionsEnum.E:
                    this.direction = DirectionsEnum.S;
                    break;
                case DirectionsEnum.W:
                    this.direction = DirectionsEnum.N;
                    break;
                default:
                    break;
            }
        }

        private void KeepGoingSameDirection(Plateau plateau)
        {
            switch (this.direction)
            {
                case DirectionsEnum.N:
                    this.Y += 1;
                    break;
                case DirectionsEnum.S:
                    this.Y -= 1;
                    break;
                case DirectionsEnum.E:
                    this.X += 1;
                    break;
                case DirectionsEnum.W:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
            roverUtil.CheckIfPositionExist(plateau, this.X, this.Y);
        }

        public void StartMoving(Plateau plateau, char[] commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'M':
                        this.KeepGoingSameDirection(plateau);
                        break;
                    case 'L':
                        this.Rotate90DegreeToLeft();
                        break;
                    case 'R':
                        this.Rotate90DegreeToRight();
                        break;
                }

            }
        }
    }
}
