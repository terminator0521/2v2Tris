using raygui_cs;
using Raylib_cs;
using TwoVTwoTris.Input;
using System.Numerics;
using TwoVTwoTris.Input;

namespace TwoVTwoTris.Core.Scenes
{
    internal class SettingsScene : Scene
    {
        // Settings State Values
        private Boolean rebindingIndex = false;
        private int position;
        private float arr;
        private float das;
        private float dcd;
        private float sdf;

        private Rectangle panelBounds = new Rectangle(0, 0, 1280, 720);   // The visible viewport
        private Rectangle panelContent = new Rectangle(0, 0, 1280, 2500);   // Total size of your content canvas
        private Vector2? scrollOffset = new Vector2(0, 0);                 // Maintains positions between frames
        private Rectangle? view = new Rectangle(0, 0, 0, 0);               // Automatically managed view rectangle



        private int[] keyCodes;


        IInputManager[] i;

        string[] inputText = new string[] { "Move Left", "Move Right", "Rotate Clockwise", "Rotate Counter Clockwise", "Rotate 180", "Soft Drop", "Hard Drop", "Hold" };

        internal SettingsScene() : base()
        {
            keyCodes = new int[] { InputSettings.keyCodeRight
        ,InputSettings.keyCodeLeft
         ,InputSettings.keyCodeCW
         ,InputSettings.keyCodeCCW
         ,InputSettings.keyCode180
         ,InputSettings.keyCodeSD
         ,InputSettings.keyCodeHD
         ,InputSettings.keyCodeHold};

            if (Raylib.IsKeyPressed((KeyboardKey)InputSettings.hardDrop))
            {
                //
            }

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

            arr = Raygui.GuiSlider(
                new Rectangle(contentStartX + 70, contentStartY + 40, 250, 30),
                "ARR",
                arr.ToString("0.0"),
                arr,
                0.0f,
                5.0f
            );

            das = Raygui.GuiSlider(
                new Rectangle(contentStartX + 70, contentStartY + 100, 250, 30),
                "DAS",
                das.ToString("0.0"),
                das,
                0.0f,
                20.0f
            );

            dcd = Raygui.GuiSlider(
                new Rectangle(contentStartX + 70, contentStartY + 160, 250, 30),
                "DCD",
                dcd.ToString("0.0"),
                dcd,
                0.0f,
                20.0f
            );

            sdf = Raygui.GuiSlider(
                new Rectangle(contentStartX + 70, contentStartY + 220, 250, 30),
                "SDF",
                sdf.ToString("0.0"),
                sdf,
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
        }

        internal override void GetInputs(IInputManager[] inputManagers)
        {
            base.GetInputs(inputManagers);
        }
    }
}