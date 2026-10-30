using raygui_cs;
using Raylib_cs;
using TwoVTwoTris.Input;
using System.Numerics;

namespace TwoVTwoTris.Core.Scenes
{
    internal class SettingsScene : Scene
    {
        // Settings State Values
        private float arr;
        private float das;
        private float dcd;
        private float sdf;

        // CRITICAL FIX: Persistent Scroll States (Class fields prevent resetting every frame)
        private Rectangle panelBounds = new Rectangle(0, 0, 1280, 720);   // The visible viewport
        private Rectangle panelContent = new Rectangle(0, 0, 1280, 720);   // Total size of your content canvas
        private Vector2? scrollOffset = new Vector2(0, 0);                 // Maintains positions between frames
        private Rectangle? view = new Rectangle(0, 0, 0, 0);               // Automatically managed view rectangle

        IInputManager[] i;
        
        internal SettingsScene() : base()
        {
        }

        internal override void Render()
        {
            // Handled globally in main loop, or put your drawing logic cleanly here if scene-managed
        }

        internal override Scene SetNextScene()
        {
            return null;
        }

         internal override void UI()
        {
            // 1. Draw the scroll panel container layout (Updates our nullable class fields)
            Raygui.GuiScrollPanel(panelBounds, "Settings Panel", panelContent, ref scrollOffset, ref view);

            // FIX CS1061: Extract the underlying safe struct values here!
            Rectangle actualView = view.GetValueOrDefault();
            Vector2 actualOffset = scrollOffset.GetValueOrDefault();

            // 2. Bound inside a safe Scissor clipping viewport using our EXTRACTED local variable
            Raylib.BeginScissorMode((int)actualView.X, (int)actualView.Y, (int)actualView.Width, (int)actualView.Height);

            // Calculate anchor positions matching the moving view content offset using our EXTRACTED local variable
            float contentStartX = panelBounds.X + actualOffset.X;
            float contentStartY = panelBounds.Y + actualOffset.Y;

            // 3. Render sliders inside the moving offset system
            arr = Raygui.GuiSlider(
                new Rectangle(contentStartX + 20, contentStartY + 40, 250, 30),
                "ARR",
                arr.ToString("0.0"),
                arr,
                0.0f,
                5.0f
            );

            das = Raygui.GuiSlider(
                new Rectangle(contentStartX + 20, contentStartY + 100, 250, 30),
                "DAS",
                das.ToString("0.0"),
                das,
                0.0f,
                20.0f
            );

            dcd = Raygui.GuiSlider(
                new Rectangle(contentStartX + 20, contentStartY + 160, 250, 30),
                "DCD",
                dcd.ToString("0.0"),
                dcd,
                0.0f,
                20.0f
            );

            sdf = Raygui.GuiSlider(
                new Rectangle(contentStartX + 20, contentStartY + 220, 250, 30),
                "SDF",
                sdf.ToString("0.0"),
                sdf,
                5.0f,
                40.0f
            );

            // 4. Close the scissor mode rendering mask cleanly
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