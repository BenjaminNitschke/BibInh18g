using System;
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
			for (int y = 0; y < 3; y++)
			for (int x = 0; x < 3; x++)
				Assert.That(map.data[x, y], Is.False);
		}

        [Test]
        public void OneCellDies()
        {
            //Arrange
            var map = new Map(3, 3);
            map.data[2, 2] = true;

            //Act

            map.ExecuteNextStep();

            //Assert
            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)    
                    Assert.That(map.data[x, y], Is.False);
                


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
	}
}