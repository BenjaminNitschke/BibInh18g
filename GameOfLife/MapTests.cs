using NUnit.Framework;
using System;

namespace GameOfLife
{
    class MapTests
    {
        [Test]
        public void Nothing()
        {

        }

        [Test]
        public void EmptyMapStaysEmpty()
        {
            //Arrange
            Map map = new Map(10, 10);

            //Act
            map.Update();

            //Assert
            for(int y = 0; y < map.GetData().GetLength(1); y++)
            {
                for (int x = 0; x < map.GetData().GetLength(0); x++)
                {
                    Assert.That(map.GetData()[x, y], Is.False);
                }
            }
        }

        [Test]
        public void OneCellDies()
        {
            // Arrange
            Map map = new Map(3, 3);
            map.GetData()[0, 0] = true;

            // Act
            map.Update();

            //Assert
            Assert.That(map.GetData()[0, 0], Is.False);
        }

        [Test, Description("Any live cell with fewer than two live neighbors dies, as if by underpopulation")]
        public void Rule1()
        {
            Map map = new Map(5, 5);
            // Set variables
            map.GetData()[2, 2] = true;

            // Update game
            map.Update();

            // Check conditions
            Assert.That(map.GetData()[2, 2], Is.False);

            // Draw map
            map.Draw();
        }
    }
}
