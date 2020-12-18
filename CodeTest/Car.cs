using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    public class Car
    {
        private string CarModel { get; set; }
        private string Direction {get; set; }
        private int CurrentPositionX { get; set; }
        private int CurrentPositionY { get; set; }

        public Car(string carModel, string direction, int currentPositionX, int currentPositionY)
        {

            CarModel = carModel;
            Direction = direction;
            CurrentPositionX = currentPositionX;
            CurrentPositionY = currentPositionY;
            
        }

        public int GetCurrentPositionX()
        {
            return CurrentPositionX;
        }

        public void SetCurrentPositionX(int currentPositionX)
        {
            CurrentPositionX = currentPositionX;
        }

        public int GetCurrentPositionY()
        {
            return CurrentPositionY;
        }

        public void SetCurrentPositionY(int currentPositionY)
        {
            CurrentPositionY = currentPositionY;
        }

        public string GetDirection()
        {
            return Direction;
        }

        public void SetDirection(string direction)
        {
            Direction = direction;
        }



    }
}
