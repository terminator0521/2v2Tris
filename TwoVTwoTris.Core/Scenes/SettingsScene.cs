using raygui_cs;

namespace TwoVTwoTris.Core.Scenes
{
    internal class SettingsScene : Scene
    {
        private float arr;
        private float das;
        private float dcd;
        private float sdf; 
        internal SettingsScene() : base() { }

        internal override void Render()
        {

        }

        internal override Scene SetNextScene()
        {
            return null;
        }

        internal override void UI()
        {
            arr = Raygui.GuiSlider(
                new Raylib_cs.Rectangle(100, 100, 300, 30)
                ,"ARR"
                ,arr+""
                ,arr
                ,0.0f
                ,5.0f
                );
            das = Raygui.GuiSlider(
                new Raylib_cs.Rectangle(100, 200, 300, 30)
                ,"DAS"
                ,das+""
                ,das
                ,0.0f
                ,20.0f
                );
            dcd = Raygui.GuiSlider(
                new Raylib_cs.Rectangle(100, 300, 300, 30)
                ,"DCD"
                ,dcd+""
                ,dcd
                ,0.0f
                ,20.0f
                );
            sdf = Raygui.GuiSlider(
                new Raylib_cs.Rectangle(100, 400, 300, 30)
                ,"SDF"
                ,sdf+""
                ,sdf
                ,5.0f
                ,40.0f
                );

            

        }

        internal override void Update()
        {
        }
    }
}
