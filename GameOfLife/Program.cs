using System;
using System.Threading;

namespace GameOfLife
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Game Of Life");
			var map = new Map(40, 20);
			map.Seed();
			while (true)
			{
				Console.Clear();
				map.ExecuteNextStep();
				map.Draw();
				Thread.Sleep(500);
			}
		}
	}
}