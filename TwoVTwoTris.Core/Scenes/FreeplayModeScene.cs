using Raylib_cs;
using TwoVTwoTris.Input;

namespace TwoVTwoTris.Core.Scenes
{
    internal class FreeplayModeScene : Scene
    {
        Rectangle _playingBoard;
        Player _player;
        private int _tileSize = 30;
        IInputManager[] i;


        internal FreeplayModeScene()
        {
            _playingBoard = new Rectangle(490, 10, _tileSize * 10, _tileSize * 23);
            _player = new Player(_playingBoard, _tileSize);

            i = [
                _player,
                ];
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
            GetInputs(i);
            _player.Update();
        }

        internal override void GetInputs(IInputManager[] inputManagers)
        {
            base.GetInputs(inputManagers);
        }
    }
}
