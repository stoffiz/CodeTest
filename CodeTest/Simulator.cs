using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    class Simulator
    {
        private int[,] RoomSize { get; set; }
        private string Commands { get; set; }

        private Car Car { get; set; }

        private bool CarDroveIntoWall { get; set; }

        public Simulator(int roomSizeX, int roomsizeY, string commands, Car car)
        {
            RoomSize = new int[roomSizeX, roomsizeY];
            Commands = commands;
            Car = car;            
        }

        public void Drive()
        {
            
            for (int i = 0; i < Commands.Count(); i++)
            {
                char singleCommand = Commands[i];
                if(singleCommand == 'R')
                {
                    TurnRight();
                }
                
                if (singleCommand == 'L')
                {
                    TurnLeft();
                }

                if (singleCommand == 'F')
                {
                    MoveForward();
                }

                if (singleCommand == 'B')
                {
                    MoveBack();
                }
            }
            Console.WriteLine(PrintMessage());
        }

        public void MoveForward()
        {

            switch(Car.GetDirection())
            {
                case "N":
                    Car.SetCurrentPositionY(Car.GetCurrentPositionY() + 1);
                    CarDroveIntoWall = CheckCarDroveIntoWall(Car.GetCurrentPositionX(), Car.GetCurrentPositionY());
                    break;
                case "E":
                    Car.SetCurrentPositionX(Car.GetCurrentPositionX() + 1);
                    CarDroveIntoWall = CheckCarDroveIntoWall(Car.GetCurrentPositionX(), Car.GetCurrentPositionY());
                    break;
                case "S":
                    Car.SetCurrentPositionY(Car.GetCurrentPositionY() - 1);
                    CarDroveIntoWall = CheckCarDroveIntoWall(Car.GetCurrentPositionX(), Car.GetCurrentPositionY());
                    break;
                case "W":
                    Car.SetCurrentPositionX(Car.GetCurrentPositionX() - 1);
                    CarDroveIntoWall = CheckCarDroveIntoWall(Car.GetCurrentPositionX(), Car.GetCurrentPositionY());
                    break;
            }
        }

        public void MoveBack()
        {

            switch (Car.GetDirection())
            {
                case "N":
                    Car.SetCurrentPositionY(Car.GetCurrentPositionY() - 1);
                    CarDroveIntoWall = CheckCarDroveIntoWall(Car.GetCurrentPositionX(), Car.GetCurrentPositionY());
                    break;
                case "E":
                    Car.SetCurrentPositionX(Car.GetCurrentPositionX() - 1);
                    CarDroveIntoWall = CheckCarDroveIntoWall(Car.GetCurrentPositionX(), Car.GetCurrentPositionY());
                    break;
                case "S":
                    Car.SetCurrentPositionY(Car.GetCurrentPositionY() + 1);
                    CarDroveIntoWall = CheckCarDroveIntoWall(Car.GetCurrentPositionX(), Car.GetCurrentPositionY());
                    break;
                case "W":
                    Car.SetCurrentPositionX(Car.GetCurrentPositionX() + 1);
                    CarDroveIntoWall = CheckCarDroveIntoWall(Car.GetCurrentPositionX(), Car.GetCurrentPositionY());
                    break;
            }
        }

        public void TurnRight()
        {
            switch(Car.GetDirection())
            {
                case "N":
                    Car.SetDirection("E");
                    break;
                case "E":
                    Car.SetDirection("S");
                    break;
                case "S":
                    Car.SetDirection("W");
                    break;
                case "W":
                    Car.SetDirection("N");
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (Car.GetDirection())
            {
                case "N":
                    Car.SetDirection("W");
                    break;
                case "W":
                    Car.SetDirection("S");
                    break;
                case "S":
                    Car.SetDirection("E");
                    break;
                case "E":
                    Car.SetDirection("N");
                    break;
            }
        }


        public bool CheckCarDroveIntoWall(int positionX, int positionY)
        {
            if(positionX > RoomSize.GetLength(0) || positionX < 0)
            {
                return true;
            }

            if(positionY > RoomSize.GetLength(1) || positionY < 0)
            {
                return true;
            }

            return false;
        }

        public String PrintMessage()
        {
            if(!CarDroveIntoWall)
            {
                return $"Success! End position {Car.GetCurrentPositionX()} {Car.GetCurrentPositionY()} heading {Car.GetDirection()}";
            }
            else
            {

                return $"Not a success! Car crashed into the wall at position {Car.GetCurrentPositionX()} {Car.GetCurrentPositionY()} heading {Car.GetDirection()}";
            }
        }

    }
}
