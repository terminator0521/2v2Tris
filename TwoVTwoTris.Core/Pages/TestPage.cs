using Raylib_cs;
using RayGui_cs;

namespace TwoVTwoTris.Core.Pages
{
    internal class TestPage : IPage
    {
        

        public void Update()
        {

        }
        public void Render()
        {
            
        }
        public void UI()
        {
            GuiStyle.Set(GuiDefaultProperty.TextSize, 40);
            Gui.Label(new(200, 200, 600, 200), "hello world");
        }
        public IPage SetNextPage()
        {
                return null;
        }

    }
}
