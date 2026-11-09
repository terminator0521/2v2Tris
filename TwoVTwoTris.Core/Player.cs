using Raylib_cs;
using TwoVTwoTris.Entities;
using TwoVTwoTris.Input;
using TwoVTwoTris.Lib;
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
        private Point2D[] _piecePos = new Point2D[4];
        private float _dropTime = 0.2f;
        private float _dropTimeWaited = 0f;


        //internal game board matrix
        private int[,] _realGameBoard =
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
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
        };

        //player perceieved gameboard
        internal int[,] currentGameBoard;

        // 0 is empty
        // 9 is garbage

        internal Player(Rectangle rect, int tileSize)
        {
            _board = rect;
            _tileSize = tileSize;
            SetNewPiece();
            currentGameBoard = (int[,])_realGameBoard.Clone();
        }

        internal void Update()
        {
            Console.WriteLine(_piecePos[0].Y);
            //block falling logic
            if (_dropTimeWaited > _dropTime)
            {
                _dropTimeWaited = 0f;
                for (int i = 0; i < _piecePos.Length; i++) //update every tile
                {
                    if (_realGameBoard[_piecePos[i].Y + 1, _piecePos[i].X] != 0) //check below block
                    {
                        for (int j = i; j < _piecePos.Length; j++) //place right side tiles
                        {
                            _realGameBoard[_piecePos[j].Y, _piecePos[j].X] = 1;
                        }

                        for (int j = 0; j < i; j++) //place left side tiles
                        {
                            _realGameBoard[_piecePos[j].Y - 1, _piecePos[j].X] = 1;
                        }
                        SetNewPiece();
                        break;
                    }
                    else
                    {
                        _piecePos[i].Y += 1;
                    }
                }
            }
            else
            {
                _dropTimeWaited += Raylib.GetFrameTime();
            }
            currentGameBoard = (int[,])_realGameBoard.Clone();

            //update percieved box
            foreach (var pos in _piecePos)
            {
                currentGameBoard[pos.Y, pos.X] = 1;
            }

        }

        internal void Render()
        {
            //render the board
            {
                Raylib.DrawRectangleRec(_board, Color.LightGray);
                Raylib.DrawRectangle((int)_board.X, (int)_board.Y, (int)_tileSize * 10, (int)_tileSize * 3, Color.White);
                for (int i = 0; i < currentGameBoard.GetLength(1) + 1; i++)
                {
                    Raylib.DrawLineV(new(_board.X + (_tileSize * i), _board.Y), new(_board.X + (_tileSize * i), _board.Y + _board.Height), Color.Black);
                }
                for (int i = 0; i < currentGameBoard.GetLength(0) + 2; i++)
                {
                    Raylib.DrawLineV(new(_board.X, _board.Y + (_tileSize * i)), new(_board.X + _board.Width, _board.Y + (_tileSize * i)), Color.Black);
                }
            }

            //render current piece
            for (int i = 0; i < currentGameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < currentGameBoard.GetLength(1); j++)
                {
                    if (currentGameBoard[i, j] != 0)
                    {
                        Raylib.DrawRectangle((int)_board.X + (j * _tileSize), (int)_board.Y + (i * _tileSize), _tileSize, _tileSize, Color.Red);
                    }
                }
            }
        }
        public void GetInputs()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Right))
                for (int i = 0; i < _piecePos.Length; i++)
                    _piecePos[i].X++;
            if (Raylib.IsKeyPressed((KeyboardKey)InputSettings.keyCodeLeft))
                for (int i = 0; i < _piecePos.Length; i++)
                    _piecePos[i].X--;

        }

        private void SetNewPiece()
        {
            _piecePos = Tetromino.NewPiece();
        }

        private void Fall()
        {

        }
    }
}
