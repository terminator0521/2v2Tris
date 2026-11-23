using System;
using Raylib_cs;
using raygui_cs;
using TwoVTwoTris.Input;

namespace TwoVTwoTris.Core.Scenes;

internal class MainMenuScene : Scene
{
    private int _nextScene = 0;
    internal override void Render()
    {
        
    }

    internal override Scene SetNextScene()
    {
        if (_nextScene == 1)
        {
            return new SettingsScene();
        }else{
       return null;
        }
    }

    internal override void UI()
    {
        Rectangle MultiplayButton = new Rectangle(100, 100, 600, 100);
        Raygui.GuiButton(MultiplayButton, "Play Multiplayer");
        Rectangle SinglePlayButton = new Rectangle(100, 250, 600, 100);
        Raygui.GuiButton(SinglePlayButton, "Play Singleplayer");
        Rectangle stats = new Rectangle(100, 550, 500, 100);
        Raygui.GuiButton(stats, "Statistics");
        Rectangle settings = new Rectangle(100, 400, 500, 100);
        int settingRoute = Raygui.GuiButton(settings, "Settings");
        if(settingRoute == 1)
        {
            _nextScene = 1;
        }
    }

    internal override void Update()
    {
        
    }
}
