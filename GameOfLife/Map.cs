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
                    int neighbors = GetNeighbors(x, y);
                    if (neighbors == 2 || neighbors == 3)
                    {
                        if (neighbors == 3)
                            data[x, y] = true;
                    }
                    else
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
                        Console.Write("|X");
                    else
                        Console.Write("|  ");

                    if (x == this.data.GetLength(0) - 1)
                        Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        public int GetNeighbors(int x, int y)
        {
            int neighbors = 0;

            for (int checkY = -1; checkY <= 1; checkY++)
            {
                for (int checkX = -1; checkX <= 1; checkX++)
                {
                    if (IsNotCenter(checkX, checkY) && 
                        IsInMap(x + checkX, y + checkY) && 
                        IsSet(x + checkX, y + checkY))
                    {
                        neighbors++;
                    }
                }
            }

            return neighbors;
        }

        private bool IsNotCenter(int checkX, int checkY)
        {
            return (checkX != 0 || checkY != 0);
        }

        private bool IsInMap(int x, int y)
        {
            return x >= 0 && x < data.GetLength(0) && y >= 0 && y < data.GetLength(1);
        }

        private bool IsSet(int x, int y)
        {
            return data[x, y];
        }

        public bool[,] GetData()
        {
            return data;
        }
    }
}
