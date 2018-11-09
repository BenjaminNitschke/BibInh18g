using System;

namespace GameOfLife
{
    public class Map
    {
        private bool[,] current;
        private bool[,] next;

        public Map(int width, int height)
        {
            current = new bool[width, height];
            next = new bool[width, height];
        }

        public void Seed()
        {
            current[1, 0] = true;
            current[1, 1] = true;
            current[1, 2] = true;
            //current[3, 3] = true;
        }

        public void Update()
        {
            for (int y = 0; y < this.current.GetLength(1); y++)
            {
                for (int x = 0; x < this.current.GetLength(0); x++)
                {
                    int neighbors = GetNeighbors(x, y);
                    if (neighbors == 2 || neighbors == 3)
                    {
                        if (neighbors == 3)
                            next[x, y] = true;
                    }
                    else
                        next[x, y] = false;
                }
            }
            var temp = current;
            current = next;
            next = temp;
        }

        public void Draw()
        {
            for (int y = 0; y < this.current.GetLength(1); y++)
            {
                for (int x = 0; x < this.current.GetLength(0); x++)
                {
                    if (this.current[x, y])
                        Console.Write("| X ");
                    else
                        Console.Write("|   ");

                    if (x == this.current.GetLength(0) - 1)
                        Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine("------------------");
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
            return x >= 0 && x < current.GetLength(0) && y >= 0 && y < current.GetLength(1);
        }

        private bool IsSet(int x, int y)
        {
            return current[x, y];
        }

        public bool[,] GetData()
        {
            return current;
        }
    }
}
