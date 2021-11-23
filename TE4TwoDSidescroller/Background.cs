using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using MonoGame;

namespace TE4TwoDSidescroller
{
    class Background : LevelTutorial
    {
        Texture2D myTexture;
        Rectangle myRectangle;


        public Background()
        {

            string currentPath =
           Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Background.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {

                myTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw(myTexture, myRectangle);


        }

    }
}
