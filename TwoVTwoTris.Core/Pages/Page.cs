using TwoVTwoTris.Input;

namespace TwoVTwoTris.Core.Pages
{
    /// <summary>
    /// Abstract class for creating a page that manages a state of the game.
    /// </summary>
    internal abstract class Page
    {
        /// <summary>
        /// Runs game logic updates. 
        ///
        /// Call <cref="GetInputs(params IInputManager[])"/> in this method to use internal input polling for IInputManager members
        /// </summary>
        abstract internal void Update();

        /// <summary>
        /// Put all rendering code here as it is linked to the main render context. Do not use Raylib.BeginDrawing() or Raylib.EndDrawing() here.
        /// </summary>
        abstract internal void Render();

        /// <summary>
        /// Put all UI code here as it is linked to the main render context. Do not use Raylib.BeginDrawing() or Raylib.EndDrawing() here.
        /// </summary>
        abstract internal void UI();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputManagers">Pass </param>
        virtual internal void GetInputs(params IInputManager[] inputManagers)
        {
            foreach (var inputManager in inputManagers)
            {
                inputManager.GetInputs();
            }
        }

        internal abstract Page SetNextPage();
    }
}
