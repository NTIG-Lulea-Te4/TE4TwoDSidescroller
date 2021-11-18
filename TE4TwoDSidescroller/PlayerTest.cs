using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class PlayerTest : Entity
    {

        Texture2D playerTestTexture;
        public static Rectangle testRectangle;


        public PlayerTest()
        {

            testRectangle = new Rectangle(500, 0, 101, 101);

            LoadTexture2D();

        }


        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/" + "PurpleBox.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                playerTestTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }



        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                testRectangle.X -= (1 * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                testRectangle.X += (1 * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                testRectangle.Y += (1 * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                testRectangle.Y -= (1 * gameTime.ElapsedGameTime.Milliseconds);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            //GameInfo.spriteBatch.Draw(playerTestTexture, testRectangle, Color.White);

        }

    }
}
