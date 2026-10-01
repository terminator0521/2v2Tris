using Raylib_cs;
using System.Numerics;
using TwoVTwoTris.Core;

namespace TwoVTwoTris.Desktop
{
    public class Program
    {
        public static void Main()
        {
            Raylib.InitWindow(1280, 720, "TwoVTwoTris");
            var game = new Game(1280, 720);

            while (!Raylib.WindowShouldClose())
            {
                game.Update();

                Raylib.BeginTextureMode(game.mainRenderer);
                Raylib.ClearBackground(Color.White);
                game.Render();
                Raylib.EndTextureMode();


                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawTexturePro(game.mainRenderer.Texture, game.renderSource, game.renderDestination, new Vector2(0, 0), 0, Color.White);
                game.UI();
                Raylib.EndDrawing();
            }
        }
    }
}
