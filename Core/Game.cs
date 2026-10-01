using Raylib_cs;


namespace TwoVTwoTris.Core
{
    public class Game
    {
        public Rectangle renderSource;
        public Rectangle renderDestination;
        public RenderTexture2D mainRenderer;

        public Game(int width, int height)
        {
            mainRenderer = Raylib.LoadRenderTexture(width, height);
            renderSource = new Rectangle(0, 0, width, -height);
            renderDestination = new Rectangle(0, 0, width, height);
        }

        public void Update()
        {

        }
        public void UI()
        {

        }
        public void Render()
        {
            Raylib.DrawText("Hello World!", 200, 100, 50, Color.Black);
        }
    }
}
