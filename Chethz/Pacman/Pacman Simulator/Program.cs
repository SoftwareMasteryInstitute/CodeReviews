using System;

namespace Pacman_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator simulator = new Simulator(5,5);
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
            catch (Exception e)
            {
                Console.WriteLine("ERROR :" + e.Message);
            }
        }
    }
}
