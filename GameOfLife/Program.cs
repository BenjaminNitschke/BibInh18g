using System;
using NUnit.Framework;

namespace GameOfLife
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Game Of Life");
			var map = new Map();
			map.Draw();
		}
		/*
		[Test]
		public void Rule1()
		{
			map[2, 2] = true;
			ExecuteNextStep(map);
			Draw(map);
			Assert.That(map[2, 2], Is.False);
		}

		void ExecuteNextStep(bool[,] map)
		{
			//Rule 1: Any live cell with fewer than two live neighbors dies, as if by underpopulation.
			map[2, 2] = false;
		}
		*/
	}
}