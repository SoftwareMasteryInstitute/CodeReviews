using System;
using System.Text.RegularExpressions;
using PacmanLibrary;

namespace Pacman_Solution
{
    public class Simulator
    {
        private Pacman _pacman;
        private Grid _grid;

        public Simulator(Pacman pacman, Grid grid)
        {
            _pacman = pacman;
            _grid = grid;
        }


        //Process user inputs
        public void UserInput(string input)
        {
            string commands = input.Trim().ToUpper();

            Regex place = new Regex(@"^PLACE ");
            Regex move = new Regex(@"^MOVE$");
            Regex left = new Regex(@"^LEFT$");
            Regex right = new Regex(@"^RIGHT$");
            Regex report = new Regex(@"^REPORT$");


            if (place.IsMatch(commands))
            {
                ProcessPlace(commands);
            }
            else if (move.IsMatch(commands))
            {
                _pacman.Move();
            }
            else if (left.IsMatch(commands))
            {
                _pacman.Left();
            }
            else if (right.IsMatch(commands))
            {
                _pacman.Right();
            }
            else if (report.IsMatch(commands))
            {
                Console.WriteLine(_pacman.Report());
            }
            else
            {
                throw new InvalidInputException("Invalid command");
            }
        }

        //######### Methods for Processing Inputs ##########

        private void ProcessPlace(string command)
        {
            string[] coordinate = command.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (coordinate.Length == 4)
            {
                int x;
                int y;

                if (int.TryParse(coordinate[1], out x) && int.TryParse(coordinate[2], out y) && coordinate[3] != null)
                {
                    PlacePacman(x, y, coordinate[3]);
                }
                else
                {
                    throw new InvalidInputException("Invalid input format");
                }
            }
            else
            {
                throw new InvalidInputException("Invalid input format");
            }
        }

        //Check if the face is valid
        //if true create new pacman with given coordinate
        private void PlacePacman(int x, int y, string face)
        {
            Directions.Face direction = Directions.IsValidFace(face);
            //_pacman.Grid = _grid;
            _pacman.Place(_grid, x, y, direction);
        }
    }
}