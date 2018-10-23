using System;

namespace GameOfLife
{
    public class Map
    {
        private readonly bool[,] data;

        public Map(int width, int height)
        {
            data = new bool[width, height];
        }

        public void Update()
        {
            for (int y = 0; y < this.data.GetLength(1); y++)
            {
                for (int x = 0; x < this.data.GetLength(0); x++)
                {
                    data[x, y] = false;
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < this.data.GetLength(1); y++)
            {
                for (int x = 0; x < this.data.GetLength(0); x++)
                {
                    if (this.data[x, y])
                        Console.Write(".X");
                    else
                        Console.Write(". ");

                    if (x == this.data.GetLength(0) - 1)
                        Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        public bool[,] GetData()
        {
            return data;
        }
    }
}
