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

        private Texture2D currentTexture;
        private Vector2 currentOrigin;
        private float currentRotation;
        private float currentScale;
        private int frameIndex;
        private Vector2 currentPosition;

        public Rectangle[] sourceRectangles;

        public float timeElapsed;
        public bool isLooping;
        private float timeToUpdate;
        


        public void IniInitialize()
        {
            screenPosition = Vector2.Zero;
        }

        public Texture2D CurrentTexture { get; set; }
        public Vector2 CurrentOrigin { get; set; }
        public float CurrentRotation { get; set; }
        public float CurrentScale { get; set; }
        public int FrameIndex { get; set; }
        public Vector2 CurrentPosition { get; set; }

        public int FramePerSecond
        {
            set
            {
                timeToUpdate = (1f / value);
            }
        }

        public void UpdateFrame(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if ( frameIndex < sourceRectangles.Length - 1) //find what 1 does
                {
                    frameIndex++;
                }
                else if (isLooping)
                {
                    frameIndex = 0;
                }
            }
        }
        
        public void Animate(Texture2D texture, int frames)
        {
            CurrentTexture = texture;
            int frameWidth = texture.Width / frames;
            sourceRectangles = new Rectangle[frames];

            for (int currentFrame = 0; currentFrame < frames; currentFrame++)
            {
                sourceRectangles[currentFrame] = new Rectangle(
                    currentFrame * frameWidth, 0, frameWidth, texture.Height);
            }
        }

        public void Draw(Texture2D currentTexture, Vector2 position, Rectangle sourceRectangle, 
            Color color, float rotation, Vector2 origin, float scale, SpriteEffects spriteEffects, float layerDepth)
        {
            position.X -= screenPosition.X;
            position.Y -= screenPosition.Y;

            GameInfo.spriteBatch.Draw(currentTexture, position, sourceRectangles[frameIndex], 
                color, rotation, origin, scale, spriteEffects, layerDepth);
        }

        public void UpdateToDraw(Vector2 playerPosition)
        {

        }

    }
}
