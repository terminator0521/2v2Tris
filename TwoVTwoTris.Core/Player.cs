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
        private int _tileSize;
        private float _dropTime = 0.2f;
        private float _dropTimeWaited = 0f;


        private enum PieceNum
        {
            I = 0,
            O = 1,
            J = 2,
            L = 3,
            S = 4,
            Z = 5,
            T = 6,

        }
        private int _currentPieceNum = 0;
        private int _pieceRotationState = 0;
        private Point2D[] _previousPiecePos = new Point2D[4];
        private Point2D[] _piecePos = new Point2D[4];


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
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        };

        //player perceieved gameboard
        internal int[,] currentGameBoard;

        // 0 is empty
        // 9 is garbage

        internal Player(Rectangle rect, int tileSize)
        {
            _board = rect;
            _tileSize = tileSize;
            //set stuff
            Tetromino.SetNewPiece(out _piecePos, out _currentPieceNum);
            Tetromino.SetNewPiece(out _previousPiecePos, out _currentPieceNum);
            //clone gameboard
            currentGameBoard = (int[,])_realGameBoard.Clone();
        }

        internal void Update()
        {
            //block falling logic
            if (_dropTimeWaited > _dropTime)
            {
                _dropTimeWaited = 0f;
                for (int i = 0; i < _piecePos.Length; i++) //update every tile
                {

                    if (_piecePos[i].Y == _realGameBoard.GetLength(0) - 1) //check if piece is at lowest point of board
                    {
                        _pieceRotationState = 0;
                        for (int j = 0; j < _piecePos.Length; j++)
                        {
                            _realGameBoard[_previousPiecePos[j].Y, _previousPiecePos[j].X] = 1;
                        }
                        SetNewPiece();
                        break;
                    }
                    else if (_realGameBoard[_piecePos[i].Y + 1, _piecePos[i].X] != 0) //place if tile below block is not empty
                    {
                        _pieceRotationState = 0;
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
                        //move down
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
            _previousPiecePos = (Point2D[])_piecePos.Clone();
            //right left movement

            if (Raylib.IsKeyPressed(KeyboardKey.Right))
            {
                for (int i = 0; i < _piecePos.Length; i++)
                    if (_piecePos[i].X == _realGameBoard.GetLength(1) - 1) //check if at edge
                    {
                        UndoMove();
                        break;
                    }
                    else if (_realGameBoard[_piecePos[i].Y, _piecePos[i].X + 1] != 0) //check if neighbour space is taken
                    {
                        UndoMove();
                        break;
                    }
                    else //move
                    {
                        _piecePos[i].X++;
                    }
            }
            else if (Raylib.IsKeyPressed((KeyboardKey)InputSettings.keyCodeLeft))
            {
                _previousPiecePos = (Point2D[])_piecePos.Clone();
                for (int i = 0; i < _piecePos.Length; i++)
                    if (_piecePos[i].X == 0) //check if at edge 
                    {
                        UndoMove();
                        break;
                    }
                    else if (_realGameBoard[_piecePos[i].Y, _piecePos[i].X - 1] != 0) //check if neighbour space is taken
                    {
                        UndoMove();
                        break;
                    }
                    else //move
                    {
                        _piecePos[i].X--;
                    }
            }



            // rotate
            if (Raylib.IsKeyPressed(KeyboardKey.Up))
            {
                ApplyRotation(1);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Z))
            {
                ApplyRotation(-1);
            }
        }
        
        private void ApplyRotation(int rotation)
        {
            _pieceRotationState += rotation;
            for (int i = 0; i < _piecePos.Length; i++)
            {
                if (rotation < 0)
                {
                    _piecePos[i] -= Tetromino.rotations[0][((_pieceRotationState + 1) + 4) % 4][i];
                }
                else if (rotation > 0)
                {
                    _piecePos[i] += Tetromino.rotations[0][_pieceRotationState % 4][i];
                }
            }
            if (_pieceRotationState > 3 || _pieceRotationState < 0)
            {
                _pieceRotationState = (_pieceRotationState + 4) % 4;
            }
        }
        private void SetNewPiece()
        {
            Tetromino.SetNewPiece(out _piecePos, out _currentPieceNum);
        }

        private void UndoMove()
        {
            _piecePos = (Point2D[])_previousPiecePos.Clone();
        }

    }
}
