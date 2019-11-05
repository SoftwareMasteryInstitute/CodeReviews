using System;
using System.Text.RegularExpressions;
using PacmanLibrary;

namespace Pacman_Simulator
{
    public class Simulator
    {
        private Pacman _pacman;
        private Grid _grid;

        //Constructor
        public Simulator(int width, int length)
        {
            _grid = new Grid(width, length);
            _pacman = new Pacman();
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
            Directions.Face direction = GetFace(face);
            _pacman.Grid = _grid;
            _pacman.Place(x, y, direction);
        }

        //Return face if input is a valid input
        private Directions.Face GetFace(string face)
        {
            if (!Enum.IsDefined(typeof(Directions.Face), face)) throw new InvalidInputException("Invalid Face");

            Directions.Face direction = (Directions.Face)Enum.Parse(typeof(Directions.Face), face);
            return direction;
        }
    }
}