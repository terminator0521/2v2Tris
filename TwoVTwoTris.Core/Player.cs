using Raylib_cs;
using TwoVTwoTris.Input;
namespace TwoVTwoTris.Core
{
    internal class Player : IInputManager
    {
        internal bool IsAlive { get; private set; }
        internal int Score { get; private set; }
        private Rectangle _board;
        private int[,] _currentPiece;
        private int _holdingPiece;
        private int _tileSize;

        internal int[,] gameBoard =
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        };

        // 0 is empty
        // 9 is garbage
        // - number is placed

        internal Player(Rectangle rect, int tileSize)
        {
            _board = rect;
            _tileSize = tileSize;
        }

        internal void Update()
        {

        }

        internal void Render()
        {
            Raylib.DrawRectangleRec(_board, Color.LightGray);

            for (int i = 0; i < gameBoard.GetLength(1) + 1; i++)
            {
                Raylib.DrawLineV(new(_board.X + (_tileSize * i), _board.Y), new(_board.X + (_tileSize * i), _board.Y + _board.Height), Color.Black);
            }

            for (int i = 0; i < gameBoard.GetLength(0) + 1; i++)
            {
                Raylib.DrawLineV(new(_board.X, _board.Y + (_tileSize * i)), new(_board.X + _board.Width, _board.Y + (_tileSize * i)), Color.Black);
            }
        }
        public void GetInputs()
        {

        }

        private void GetNextPiece()
        {

        }
    }
}
