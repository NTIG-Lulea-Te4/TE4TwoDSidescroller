using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TE4TwoDSidescroller
{
    public class EntityAnimation
    {

        protected Texture2D currentTexture;
        protected Vector2 currentOrigin;
        protected Rectangle sourceRectangle;
        protected Vector2 currentPosition;
        protected float scale;
        protected float rotation;
        protected bool isLooping;
        protected int currentFrame;
        protected int currentFrameCount;
        protected float timeElapsed;
        protected float timeToUpdateFrame;
        protected float layerDepth;
        protected SpriteEffects spriteEffects;

        public EntityAnimation(Texture2D texture, int currentFrame, int currentFrameCount, Vector2 currentOrigin)
        {

        }

        public void UpdateDraw(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdateFrame)
            {
                currentFrame++;
            }
        }

    }
}
