using NUnit.Framework;
using Pacman_Solution;
using PacmanLibrary;

namespace PacmanTests
{
    public class SimulatorTests
    {
        private Simulator _simulator;

        [SetUp]
        public void Setup()
        {
            Grid grid = new Grid(5, 5);
            Pacman pacman = new Pacman();
            _simulator = new Simulator(pacman, grid);
        }
        [Test]
        public void UserInput_WhenInvalidCoordinate_ShouldReturnException()
        {
            var ex = Assert.Throws<InvalidInputException>(() => _simulator.UserInput("PLACE One, 1, NORTH"));
            Assert.AreEqual("Invalid input format", ex.Message);
        }

        [Test]
        public void UserInput_InvalidInputFace_ShouldThrowException()
        {
            var ex = Assert.Throws<InvalidInputException>(() => _simulator.UserInput("PLACE 1, 1, NORRTH"));
            Assert.AreEqual("Invalid Face", ex.Message);
        }

        [Test]
        public void UserInput_InvalidInputFormat_ShouldThrowException()
        {
            var ex = Assert.Throws<InvalidInputException>(() => _simulator.UserInput("PLACE 1 NORTH"));
            Assert.AreEqual("Invalid input format", ex.Message);
        }

        [Test]
        [TestCase("PLACEE 1, 1, NORTH", "Invalid command")]
        [TestCase("MOVEE", "Invalid command")]
        [TestCase("LEFTT", "Invalid command")]
        [TestCase("RIGHTT", "Invalid command")]
        public void UserInput_InvalidCommand_ShouldThrowException(string invalidCommand, string expectedResult)
        {
            var ex = Assert.Throws<InvalidInputException>(() => _simulator.UserInput(invalidCommand));
            Assert.AreEqual(expectedResult, ex.Message);
        }
    }
}