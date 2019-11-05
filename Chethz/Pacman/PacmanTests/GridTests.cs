using NUnit.Framework;
using PacmanLibrary;

namespace PacmanTests
{
    class GridTests
    {
            private Grid _grid;

            [SetUp]
            public void Setup()
            {
                _grid = new Grid(5, 5);
            }

            [Test]
            [TestCase(0, 0, true)]
            [TestCase(4, 4, true)]
            [TestCase(5, 5, false)]
            [TestCase(-1, -1, false)]
            public void IsValidPlace_WhenCalled_ShouldReturnTrueIfValidElseFalse(int x, int y, bool expectedResult)
            {
                var result = _grid.IsValidPlace(x, y);
                Assert.That(result, Is.EqualTo(expectedResult));
            }
    }
}
