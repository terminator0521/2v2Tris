using System.Drawing;
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

        readonly static private Point2D[][] _origin =
        {
            [new Point2D(3, 2), new Point2D(4, 2), new Point2D(5, 2), new Point2D(6, 2)]
        };

        //Indicies -> piece type | rotation state | block index

        //add to go clockwise, which increase 
        readonly static private Point2D[][][] _rotations =
        {
            //I piece
            [
                [new(-1, -2), new(0, -1), new(1, 0), new(2, 1)],
                [new(2, -1), new(1, 0), new(0, 1), new(-1, 2)],
                [new(1, 2), new(0, 1), new(-1, 0), new(-2, -1)],
                [new(-2, 1), new(-1, 0), new(0, -1), new(1, -2)],
            ],

        };

        static public void ApplyRotation(ref int rotationState, ref Point2D[] piece, ref int[,] gameB,int rotation)
        {
            Point2D[] prevPiece=(Point2D[])piece.Clone();
            rotationState += rotation;
            for (int i = 0; i < piece.Length; i++)
            {
                // rotate counterclockwise
                if (rotation < 0)
                {
                    piece[i] -= _rotations[0][((rotationState + 1) + 4) % 4][i];
                }
                // rotate clockwise
                else if (rotation > 0)
                {
                    piece[i] += _rotations[0][rotationState % 4][i];
                    int checks = 0;
                    Point2D[] modifications = [new(0,0),new(-2,0),new(+1,0),new(-2,-1),new(1,2)];

                    for(int j = 0; j < 4; j++)
                    {
                        //itterate through each block of the piece's location
                        for(int k = 0; k < 5; k++)
                        {
                            piece[j] += modifications[k];
                            //check if it is a possible locate, addiding to checks
                            // if colliding with game object or out of bounds
                            if (gameB[piece[j].X, piece[j].Y] == 0)
                            {
                                
                            }
                            if (piece[j].Y < gameB.Length)
                            {
                                
                            }
                            if (piece[j].X < gameB.GetLength(1))
                            {
                                
                            }
                        }


                    }
                    if (checks == 4)
                    {
                        
                    }

                }
            }

            if (rotationState > 3 || rotationState < 0)
            {
                rotationState = (rotationState + 4) % 4;
            }
        }

        static public void SetNewPiece(out Point2D[] piece)
        {
            piece = (Point2D[])_origin[0].Clone();
        }

       
    }
}