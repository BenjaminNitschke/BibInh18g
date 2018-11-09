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
            CheckMapIsEmpty(map);
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
            CheckMapIsEmpty(map);
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

        [Test]
        public void CellShouldNotCountItselfAsNeighbor()
        {
            // Assign
            Map map = new Map(3, 3);
            map.GetData()[0, 0] = true;
            map.GetData()[1, 0] = true;

            // Act
            map.Update();

            // Assert
            Assert.That(map.GetNeighbors(0, 0), Is.EqualTo(0));
            //CheckMapIsEmpty(map);
        }

        [Test, Description("Any live cell with more than three live neighbors dies, as if by overpopulation.")]
        public void Rule3()
        {
            Map map = new Map(3, 2);
            // Set variables
            // 0 | x | x
            // x | x | x
            map.GetData()[1, 0] = true;
            map.GetData()[2, 0] = true;
            map.GetData()[0, 1] = true;
            map.GetData()[1, 1] = true;
            map.GetData()[2, 1] = true;


            // Update game
            map.Update();

            // Draw map
            map.Draw();

            // Check conditions
            // x | 0 | x
            // x | 0 | x
            Assert.That(map.GetData()[1, 1], Is.False);
        }

        [Test, Description("Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.")]
        public void Rule4()
        {
            Map map = new Map(3, 2);
            // Set variables
            // 0 | x | x
            // 0 | 0 | x
            map.GetData()[1, 0] = true;
            map.GetData()[2, 0] = true;
            map.GetData()[2, 1] = true;


            // Update game
            map.Update();

            // Draw map
            map.Draw();

            // Check conditions
            // 0 | 0 | 0
            // 0 | x | 0
            Assert.That(map.GetData()[1, 1], Is.True);
        }

        [Test]
        public void StableTreeCellPattern()
        {
            Map map = new Map(3, 3);
            // Set variables
            // 0 | x | 0
            // 0 | x | 0
            // 0 | x | 0
            map.GetData()[1, 0] = true;
            map.GetData()[1, 1] = true;
            map.GetData()[1, 2] = true;


            // Update game
            map.Update();

            // Draw map
            map.Draw();

            // Check conditions
            // 0 | 0 | 0
            // 0 | x | 0
            Assert.That(map.GetData()[0, 1], Is.True);
        }

        private void CheckMapIsEmpty(Map map)
        {
            for (int y = 0; y < map.GetData().GetLength(1); y++)
            {
                for (int x = 0; x < map.GetData().GetLength(0); x++)
                {
                    Assert.That(map.GetData()[x, y], Is.False);
                }
            }
        }
    }
}
