namespace TwoVTwoTris.Core.Scenes
{
    internal class SettingsScene : Scene
    {
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

        }

        internal override void Update()
        {
            GetInputs();
        }
    }
}
