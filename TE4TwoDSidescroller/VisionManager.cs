using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TE4TwoDSidescroller
{
    public class VisionManager
    {
        static Vector2 screenPosition;

        static private int worldWidth;

        static private int worldHeight;

        


        public void IniInitialize()
        {
            screenPosition = Vector2.Zero;
        }


        public void Draw(Texture2D currentTexture, Vector2 position, Rectangle sourceRectangle, 
            Color color, float rotation, Vector2 origin, float scale, SpriteEffects spriteEffects, float layerDepth)
        {
            position.X -= screenPosition.X;
            position.Y -= screenPosition.Y;

            GameInfo.spriteBatch.Draw(currentTexture, position, sourceRectangle, 
                color, rotation, origin, scale, spriteEffects, layerDepth);
        }

        public void UpdateToDraw(Vector2 playerPosition)
        {

        }

    }
}
