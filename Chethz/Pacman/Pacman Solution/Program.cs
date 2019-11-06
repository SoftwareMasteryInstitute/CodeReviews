using System;
using PacmanLibrary;

namespace Pacman_Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid(5, 5);
            Pacman pacman = new Pacman();
            Simulator simulator = new Simulator(pacman, grid);

            try
            {
                simulator.UserInput("PLACE 0, 0, NORTH");
                simulator.UserInput("MOVE");
                simulator.UserInput("REPORT");

                simulator.UserInput("PLACE 0, 0, NORTH");
                simulator.UserInput("LEFT");
                simulator.UserInput("REPORT");

                simulator.UserInput("PLACE 1, 2, EAST");
                simulator.UserInput("MOVE");
                simulator.UserInput("MOVE");
                simulator.UserInput("LEFT");
                simulator.UserInput("MOVE");
                simulator.UserInput("REPORT");
                Console.ReadLine();
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine("ERROR :" + e.Message);
            }
            catch (InvalidInitializedException e)
            {
                Console.WriteLine("ERROR :" + e.Message);
            }
            catch (InvalidCoordinatesException e)
            {
                Console.WriteLine("ERROR :" + e.Message);
            }
        }
    }
}
