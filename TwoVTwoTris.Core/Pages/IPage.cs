namespace TwoVTwoTris.Core.Pages
{
    /// <summary>
    /// Abstract class for creating a page that manages a state of the game.
    /// </summary>
    internal interface IPage
    {
        /// <summary>
        /// Runs game logic updates
        /// </summary>
        internal void Update();

        /// <summary>
        /// Put all rendering code here as it is linked to the main render context. Do not use Raylib.BeginDrawing() or Raylib.EndDrawing() here.
        /// </summary>
        internal void Render();

        /// <summary>
        /// Put all UI code here as it is linked to the main render context. Do not use Raylib.BeginDrawing() or Raylib.EndDrawing() here.
        /// </summary>
        internal void UI(); //ui updates

        internal IPage SetNextPage();
    }
}
