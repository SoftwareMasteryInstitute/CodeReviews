﻿using System;

namespace PacmanLibrary
{
    public class Pacman
    {
        private int _x;
        private int _y;
        private Grid _grid;

        public int X
        {
            get => _x;
            set
            {
                if (value >= 0)
                    _x = value;
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                if (value >= 0)
                    _y = value;
            }
        }

        public Directions.Face Face { get; set; }

        public Grid Grid
        {
            get => _grid;
            set => _grid = value;
        }

        //Methods//

        //Place pacmann on grid
        public void Place(Grid grid, int x, int y, Directions.Face face)
        {
            Grid = grid;
            this.Place(x, y, face);
        }

        public void Place(int x, int y, Directions.Face face)
        {
            if (Grid == null) return;
            if (Grid.IsValidPlace(x, y)) //Validate Gird and coordinates before placing
            {
                X = x;
                Y = y;
                Face = face;
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
            if (!this.IsPlaced()) return; //ignore the command if pacman is not placed on the grid.

            switch (this.Face)
            {
                case Directions.Face.NORTH:
                    Face = Directions.Face.WEST;
                    break;
                case Directions.Face.SOUTH:
                    Face = Directions.Face.EAST;
                    break;
                case Directions.Face.EAST:
                    Face = Directions.Face.NORTH;
                    break;
                case Directions.Face.WEST:
                    Face = Directions.Face.SOUTH;
                    break;
            }
        }

        //Turn Right
        public void Right()
        {
            if (!this.IsPlaced()) return; //ignore the command if pacman is not placed on the grid.

            switch (this.Face)
            {
                case Directions.Face.NORTH:
                    Face = Directions.Face.EAST;
                    break;
                case Directions.Face.SOUTH:
                    Face = Directions.Face.WEST;
                    break;
                case Directions.Face.EAST:
                    Face = Directions.Face.SOUTH;
                    break;
                case Directions.Face.WEST:
                    Face = Directions.Face.NORTH;
                    break;
            }
        }

        //return current coordinates of the pacman
        public string Report()
        {
            if (!this.IsPlaced()) return String.Empty; //Throw exception if pacman not placed on grid
            return $"{X}, {Y}, {Face}";
        }

        //Check whether pacman is placed on the grid
        private bool IsPlaced()
        {
            return _grid != null;
        }

        //Check if the next move is valid, To avoid falling off the grid
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