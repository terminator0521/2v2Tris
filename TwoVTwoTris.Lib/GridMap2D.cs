namespace TwoVTwoTris.Lib
{
    internal record struct GridMap2D<T>
    {

        public T[,] grid;
        public int Length
        {
            get => grid.GetLength(0);
        }
        public int Width
        {
            get => grid.GetLength(1);
        }
        public GridMap2D(T[,] grid)
        {
            this.grid = (T[,])grid.Clone();
        }
        public GridMap2D(int size)
        {
            grid = new T[size, size];
        }
        public GridMap2D(int length, int width)
        {
            grid = new T[length, width];
        }

        public void Shift(GridMap2D<bool> gridMap2D, Point2D startPosition, Point2D displacement)
        {
            T[,] old = (T[,])this.grid.Clone();

            // for displacement.X
            for (int i = startPosition.X; i < startPosition.X + displacement.X; i++)
            {
                for (int j = startPosition.Y; j < Width + displacement.X; j++)
                {
                    try
                    {
                        grid[i + 1, j] = old[i, j];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        this.grid = (T[,])old.Clone();
                        return;
                    }
                }
            }
        }
    }
}
