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
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        };
        /*
         * I piece:
         * 0 0 0 1 1 1 1 0 0 0
         * 
         * O piece:
         * 0 0 0 0 1 1 0 0 0 0
         * 0 0 0 0 1 1 0 0 0 0
         * 
         * L piece:
         * 0 0 0 0 0 1 0 0 0 0
         * 0 0 0 1 1 1 0 0 0 0
         * 
         * J piece:
         * 0 0 0 1 0 0 0 0 0 0
         * 0 0 0 1 1 1 0 0 0 0
         * 
         * S piece:
         * 0 0 0 0 1 1 0 0 0 0
         * 0 0 0 1 1 0 0 0 0 0
         * 
         * Z piece:
         * 0 0 0 1 1 0 0 0 0 0 
         * 0 0 0 0 1 1 0 0 0 0 
         * 
         * T piece:
         * 0 0 0 0 1 0 0 0 0 0
         * 0 0 0 1 1 1 0 0 0 0 
         */

        // 0 is empty
        // 9 is garbage

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
            //render the board
            Raylib.DrawRectangleRec(_board, Color.LightGray);
            Raylib.DrawRectangle((int)_board.X, (int)_board.Y, (int)_tileSize * 10, (int)_tileSize * 3, Color.White);
            for (int i = 0; i < gameBoard.GetLength(1) + 1; i++)
            {
                Raylib.DrawLineV(new(_board.X + (_tileSize * i), _board.Y), new(_board.X + (_tileSize * i), _board.Y + _board.Height), Color.Black);
            }
            for (int i = 0; i < gameBoard.GetLength(0) + 2; i++)
            {
                Raylib.DrawLineV(new(_board.X, _board.Y + (_tileSize * i)), new(_board.X + _board.Width, _board.Y + (_tileSize * i)), Color.Black);
            }

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] != 0)
                    {
                        Raylib.DrawRectangle((int)_board.X + (j * _tileSize), (int)_board.Y + (i * _tileSize), _tileSize, _tileSize, Color.Red);
                    }
                }
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
