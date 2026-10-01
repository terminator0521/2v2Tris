using RayGui_cs;

namespace TwoVTwoTris.Core.Pages
{
    internal class TestPage : Page
    {


        override internal void Update()
        {
            //always GetInput() for internal input manager
        }
        override internal void Render()
        {

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
