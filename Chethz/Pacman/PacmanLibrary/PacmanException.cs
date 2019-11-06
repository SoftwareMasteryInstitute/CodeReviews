using System;

namespace PacmanLibrary
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }

    public class InvalidInitializedException : Exception
    {
        public InvalidInitializedException(string message) : base(message) { }
    }

    public class InvalidCoordinatesException : Exception
    {
        public InvalidCoordinatesException(string message) : base(message) { }
    }
}