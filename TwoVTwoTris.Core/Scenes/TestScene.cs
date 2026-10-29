using raygui_cs;
using Raylib_cs;
using TwoVTwoTris.Entities;
using TwoVTwoTris.Input;
namespace TwoVTwoTris.Core.Scenes
{
    internal class TestScene : Scene
    {
        TestBlock block;
        IInputManager[] i;
        private Scene j;

        internal TestScene() : base()
        {
            block = new TestBlock();
            i = [block];

        }

        override internal void Update()
        {
            GetInputs(i);
        }
        override internal void Render()
        {
            block.Draw();
        }
        override internal void UI()
        {
            // Raygui.GuiLabel(new Rectangle(100, 100, 200, 50), "Test Page");
            // if (Raygui.GuiButton(new Rectangle(100, 100, 200, 200), "Night") == 1)
            // {
            //     Console.WriteLine("hiosfoss");
            // }
        }

        override internal Scene SetNextScene()
        {
            return j;
        }

    }
}
