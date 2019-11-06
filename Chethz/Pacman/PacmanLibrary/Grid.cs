using System;

namespace PacmanLibrary
{

    public class Grid
    {
        private int _width;
        private int _length;

        public int Width
        {
            get => _width;
            set
            {
                if (value <= 0)
                    throw new InvalidInputException("Invalid Input!");
                _width = value;
            }
        }

        public int Length
        {
            get => _length;
            set
            {
                if (value <= 0)
                    throw new InvalidInputException("Invalid Input!");
                _length = value;
            }
        }

        public Grid(int width, int length)
        {
            Width = width;
            Length = length;
        }

        //Check whether input is with in the grid range
        public bool IsValidPlace(int x, int y)
        {
            var xIsWithInBounds = x >= 0 && x <= Width - 1;
            var yIsWithInBounds = y >= 0 && y <= Length - 1;

            return (xIsWithInBounds && yIsWithInBounds);
        }
    }
}