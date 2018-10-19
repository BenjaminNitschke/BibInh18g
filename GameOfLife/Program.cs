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

		[Test]
		public void Rule1()
		{
			var map = new Map();
			map.data[2, 2] = true;
			map.ExecuteNextStep();
			map.Draw();
			Assert.That(map.data[2, 2], Is.False);
		}
	}
}