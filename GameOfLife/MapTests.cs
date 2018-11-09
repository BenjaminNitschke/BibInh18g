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
			for (int y = 0; y < map.data.GetLength(1); y++)
			for (int x = 0; x < map.data.GetLength(0); x++)
				Assert.That(map.data[x, y], Is.False);
		}

		[Test]
		public void OneCellDies()
		{
			var map = new Map(3, 3);
			map.data[0, 0] = true;
			map.ExecuteNextStep();
			CheckMapIsEmpty(map);
		}

		[Test]
		public void Rule1()
		{
			var map = new Map(3, 3);
			map.data[2, 2] = true;
			map.ExecuteNextStep();
			map.Draw();
			Assert.That(map.data[2, 2], Is.False);
		}

		/// <summary>
		/// XX.
		/// X..
		/// ...
		/// </summary>
		[Test]
		public void CellWithTwoNeighborsLives()
		{
			// Assign
			var map = new Map(3, 3);
			map.data[0, 0] = true;
			map.data[0, 1] = true;
			map.data[1, 0] = true;
			// Act
			map.ExecuteNextStep();
			// Assert
			Assert.That(map.data[0, 0], Is.True);
		}

		[Test]
		public void CellShouldNotCountItselfAsNeighbor()
		{
			var map = new Map(3, 3);
			map.data[0, 0] = true;
			map.data[1, 0] = true;
			map.ExecuteNextStep();
			CheckMapIsEmpty(map);
		}

		[Test]
		public void Rule3()
		{
            //Any live cell with more than three live neighbors dies, as if by overpopulation.
            var map = new Map(3, 3);
            map.data[0, 1] = true;
            map.data[1, 0] = true;
            map.data[1, 2] = true;
            map.data[2, 1] = true;

            map.data[1, 1] = true;

            map.ExecuteNextStep();

            Assert.That(map.data[1, 1], Is.False);
		}
		
		[Test]
		public void Rule4()
		{
            //Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
            var map = new Map(3, 3);

            map.data[0, 1] = true;
            map.data[1, 0] = true;
            map.data[1, 2] = true;

            map.data[1, 1] = false;

            map.ExecuteNextStep();

            Assert.That(map.data[1, 1], Is.True);
		}
	}
}