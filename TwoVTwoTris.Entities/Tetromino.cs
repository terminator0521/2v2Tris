using TwoVTwoTris.Lib;

namespace TwoVTwoTris.Entities
{


    static public class Tetromino
    {
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
        private static int width;
        private static int height;
        readonly static private Point2D[][] _origin =
        {
            [new Point2D(3, 2), new Point2D(4, 2), new Point2D(5, 2), new Point2D(6, 2)], //i piece
            [new Point2D(4, 1), new Point2D(5, 1), new Point2D(4, 2), new Point2D(5, 2)], //o piece
            [new Point2D(3, 1), new Point2D(3, 2), new Point2D(4, 2), new Point2D(5, 2)], //j piece
        };

        //Indicies -> piece type | rotation state | block index

        //add to go clockwise, which increase 
        readonly static public Point2D[][][] rotations =
        {
            //I piece
            [
                [new(-1, -2), new(0, -1), new(1, 0), new(2, 1)],
                [new(2, -1), new(1, 0), new(0, 1), new(-1, 2)],
                [new(1, 2), new(0, 1), new(-1, 0), new(-2, -1)],
                [new(-2, 1), new(-1, 0), new(0, -1), new(1, -2)],
            ],
            //O piece
            [
                [new(0, 0), new(0, 0), new(0, 0), new(0, 0)],
                [new(0, 0), new(0, 0), new(0, 0), new(0, 0)],
                [new(0, 0), new(0, 0), new(0, 0), new(0, 0)],
                [new(0, 0), new(0, 0), new(0, 0), new(0, 0)],
            ],
            //3 x 3 matrix pieces 
            [
                [new(0, -2), new(-1, -1), new(0, 0), new(1, 1)],
                [new(2, 0), new(1, -1), new(0, 0), new(-1, 1)],
                [new(0, 2), new(1, 1), new(0, 0), new(-1, -1)],
                [new(-2, 0), new(-1, 1), new(0, 0), new(1, -1)],
            ],
        };

        // Indecies -> Piece type | rotation State | kick offset tests
        readonly static public Point2D[][][] kicks =
        {

        };

        static public void SetNewPiece(out Point2D[] piece, out int piecenum)
        {
            int i = 2;
            piece = (Point2D[])_origin[i].Clone();
            piecenum = i; 
        }

        static public void ApplyRotation(ref int rotationState, ref Point2D[] piece, ref int[,] gameB, int rotation)
        {
            // if false, not i piece, if true, i piece
            bool pieceType = (piece[0].X == piece[1].X && piece[1].X == piece[2].X && piece[2].X == piece[3].X) || (piece[0].Y == piece[1].Y && piece[1].Y == piece[2].Y && piece[2].Y == piece[3].Y);
            Point2D[] prevPiece = (Point2D[])piece.Clone();
            Point2D[][] modificationsCW = {
                [new(0,0),new(-1,0),new(-1,1),new(0,-2),new(-1,-2)],
                [new(0,0),new(+1,0),new(+1,-1),new(0,+2),new(1,2)],
                [new(0,0),new(1,0),new(+1,1),new(0,-2),new(1,-2)],
                [new(0,0),new(-1,0),new(-1,-1),new(0,2),new(-1,+2)],
            };
            Point2D[][] modificationsCC = {
                [new(0,0),new(1,0),new(+1,-1),new(0,2),new(1,2)],
                [new(0,0),new(-1,0),new(-1,+1),new(0,-2),new(-1,-2)],
                [new(0,0),new(-1,0),new(-1,-1),new(0,+2),new(-1,2)],
                [new(0,0),new(1,0),new(1,+1),new(0,-2),new(-1,2)],
            };
            Point2D[][] modificationsCWI = {
                [new(0,0), new(-2,0), new(+1,0), new(-2,-1), new(+1,+2)], // 0->R
                [new(0,0), new(-1,0), new(+2,0), new(-1,+2), new(+2,-1)], // R->2
                [new(0,0), new(+2,0), new(-1,0), new(+2,+1), new(-1,-2)], // 2->L
                [new(0,0), new(+1,0), new(-2,0), new(+1,-2), new(-2,+1)], // L->0
            };

            Point2D[][] modificationsCCI = {
                [new(0,0), new(-1,0), new(+2,0), new(-1,+2), new(+2,-1)], // 0->L
                [new(0,0), new(-2,0), new(+1,0), new(-2,-1), new(+1,+2)], // L->2
                [new(0,0), new(+1,0), new(-2,0), new(+1,-2), new(-2,+1)], // 2->R
                [new(0,0), new(+2,0), new(-1,0), new(+2,+1), new(-1,-2)], // R->0
            };
            int oldRotationState = rotationState;
            rotationState += rotation;
            // rotate counterclockwise
            if (rotation < 0)
            {
                int checks = 0;

                // iterate through each test
                for (int j = 0; j < 5; j++)
                {
                    // iterate through each square of the tetrimino
                    for (int k = 0; k < 4; k++)
                    {
                        piece[k] += rotations[0][rotationState % 4][k];
                        piece[k] += pieceType ? modificationsCCI[oldRotationState][j] : modificationsCC[oldRotationState][j];
                        //check if it is a possible locate, addiding to checks
                        // if colliding with game object or out of bounds
                        if ((gameB[piece[k].Y, piece[k].X] == 0) && piece[k].X < gameB.GetLength(1) && piece[k].Y < gameB.Length && piece[k].X > 0)
                        {
                            checks++;
                        }
                    }
                    if (checks == 4)
                    {
                        break;
                    }
                    else
                    {
                        checks = 0;
                        piece = prevPiece;
                    }
                }
            }
            // rotate clockwise
            else if (rotation > 0)
            {
                int checks = 0;

                // iterate through each test
                for (int j = 0; j < 5; j++)
                {
                    // iterate through each square of the tetrimino
                    for (int k = 0; k < 4; k++)
                    {
                        piece[k] += rotations[0][rotationState % 4][k];
                        piece[k] += pieceType ? modificationsCWI[oldRotationState][j] : modificationsCW[oldRotationState][j];
                        //check if it is a possible locate, addiding to checks
                        // if colliding with game object or out of bounds
                        if ((gameB[piece[k].Y, piece[k].X] == 0) && (piece[k].X < gameB.GetLength(1) || piece[k].Y < gameB.Length))
                        {
                            checks++;
                        }
                    }
                    if (checks == 4)
                    {
                        break;
                    }
                    else
                    {
                        checks = 0;
                        piece = prevPiece;
                    }
                }

            }

        }

        static public void InitBoard(int width, int height)
        {
            Tetromino.width = width;
            Tetromino.height = height;
        }

        static public bool Kick()
        {


            return false;
        }
    }
}