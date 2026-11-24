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

        //piece type | rotation state | block index

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

        static public void ApplyRotation(ref int rotationState, ref Point2D[] piece, int rotation)
        {
            rotationState += rotation;
            for (int i = 0; i < piece.Length; i++)
            {
                if (rotation < 0)
                {
                    piece[i] -= _rotations[0][((rotationState + 1) + 4) % 4][i];
                }
                else if (rotation > 0)
                {
                    piece[i] += _rotations[0][rotationState % 4][i];
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