using RayGui_cs;
using TwoVTwoTris.Entities;

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
            GuiStyle.Set(GuiDefaultProperty.TextSize, 40);
            Gui.Label(new(200, 200, 600, 200), "hello world");
        }

        override internal Page SetNextPage()
        {
            return null;
        }

    }
}
