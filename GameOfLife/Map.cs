using System;

namespace GameOfLife
{
	public class Map
	{
		public Map()
		{
			data[2, 2] = true;
			data[2, 3] = true;
			data[3, 2] = true;
			data[3, 3] = true;
		}

		private readonly bool[,] data = new bool[40, 20];

		public void Draw()
		{
			for (int y = 0; y < data.GetLength(1); y++)
			{
				for (int x = 0; x < data.GetLength(0); x++)
					Console.Write(data[x, y] ? "X" : ".");
				Console.WriteLine();
			}
		}
	}
}