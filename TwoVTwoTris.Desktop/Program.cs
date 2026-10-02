using Raylib_cs;
using raygui_cs;
using TwoVTwoTris.Core;

namespace TwoVTwoTris.Desktop
{
    internal class Program
    {
        public static void Main()
        {
            Raylib.InitWindow(1280, 720, "TwoVTwoTris");
            Raylib.InitAudioDevice();
            Raylib.SetTargetFPS(60);
            var renderContext = new RenderContext(1280, 720); //create main render context
            var game = new Game(); //create game instance

            while (!Raylib.WindowShouldClose())
            {
                //logic updates
                game.Update();

                //draw in main renderer context
                Raylib.BeginTextureMode(renderContext.mainRenderer);
                Raylib.ClearBackground(Color.White); //reset renderer
                game.Render(); ;//render game to main renderer
                Raylib.EndTextureMode();
                
                //draw in window context
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black); //reset renderer
                renderContext.Render(); //draw main renderer to window
                game.UI(); //draw ui
                Raygui.GuiSetStyle((int)GuiControl.DEFAULT, (int)GuiDefaultProperty.TEXT_SIZE, 20);
                Raylib.EndDrawing();

                game.GetPage(); //get next page
            }
        }
    }
}
