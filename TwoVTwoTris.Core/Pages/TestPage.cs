using TwoVTwoTris.Entities;
using raygui_cs;
using Raylib_cs;
namespace TwoVTwoTris.Core.Pages
{
    internal class TestPage : Page
    {
        TestBlock block = new TestBlock();

        override internal void Update()
        {
            //always GetInputs() for internal input manager
            GetInputs(block);
        }
        override internal void Render()
        {
            block.Draw();
        }
        override internal void UI()
        {
            Raygui.GuiLabel(new Rectangle(100, 100, 200, 50), "Test Page");
        }

        override internal Page SetNextPage()
        {
            return null;
        }

    }
}
