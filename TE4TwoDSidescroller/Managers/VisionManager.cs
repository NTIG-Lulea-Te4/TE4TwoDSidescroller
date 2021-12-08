using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TE4TwoDSidescroller
{
    public class VisionManager : Entity
    {
        Viewport viewport;

        int Xsize;
        int Ysize;

        int Xposition;
        int Yposition;

        public VisionManager()
        {
            Xsize = 1280;
            Ysize = 720;

        }

        public override void Update(GameTime gameTime)
        {

            Xposition = (int)GameInfo.player1Position.X + GameInfo.Player1TextureSize.Width / 2;
            Yposition = (int)GameInfo.player1Position.Y - GameInfo.Player1TextureSize.Height / 2;
            viewport = new Viewport(-Xposition + Xsize / 2, -Yposition + Ysize / 2, Xsize, Ysize);
            GameInfo.graphicsDevice.GraphicsDevice.Viewport = viewport;
            GameInfo.viewportPosition.X = -viewport.X;
            GameInfo.viewportPosition.Y = -viewport.Y;




        }

        public Viewport NewViewport()
        {

            //finns bättre lösning för nu. settings???
            return viewport;

        }



        #region Abbes kod

        //public void Initialize()
        //{
        //    screenPosition = Vector2.Zero;
        //}


        //public void Draw(Texture2D currentTexture, Vector2 position, Rectangle sourceRectangle, 
        //    Color color, float rotation, Vector2 origin, float scale, SpriteEffects spriteEffects, float layerDepth)
        //{
        //    position.X -= screenPosition.X;
        //    position.Y -= screenPosition.Y;

        //    GameInfo.spriteBatch.Draw(currentTexture, position, sourceRectangle, 
        //        color, rotation, origin, scale, spriteEffects, layerDepth);
        //}

        //public void UpdateToDraw(Vector2 playerPosition)
        //{

        //}
        #endregion
    }
}
