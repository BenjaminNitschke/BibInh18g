using System;

namespace GameOfLife
{
	public class Map
	{
		public Map(int width, int height)
		{
			data = new bool[width, height];
		}

		public readonly bool[,] data;

		public void Seed()
		{
			data[2, 2] = true;
			data[2, 3] = true;
			data[3, 2] = true;
			data[3, 3] = true;
		}


		public void Draw()
		{
			for (int y = 0; y < data.GetLength(1); y++)
			{
				for (int x = 0; x < data.GetLength(0); x++)
					Console.Write(data[x, y] ? "X" : ".");
				Console.WriteLine();
			}
		}

		public void ExecuteNextStep()
		{
			for (int y = 0; y < data.GetLength(1); y++)
			for (int x = 0; x < data.GetLength(0); x++)
			{
				int neighbors = GetNeighbors(x, y);
				if (neighbors == 2 || neighbors == 3)
					data[x, y] = true;
				else
					data[x, y] = false;
			}
		}

		private int GetNeighbors(int x, int y)
		{
			int numberOfNeighbors = 0;
			for (int checkY = -1; checkY <= 1; checkY++)
			for (int checkX = -1; checkX <= 1; checkX++)
				if (IsNotCenter(checkX, checkY) && IsInMap(x + checkX, y + checkY) &&
						IsSet(x + checkX, y + checkY))
					numberOfNeighbors++;
			return numberOfNeighbors;
		}

		private static bool IsNotCenter(int checkX, int checkY)
		{
			return checkX != 0 || checkY != 0;
		}

		private bool IsInMap(int x, int y)
		{
			return x >= 0 && x < data.GetLength(0) && y >= 0 && y < data.GetLength(1);
		}

		private bool IsSet(int x, int y)
		{
			return data[x, y];
		}
	}
}