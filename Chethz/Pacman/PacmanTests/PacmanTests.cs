using NUnit.Framework;
using PacmanLibrary;

namespace PacmanTests
{
    public class PacmanTests
    {

        private Pacman _pacman;
        private Grid _grid;

        [SetUp]
        public void Setup()
        {
            _pacman = new Pacman();
            _grid = new Grid(5, 5);
            _pacman.Place(_grid, 1, 1, Directions.Face.NORTH);
        }

        [Test]
        public void Place_SetGrid_ShouldReturnNotNull()
        {
            Assert.IsNotNull(_pacman.Grid);
        }

        [Test]
        public void Place_WhenPlaceOutsideGrid_ShouldIgnoreCommand()
        {
            var pacman = new Pacman();
            pacman.Place(6,6, Directions.Face.NORTH);
            Assert.IsNull(pacman.Grid);
        }

        [Test]
        public void Place_WhenPlaceOutsideGrid_ShouldIgnoreCommandStayInTheSameCoordinates()
        {
            _pacman.Place(6, 6, Directions.Face.NORTH);
            Assert.That(_pacman.X, Is.EqualTo(1));
            Assert.That(_pacman.Y, Is.EqualTo(1));
            Assert.That(_pacman.Face, Is.EqualTo(Directions.Face.NORTH));
        }

        [Test]
        public void Place_WhenPlaceAgainInVallidDifferentCoordinates_ShouldPlaceInNewCoordinates()
        {
            _pacman.Place(2,2, Directions.Face.SOUTH);
            Assert.That(_pacman.X, Is.EqualTo(2));
            Assert.That(_pacman.Y, Is.EqualTo(2));
            Assert.That(_pacman.Face, Is.EqualTo(Directions.Face.SOUTH));
        }

        [Test]
        public void Place_WhenNotPlaced_ShouldIgnoreCommands()
        {
            var pacman = new Pacman();
            pacman.Move();
            pacman.Left();
            var result =pacman.Report();
            Assert.IsEmpty(result);

        }

        [Test]
        public void IsPlaced_WhenPlaced_ShouldReturnTrue()
        {
            _pacman.Place(_grid, _pacman.X, _pacman.Y, _pacman.Face);
            Assert.IsNotNull(_pacman.Grid);
        }

        [Test]
        public void IsPlaced_WhenNotPlaced_ShouldReturnFalse()
        {
            var pacman = new Pacman();
            Assert.Null(pacman.Grid);
        }

        [Test]
        public void Move_WhenInNorthEastCornerFaceNorth_ShouldNotMove()
        {
            var pacman = new Pacman();
            pacman.Place(_grid,4, 4, Directions.Face.NORTH);
            pacman.Move();
            Assert.That(pacman.Y, Is.EqualTo(4));
            Assert.That(pacman.X, Is.EqualTo(4));
        }

        [Test]
        public void Move_WhenInNorthWestCornerFaceWest_ShouldNotMove()
        {
            var pacman = new Pacman();
            pacman.Place(_grid, 0, 4, Directions.Face.WEST);
            pacman.Move();
            Assert.That(pacman.Y, Is.EqualTo(4));
            Assert.That(pacman.X, Is.EqualTo(0));
        }

        [Test]
        public void Move_WhenInSouthWestCornerFaceSouth_ShouldNotMove()
        {
            var pacman = new Pacman();
            pacman.Place(_grid, 0, 0, Directions.Face.SOUTH);
            pacman.Move();
            Assert.That(pacman.Y, Is.EqualTo(0));
            Assert.That(pacman.X, Is.EqualTo(0));
        }

        [Test]
        public void Move_WhenInSouthEastCornerFaceEast_ShouldNotMove()
        {
            var pacman = new Pacman();
            pacman.Place(_grid, 4, 0, Directions.Face.EAST);
            pacman.Move();
            Assert.That(pacman.Y, Is.EqualTo(0));
            Assert.That(pacman.X, Is.EqualTo(4));
        }

        [Test]
        public void Left_WhenTurn_ShouldTurnNinetyDegreesLeft()
        {
            _pacman.Place(_grid, _pacman.X, _pacman.Y, _pacman.Face);
            _pacman.Left();
            Assert.That(_pacman.Face, Is.EqualTo(Directions.Face.WEST));
        }

        [Test]
        public void Right_WhenTurn_ShouldTurnNinetyDegreesRight()
        {
            _pacman.Place(_grid, _pacman.X, _pacman.Y, _pacman.Face);
            _pacman.Right();
            Assert.That(_pacman.Face, Is.EqualTo(Directions.Face.EAST));
        }

        [Test]
        public void Left_WhenInvalidCommandGivenNextValidCommandShouldProcess_ShouldNotMove()
        {
            var pacman = new Pacman();
            pacman.Place(_grid, 0, 0, Directions.Face.WEST);
            pacman.Move();
            pacman.Right();
            pacman.Move();
            Assert.That(pacman.Y, Is.EqualTo(1));
            Assert.That(pacman.X, Is.EqualTo(0));
        }

        [Test]
        public void Report_WhenNotPlaced_ShouldReturnEmptyString()
        {
            var pacman = new Pacman();
            var result = pacman.Report();
            Assert.IsEmpty(result);
        }

        [Test]
        public void Report_WhenPlaced_ShouldReturnDetailedString()
        {
            _pacman.Place(_grid, 1, 1, Directions.Face.NORTH);
            var result = _pacman.Report();
            StringAssert.Contains("1, 1, NORTH", result);
        }
    }
}