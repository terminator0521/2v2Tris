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

        static public void ApplyRotation(ref int rotationState, ref Point2D[] piece, ref int[,] gameB, int rotation)
        {
            Point2D[] prevPiece=(Point2D[])piece.Clone();
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
            rotationState += rotation;
            for (int i = 0; i < piece.Length; i++)
            {
                // rotate counterclockwise
                if (rotation < 0)
                {
                    //piece[i] += _rotations[0][rotationState % 4][i];
                    int checks = 0;

                    // iterate through each test
                    for(int j = 0; j < 5; j++)
                    {
                        // iterate through each square of the tetrimino
                        for(int k = 0; k < 4; k++)
                        {
                            piece[k] += modificationsCC[rotationState-1][j];
                            //check if it is a possible locate, addiding to checks
                            // if colliding with game object or out of bounds
                            if ((gameB[piece[k].Y, piece[k].X] == 0) && (piece[k].X < gameB.GetLength(1)||piece[k].Y < gameB.Length))
                            {
                                checks++;
                            }
                        }
                        if (checks == 4){
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
                    //piece[i] += _rotations[0][rotationState % 4][i];
                    int checks = 0;

                    // iterate through each test
                    for(int j = 0; j < 5; j++)
                    {
                        // iterate through each square of the tetrimino
                        for(int k = 0; k < 4; k++)
                        {
                            piece[k] += modificationsCW[rotationState-1][j];
                            //check if it is a possible locate, addiding to checks
                            // if colliding with game object or out of bounds
                            if ((gameB[piece[k].X, piece[k].Y] == 0) && (piece[k].X < gameB.GetLength(1)||piece[k].Y < gameB.Length))
                            {
                                checks++;
                            }
                        }
                        if (checks == 4){
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