using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BowlingGame
{
	public class Program
	{
		public static void Main()
		{
			var random = new Random();
            var pins = new List<int>();
			for (int round = 0; round < 10; round++)
			{
				var throwResult = random.Next(0, 10 + 1);
                pins.Add(throwResult);
				var throwResult2 = random.Next(0, 10 + 1 - throwResult);
                if (throwResult < 10)
                    pins.Add(throwResult2);
				Console.WriteLine("Round "+(round+1)+" Throws: "+throwResult+", "+throwResult2);
			}
            var game = new Game(pins.ToArray());
            Console.WriteLine("Total points: "+game.CalculatePoints());
		}
	}

	public class Game
	{
		public Game(int[] pins) => this.pins = pins;
        private readonly int[] pins;

		public int CalculatePoints()
        {
			int result = 0;
            int roll = 0;
            for (int round = 0; round < 10; round++, roll += 2)
                result += IsStrike(roll)
                    ? 10 + pins[roll + 1] + pins[roll-- + 2]
                    : IsSpare(roll)
                        ? 10 + pins[roll + 2]
                        : pins[roll] + pins[roll + 1];
            return result;
		}

        private bool IsStrike(int roll) => pins[roll] == 10;
        private bool IsSpare(int roll) => pins[roll] + pins[roll + 1] == 10;
    }

	public class GameTests
	{
		[SetUp]
		public void ResetList()
		{
			pins.Clear();
		}

		[Test]
		public void ZeroGame()
		{
			Roll(20, 0);
			int points = new Game(pins.ToArray()).CalculatePoints();
			Assert.That(points, Is.EqualTo(0));
		}

		private void Roll(int numberOfThrows, int pinsPerThrow)
        {
            for (var i = 0; i < numberOfThrows; i++)
                pins.Add(pinsPerThrow);
        }

		private readonly List<int> pins = new List<int>();

		[Test]
		public void AllOne()
        {
			Roll(20, 1);
			int points = new Game(pins.ToArray()).CalculatePoints();
			Assert.That(points, Is.EqualTo(20));
		}

		[Test]
		public void ThrowSpare()
		{
			Roll(1, 3);
			Roll(1, 7);
			Roll(1, 2);
			Roll(17, 0);
			int points = new Game(pins.ToArray()).CalculatePoints();
			Assert.That(points, Is.EqualTo(3+7+2+2));
		}

		[Test]
		public void ThrowStrike()
		{
			Roll(1, 10);
			Roll(1, 10);
			Roll(16, 0);
			int points = new Game(pins.ToArray()).CalculatePoints();
			Assert.That(points, Is.EqualTo(10+10+10+0));
		}
		
		[Test]
		public void ThrowAnotherStrike()
		{
			Roll(1, 10);
			Roll(1, 4);
            Roll(1, 6);
			Roll(16, 0);
			int points = new Game(pins.ToArray()).CalculatePoints();
			Assert.That(points, Is.EqualTo(10+2*4+2*6));
		}

		[Test]
		public void PerfectGame()
		{
			Roll(12, 10);
			int points = new Game(pins.ToArray()).CalculatePoints();
			Assert.That(points, Is.EqualTo(300));
		}
	}
}
