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
		public void OneCellDies()
		{
			var map = new Map(3, 3);
			map.current[0, 0] = true;
			map.ExecuteNextStep();
			CheckMapIsEmpty(map);
		}
		
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
			map.ExecuteNextStep();
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
		
		[Test]
		public void DeadCellWithExactlyThreeNeighborsBecomesLive()
		{
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
}