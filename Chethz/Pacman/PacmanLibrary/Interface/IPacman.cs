using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanLibrary.Interface
{
    public interface IPacman
    {
        int X { get; set; }
        int Y { get; set; }
        Directions.Face Face { get; set; }
        IGrid Grid { get; set; }
        void Place(IGrid grid, int x, int y, Directions.Face face);
        void Place(int x, int y, Directions.Face face);

    }
}
