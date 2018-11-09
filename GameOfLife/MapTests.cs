using System.ComponentModel;
using NUnit.Framework;

namespace GameOfLife
{
	public class MapTests
	{
		[Test]
		public void EmptyMapStaysEmpty()
		{
			var map = new Map(3, 3);
			map.ExecuteNextStep();
			CheckMapIsEmpty(map);
		}

		private static void CheckMapIsEmpty(Map map)
		{
			map.Draw();
			for (int y = 0; y < map.current.GetLength(1); y++)
			for (int x = 0; x < map.current.GetLength(0); x++)
				Assert.That(map.current[x, y], Is.False);
		}

		[Test]
		public void Rule1OneCellDies()
		{
			var map = new Map(3, 3);
			map.current[0, 0] = true;
			map.ExecuteNextStep();
			CheckMapIsEmpty(map);
		}
<<<<<<< HEAD

		[Test]
=======
>>>>>>> master
		
		/// <summary>
		/// XX.
		/// X..
		/// ...
		/// </summary>
		[Test]
		public void CellWithTwoNeighborsLives()
		{
			var map = new Map(3, 3);
			map.current[0, 0] = true;
			map.current[0, 1] = true;
			map.current[1, 0] = true;
<<<<<<< HEAD
			// Act
			map.ExecuteNextStep();
			// Assert
=======
			map.ExecuteNextStep();
>>>>>>> master
			Assert.That(map.current[0, 0], Is.True);
		}

		[Test]
		public void CellShouldNotCountItselfAsNeighbor()
		{
			var map = new Map(3, 3);
			map.current[0, 0] = true;
			map.current[1, 0] = true;
			map.ExecuteNextStep();
			CheckMapIsEmpty(map);
		}
		
		[Test]
		public void CellWithMoreThanThreeNeighborsDies()
		{
<<<<<<< HEAD
            //Any live cell with more than three live neighbors dies, as if by overpopulation.
            var map = new Map(3, 3);
            //Cell to check
            map.current[1, 1] = true;
            //Create 4 neighbours
            map.current[1, 0] = true;
            map.current[0, 1] = true;
            map.current[2, 1] = true;
            map.current[1, 2] = true;
            map.ExecuteNextStep();
            Assert.That(map.current[1, 1], Is.False);
        }
=======
			var map = new Map(3, 3);
			// Cell to check
			map.current[1, 1] = true;
			// Create 4 Neighbors
			map.current[1, 0] = true;
			map.current[0, 1] = true;
			map.current[2, 1] = true;
			map.current[1, 2] = true;
			map.ExecuteNextStep();
			Assert.That(map.current[1, 1], Is.False);
		}
>>>>>>> master
		
		[Test]
		public void DeadCellWithExactlyThreeNeighborsBecomesLive()
		{
<<<<<<< HEAD
            var map = new MapTests(3, 3);
            //Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

            map.data[1, 0] = true;
            map.data[0, 1] = true;
            map.data[2, 1] = true;
            map.ExecuteNextStep();
            Assert.That(map.data[1, 1], Is.True);
        }
    }
=======
			var map = new Map(3, 3);
			// Create 3 neighbors around 1, 1
			map.current[1, 0] = true;
			map.current[0, 1] = true;
			map.current[2, 1] = true;
			map.ExecuteNextStep();
			Assert.That(map.current[1, 1], Is.True);
		}

		[Test]
		public void StableTreeCellPattern()
		{
			var map = new Map(3, 3);
			map.current[0, 1] = true;
			map.current[1, 1] = true;
			map.current[2, 1] = true;
			map.Draw();
			map.ExecuteNextStep();
			map.Draw();
			Assert.That(map.current[1, 0], Is.True);
			map.ExecuteNextStep();
			map.Draw();
			Assert.That(map.current[1, 0], Is.False);
			Assert.That(map.current[0, 1], Is.True);
		}
	}
>>>>>>> master
}