using System.Data;
using System.Numerics;
using Raylib_cs;
namespace TwoVTwoTris.Entities
{
    public class Tetrimino
    {
        public Vector2I position;
        public int[,] shape;
        private Vector2I rotationPoint;
        private int tileSize;
        public static float gravity = -1;
        private Texture2D texture;
        int pieceNumber;
        public Tetrimino(int x, int y, int[] xShape, int[] yShape, Vector2I rotate, int tile,Texture2D text, int pNum)
        {
            position.x= x;
            position.y=y;
            // shape[1] = xShape;
            // shape[,0] = yShape; // HOW TO IMPLEMENT
            rotationPoint = rotate;
            tileSize = tile;
            texture = text;
            pieceNumber = pNum;

        }

        public void Update()
        {
            
        }
        public void Render()
        {
            
        }
        public void Rotate(Vector2I r)
        {
            
        }
        public void SoftDrop(int d)
        {
            
        }
        public void HardDrop()
        {
            
        }
    }
}