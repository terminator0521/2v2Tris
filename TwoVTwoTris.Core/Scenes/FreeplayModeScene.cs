using Raylib_cs;

namespace TwoVTwoTris.Core.Scenes
{
    internal class FreeplayModeScene : Scene
    {
        Rectangle _playingBoard;
        Player _player;
        private int _tileSize = 30;


        internal FreeplayModeScene()
        {
            _playingBoard = new Rectangle(50, 50, 30 * 10, 30 * 20);
            _player = new Player(_playingBoard, _tileSize);
        }

        internal override void Render()
        {
            _player.Render();
        }

        internal override Scene SetNextScene()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Backspace))
                return this;
            return null;
        }

        internal override void UI()
        {

        }

        internal override void Update()
        {

        }
    }
}
