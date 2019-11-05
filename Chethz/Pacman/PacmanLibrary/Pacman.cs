using System;

namespace PacmanLibrary
{
    public class Pacman
    {
        private int _x;
        private int _y;
        private Directions.Face _face;
        private Grid _grid;

        public int X
        {
            get { return _x; }
            set
            {
                if (value >= 0)
                    _x = value;
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                if (value >= 0)
                    _y = value;
            }
        }

        public Directions.Face Face
        {
            get { return _face; }
            set { _face = value; }
        }

        public Grid Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }

        //Methods//

        //Place pacmann on grid
        public void Place(Grid grid, int x, int y, Directions.Face face)
        {
            _grid = grid;
            this.Place(x, y, face);
        }

        public void Place(int x, int y, Directions.Face face)
        {
            if (_grid == null) return;
            if (_grid.IsValidPlace(x, y)) //Validate Gird and coordinates before placing
            {
                _x = x;
                _y = y;
                _face = face;
            }
        }

        //Move Pacman one step
        public void Move()
        {
            if (!this.IsPlaced() || !this.IsValidMove()) return;

            switch (this.Face)
            {
                case Directions.Face.NORTH:
                    Y += 1;
                    break;
                case Directions.Face.SOUTH:
                    Y -= 1;
                    break;
                case Directions.Face.EAST:
                    X += 1;
                    break;
                case Directions.Face.WEST:
                    X -= 1;
                    break;
            }
        }

        //Turn Pacman left
        public void Left()
        {
            if (!this.IsPlaced()) return; //ignore the command if pacman is not placed on the table.

            switch (this.Face)
            {
                case Directions.Face.NORTH:
                    _face = Directions.Face.WEST;
                    break;
                case Directions.Face.SOUTH:
                    _face = Directions.Face.EAST;
                    break;
                case Directions.Face.EAST:
                    _face = Directions.Face.NORTH;
                    break;
                case Directions.Face.WEST:
                    _face = Directions.Face.SOUTH;
                    break;
            }
        }

        //Turn Right
        public void Right()
        {
            if (!this.IsPlaced()) return; //ignore the command if pacman is not placed on the table.

            switch (this.Face)
            {
                case Directions.Face.NORTH:
                    _face = Directions.Face.EAST;
                    break;
                case Directions.Face.SOUTH:
                    _face = Directions.Face.WEST;
                    break;
                case Directions.Face.EAST:
                    _face = Directions.Face.SOUTH;
                    break;
                case Directions.Face.WEST:
                    _face = Directions.Face.NORTH;
                    break;
            }
        }

        //return current position of the pacman
        public string Report()
        {
            if (!this.IsPlaced()) return String.Empty; //Throw exception if pacman not placed on table
            return $"{X}, {Y}, {Face}";
        }

        //Check whether pacman is placed on the table
        private bool IsPlaced()
        {
            return _grid != null;
        }

        //Check if the next move is valid, To avoid falling off the table
        private bool IsValidMove()
        {
            var nextX = this.X;
            var nextY = this.Y;

            switch (this.Face)
            {
                case Directions.Face.NORTH:
                    nextY = this.Y + 1;
                    break;
                case Directions.Face.SOUTH:
                    nextY = this.Y - 1;
                    break;
                case Directions.Face.EAST:
                    nextX = this.X + 1;
                    break;
                case Directions.Face.WEST:
                    nextY = this.X - 1;
                    break;
            }

            return _grid.IsValidPlace(nextX, nextY);
        }
    }
}