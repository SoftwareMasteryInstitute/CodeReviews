using System;

namespace PacmanLibrary
{
    public class Directions
    {
        public enum Face
        {
            NORTH,
            SOUTH,
            EAST,
            WEST,
        }

        //Return face if input is a valid input
        public static Directions.Face IsValidFace(string face)
        {
            if (!Enum.IsDefined(typeof(Directions.Face), face)) throw new InvalidInputException("Invalid Face");

            Directions.Face direction = (Directions.Face)Enum.Parse(typeof(Directions.Face), face);
            return direction;
        }
    }
}
