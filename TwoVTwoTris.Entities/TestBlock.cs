using Raylib_cs;
using System.Numerics;
using TwoVTwoTris.Input;

namespace TwoVTwoTris.Entities
{
    public class TestBlock : IInputManager
    {
        float vel = 670f;
        Vector2 position = new Vector2(0);
        public void GetInputs()
        {

            position += new Vector2(
                (Raylib.IsKeyDown(KeyboardKey.Left) ? -vel * Raylib.GetFrameTime() : 0) + (Raylib.IsKeyDown(KeyboardKey.Right) ? vel * Raylib.GetFrameTime() : 0),
                (Raylib.IsKeyDown(KeyboardKey.Up) ? -vel * Raylib.GetFrameTime() : 0) + (Raylib.IsKeyDown(KeyboardKey.Down) ? vel * Raylib.GetFrameTime() : 0)
                );
        }

        public void Draw()
        {
            Raylib.DrawRectangleV(position, new(50, 50), Color.Beige);
        }
    }
}
