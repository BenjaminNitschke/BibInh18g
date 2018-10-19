using NUnit.Framework;
using System;

namespace GameOfLife
{
    public class Program
    {
        public static void Main()
        {
            new Program();
        }

        [Test, Description("Any live cell with fewer than two live neighbors dies, as if by underpopulation")]
        public void Rule1()
        {
            Map map = new Map(5, 5);
            // Set variables
            map.GetData()[2, 2] = true;

            // Update game
            map.Update();

            // Check conditions
            Assert.That(map.GetData()[2, 2], Is.False);

            // Draw map
            map.Draw();
        }
    }
}
