<<<<<<< HEAD
﻿using TwoVTwoTris.Entities;
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
=======
﻿using Raylib_cs;
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
>>>>>>> refs/remotes/origin/main
        }

    }
}
