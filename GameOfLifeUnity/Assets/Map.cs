using System;

namespace GameOfLife
{
	public class Map
	{
		public Map(int width, int height)
		{
			current = new bool[width, height];
			next = new bool[width, height];
		}

		public bool[,] current;
		public bool[,] next;

		public void Seed()
		{
			// Stable 2x2 block
			current[2, 2] = true;
			current[2, 3] = true;
			current[3, 2] = true;
			current[3, 3] = true;
			// 3x1 blinking pattern
			current[0, 10] = true;
			current[1, 10] = true;
			current[2, 10] = true;

			Random rnd = new Random();
			for (int x = 5; x < 30; x++)
			for (int y = 2; y < 18; y++)
				if (rnd.Next(2) == 1)
					current[x, y] = true;
		}

		public void Draw()
		{
			for (int y = 0; y < current.GetLength(1); y++)
			{
				for (int x = 0; x < current.GetLength(0); x++)
					Console.Write(current[x, y] ? "X" : ".");
				Console.WriteLine();
			}
		}

		public void ExecuteNextStep()
		{
			for (int y = 0; y < current.GetLength(1); y++)
			for (int x = 0; x < current.GetLength(0); x++)
			{
				int neighbors = GetNeighbors(x, y);
				if (IsSet(x, y) && neighbors == 2 || neighbors == 3)
					next[x, y] = true;
				else
					next[x, y] = false;
			}
			// Swap
			var temp = current;
			current = next;
			next = temp;
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
			return x >= 0 && x < current.GetLength(0) && y >= 0 && y < current.GetLength(1);
		}

		public bool IsSet(int x, int y)
		{
			return current[x, y];
		}
	}
}