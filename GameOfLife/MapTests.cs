using NUnit.Framework;

namespace GameOfLife
{
	public class MapTests
	{
		[Test]
		public void EmptyMapStaysEmpty()
		{
			//Arrange
			var map = new Map(3, 3);

			//Act
			map.ExecuteNextStep();

			//Assert
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

    [Test]
    public void CellWithTwoNeighborsLives()
    {
      //Arrange
      var map = new Map(3, 3);
      map.data[0, 0] = true;
      map.data[0, 1] = true;
      map.data[1, 0] = true;
      //Act
      map.ExecuteNextStep();
      //Assert
      Assert.That(map.data[0, 0], Is.True);
    }
    //Any live cell with two or three live neighbors lives on to the next generation.
  }
}