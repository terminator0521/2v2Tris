using Raylib_cs;

namespace App
{
    public class App
    {
        public void run()
        {
            var Game = new Core.Game();

            while (!Raylib.WindowShouldClose())
            {
                Game.Update();

                Raylib.BeginDrawing();
                Game.Draw();
                Raylib.EndDrawing();
            }
        }
    }
}
