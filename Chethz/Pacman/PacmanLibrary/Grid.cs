namespace PacmanLibrary
{
    public class Grid
    {
        private int _width;
        private int _length;

        public int Width
        {
            get { return _width; }
            set
            {
                if (value <= 0)
                    throw new InvalidInputException("Invalid Input!");
                _width = value;
            }
        }

        public int Length
        {
            get { return _length; }
            set
            {
                if (value <= 0)
                    throw new InvalidInputException("Invalid Input!");
                _width = value;
            }
        }

        //Constructor
        public Grid(int width, int length)
        {
            _width = width;
            _length = length;
        }

        //Check whether input is with in the grid range
        public bool IsValidPlace(int x, int y)
        {
            if (x >= 0 && x <= Width - 1 && y >= 0 && y <= Length - 1)
                return true;
            return false;
        }
    }
}