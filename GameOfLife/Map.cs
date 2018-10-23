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
            //Rule 1: Any live cell with fewer than two live neighbors dies, as if by underpopulation.
            for (int y = 0; y < data.GetLength(1); y++)
            for (int x = 0; x < data.GetLength(0); x++)
                data[x, y] = false;
		}
	}
}