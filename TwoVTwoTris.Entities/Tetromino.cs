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

        static public void SetNewPiece(out Point2D[] piece)
        {
            piece = (Point2D[])_origin[0].Clone();
        }

        //piece type | rotation state | block index

        //add to go clockwise, which increase 
        readonly static public Point2D[][][] _rotations =
        {
            //I piece
            [
                [new(-1, -2), new(0, -1), new(1, 0), new(2, 1)],
                [new(2, -1), new(1, 0), new(0, 1), new(-1, 2)],
                [new(1, 2), new(0, 1), new(-1, 0), new(-2, -1)],
                [new(-2, 1), new(-1, 0), new(0, -1), new(1, -2)],
            ],

        };
    }
}