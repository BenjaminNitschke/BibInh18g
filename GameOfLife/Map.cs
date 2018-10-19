using System;

namespace GameOfLife
{
    public class Map
    {
        private bool[,] data;

        public Map(int width, int height)
        {
            data = new bool[width, height];
            data[2, 2] = true;
            data[2, 3] = true;
            data[3, 2] = true;
            data[3, 3] = true;
        }

        public void Update()
        {
            data[2, 2] = false;
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
