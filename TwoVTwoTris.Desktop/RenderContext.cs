using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TwoVTwoTris.Desktop
{
    internal class RenderContext
    {
        private Rectangle renderSource;
        private Rectangle renderDestination;
        internal RenderTexture2D mainRenderer;

        internal RenderContext(int width, int height)
        {
            mainRenderer = Raylib.LoadRenderTexture(width, height);
            renderSource = new Rectangle(0, 0, width, -height);
            renderDestination = new Rectangle(0, 0, width, height);
        }
        
        internal void Render()
        {
            Raylib.DrawTexturePro(mainRenderer.Texture, renderSource, renderDestination, new Vector2(0, 0), 0, Color.White);
        }

    }
}
