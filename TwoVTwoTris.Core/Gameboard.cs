using TwoVTwoTris.Lib;

namespace TwoVTwoTris.Core
{
    internal record struct Gameboard<T>
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
        public Gameboard(T[,] grid)
        {
            this.grid = (T[,])grid.Clone();
        }
        public Gameboard(int size)
        {
            grid = new T[size, size];
        }
        public Gameboard(int length, int width)
        {
            grid = new T[length, width];
        }

        public void Shift(Gameboard<bool> gridMap2D, Point2D startPosition, Point2D displacement)
        {

        }
    }
}
