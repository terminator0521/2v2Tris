using raygui_cs;
using Raylib_cs;
using TwoVTwoTris.Input;
using System.Numerics;
using TwoVTwoTris.Input;
    using System;
using System.IO;
using System.ComponentModel;
using System.Xml;
using System.IO.Pipelines;

namespace TwoVTwoTris.Core.Scenes{
    internal class SettingsScene : Scene
    {
        // Settings State Values
        private Boolean rebindingIndex = false;
        private int position;

        private Rectangle panelBounds = new Rectangle(0, 0, 1280, 720);   // The visible viewport
        private Rectangle panelContent = new Rectangle(0, 0, 1280, 2500);   // Total size of your content canvas
        private Vector2? scrollOffset = new Vector2(0, 0);                 // Maintains positions between frames
        private Rectangle? view = new Rectangle(0, 0, 0, 0);               // Automatically managed view rectangle
        private int[] keyCodes;
        private float[] settings = new float[4];
        IInputManager[] i;

        string[] inputText = new string[] { "Move Left", "Move Right", "Rotate Clockwise", "Rotate Counter Clockwise", "Rotate 180", "Soft Drop", "Hard Drop", "Hold" };

        internal SettingsScene() : base()
        {
            InputSettings.getInputs();
            keyCodes = new int[] { InputSettings.keyCodeRight
            ,InputSettings.keyCodeLeft
            ,InputSettings.keyCodeCW
            ,InputSettings.keyCodeCCW
            ,InputSettings.keyCode180
            ,InputSettings.keyCodeSD
            ,InputSettings.keyCodeHD
            ,InputSettings.keyCodeHold};

            settings = new float[] { InputSettings.arr
            ,InputSettings.das
            ,InputSettings.dcd
            ,InputSettings.sdf};

        }


        internal override void Render()
        {

        }

        internal override Scene SetNextScene()
        {
            return null;
        }

        internal override void UI()
        {
            Rectangle actualView = view.GetValueOrDefault();
            Vector2 actualOffset = scrollOffset.GetValueOrDefault();


            Raylib.BeginScissorMode((int)actualView.X, (int)actualView.Y, (int)actualView.Width, (int)actualView.Height);


            float contentStartX = panelBounds.X + actualOffset.X;
            float contentStartY = panelBounds.Y + actualOffset.Y;

            Raygui.GuiScrollPanel(panelBounds, "Settings Panel", panelContent, ref scrollOffset, ref view);

            settings[0] = Raygui.GuiSlider(
                new Rectangle(contentStartX + 70, contentStartY + 40, 250, 30),
                "ARR",
                settings[0].ToString("0.0"),
                settings[0],
                0.0f,
                5.0f
            );

            settings[1] = Raygui.GuiSlider(
                new Rectangle(contentStartX + 70, contentStartY + 100, 250, 30),
                "das",
                settings[1].ToString("0.0"),
                settings[1],
                0.0f,
                20.0f
            );

            settings[2] = Raygui.GuiSlider(
                new Rectangle(contentStartX + 70, contentStartY + 160, 250, 30),
                "dcd",
                settings[2].ToString("0.0"),
                settings[2],
                0.0f,
                20.0f
            );

            settings[3] = Raygui.GuiSlider(
                new Rectangle(contentStartX + 70, contentStartY + 220, 250, 30),
                "sdf",
                settings[3].ToString("0.0"),
                settings[3],
                5.0f,
                40.0f
            );

            Raygui.GuiSetStyle(10, 10, 50);
            Raygui.GuiLabel(new Rectangle(100, contentStartY + 300, 200, 50), "Keybinds:");

            for (int i = 0; i < inputText.Length; i++)
            {
                Raygui.GuiLabel(new Rectangle(50, contentStartY + 400 + (i * 100), 200, 50), inputText[i]);

                string label;
                if (rebindingIndex && position == i)
                {
                    label = "Press a key...";
                }
                else
                {
                    label = "[" + ((KeyboardKey)keyCodes[i]).ToString() + "]";
                }

                if (Raygui.GuiButton(new Rectangle(600, contentStartY + 400 + (i * 100), 200, 100), label) == 1)
                {
                    rebindingIndex = true;
                    position = i;
                }
            }

            if (rebindingIndex)
            {
                int key = Raylib.GetKeyPressed();
                if (key != 0)
                {
                    keyCodes[position] = key;
                    rebindingIndex = false;
                }
            }

            Raylib.EndScissorMode();
        }

        internal override void Update()
        {
            GetInputs(i);
            float[] setsKeys = [..settings, ..keyCodes];
            InputSettings.writeInputs(setsKeys);
        }

        internal override void GetInputs(IInputManager[] inputManagers)
        {
            base.GetInputs(inputManagers);
        }
    }
}