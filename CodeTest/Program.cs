using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var sizeOfRoom = SizeOfRoom();
            var car = StartingPositionAndHeading(sizeOfRoom[0], sizeOfRoom[1]);
            var commands = UserCommandsToExecute();
            Simulator simulator = new Simulator(sizeOfRoom[0], sizeOfRoom[1], commands, car);
            simulator.Drive();
       
        }

        public static int[] SizeOfRoom()
        {
            int roomSizeX;
            int roomSizeY;

            int[] valuesToReturn = new int[2];
            bool watingOnCorrectInput = true;

            while(watingOnCorrectInput)
            {
                Console.WriteLine("Enter room size (e.g. 4 8):");
                string[] userInput = Console.ReadLine().Split(' ');

                if(userInput.Length == 2)
                {
                    try
                    {
                        roomSizeX = int.Parse(userInput[0]);
                        roomSizeY = int.Parse(userInput[1]);

                        if (roomSizeX >= 1 && roomSizeY >= 1)
                        {
                            valuesToReturn[0] = roomSizeX;
                            valuesToReturn[1] = roomSizeY;
                            watingOnCorrectInput = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter a value greater than 0");
                        }
                    }
                    catch (FormatException error)
                    {
                        Console.WriteLine(error.Message);
                    }
                } else
                {
                    Console.WriteLine("Wrong number of parameters");
                }

            }

            return valuesToReturn;

        }

        public static Car StartingPositionAndHeading(int roomSizeX, int roomSizeY)
        {

            int startingPositionX;
            int startingPositionY;
            string heading;
            bool watingOnCorrectInput = true;
            Car car = null;

            while(watingOnCorrectInput)
            {
                Console.WriteLine("Enter starting position and heading (e.g. 4 8 N):");
                string[] userInput = Console.ReadLine().Split(' ');

                if(userInput.Length == 3)
                {
                    try
                    {
                        startingPositionX = int.Parse(userInput[0]);
                        startingPositionY = int.Parse(userInput[1]);
                        heading = userInput[2].ToUpper();

                        if(startingPositionX <= roomSizeX && startingPositionX >= 0 && startingPositionY <= roomSizeY && startingPositionY >= 0)
                        {
                            if(heading == "N" || heading == "S" || heading == "W" || heading == "E")
                            {
                                car = new Car("Monster Truck", heading, startingPositionX, startingPositionY);
                                watingOnCorrectInput = false;
                            } else
                            {
                                Console.WriteLine("Characters allowed: N S W or E");
                            }
                        } else
                        {
                            Console.WriteLine("Car is out of bounds. Try again.");
                        }

                    } catch(FormatException error)
                    {
                        Console.WriteLine(error.Message);
                    }
                } else
                {
                    Console.WriteLine("Wrong number of parameters");
                }
                
            }

            return car;
        }

        public static string UserCommandsToExecute()
        {
            string commands = "";
            bool watingOnCorrectInput = true;

            while(watingOnCorrectInput)
            {
                Console.WriteLine("Enter one or several of the following commands to drive the car: F, B, L or R");
                commands = Console.ReadLine().ToUpper();

                for(int i = 0; i < commands.Count(); i++)
                {
                    char characters = commands[i];
                    if (characters != 'F' && characters != 'B' && characters != 'L' && characters != 'R')
                    {
                        Console.WriteLine("Commands allowed: F, B, L or R");
                        watingOnCorrectInput = true;
                        break;
                    }
                    else
                    {
                        watingOnCorrectInput = false;
                    }
                }
            }

            return commands;
        }
    }
}
