using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace TE4TwoDSidescroller
{
    class Floor : LevelTutorial
    {
        Texture2D myTexture;
        Vector2 myPosition;
        public Rectangle myRectangle;
        public Floor()
        {

            PixelDraw();
        }


        public void PixelDraw()
        {

            myPosition = new Vector2(0, 400);
            myRectangle = new Rectangle((int)myPosition.X, (int)myPosition.Y, 900, 50);
            myTexture = new Texture2D
                (GameInfo.graphicsDevice.GraphicsDevice, myRectangle.Width, myRectangle.Height);
            Color[] data = new Color[myRectangle.Width * myRectangle.Height];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.Red;
            }

            myTexture.SetData(data);

        }





        public override void Draw(GameTime gameTime)
        {


            GameInfo.spriteBatch.Draw(myTexture, myRectangle, Color.Red);


        }
        public override void Update(GameTime gameTime)
        {



        }



    }
}
