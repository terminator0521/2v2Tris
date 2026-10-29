using raygui_cs;
using Raylib_cs;
using TwoVTwoTris.Entities;
using TwoVTwoTris.Input;
namespace TwoVTwoTris.Core.Scenes
{
    internal class SettingScene : Scene
    {
        int[] mykey = new int[7];
        TestBlock block;
        IInputManager[] i;

        internal SettingScene() : base()
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
            Raygui.GuiLabel(new Rectangle(100, 100, 200, 50), "Settings");
            Raygui.GuiLabel(new Rectangle(0, 100, 200, 50), "Settings");
            if (Raygui.GuiButton(new Rectangle(1000, 1000, 200, 200), "hello") == 1)
            {
                Console.WriteLine("goon");
            }
        }

        override internal Scene SetNextScene()
        {
            return null;
        }



    }
}
