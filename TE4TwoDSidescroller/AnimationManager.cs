using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    public class AnimationManager
    {
        private Animation animation;

        private float timer;

        public Vector2 Position { get; set; }

        public AnimationManager(Animation newAnimation)
        {
            animation = newAnimation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(animation.Texture, Position,
                new Rectangle(animation.CurrentFrame * animation.FrameWidth, 0, animation.FrameWidth, animation.FrameHeight),
                Color.White);
        }
        public void Play(Animation newAnimation)
        {
            if(animation == newAnimation)
            {
                return;
            }

            animation = newAnimation;

            animation.CurrentFrame = 0;

            timer = 0f;
        }

        public void Stop()
        {
            timer = 0;

            animation.CurrentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(timer > animation.FrameSpeed)
            {
                timer = 0f;

                animation.CurrentFrame++;

                if(animation.CurrentFrame >= animation.FrameCount)
                {
                    animation.CurrentFrame = 0;
                }
            }
        }
    }
}
