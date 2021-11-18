using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Knight : Character
    {

        Texture2D testTexture;
        Rectangle detectionHitbox;
        Rectangle knightRectangle;
        int posistionX;
        int posistionY;

        Health health;
        int maxHealth;
        int currentHealth;

        public Knight()
        {
            health = new Health();
            detectionHitbox = new Rectangle(0, 0, 150, 150);
            knightRectangle = new Rectangle(0, 0, 101, 101);

            LoadTexture2D();
        }

        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/" + "Box.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                testTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }



        public override void Update(GameTime gameTime)
        {
            #region Controls for testing
            //if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //{
            //    knightRectangle.X -= (1 * gameTime.ElapsedGameTime.Milliseconds);
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //{
            //    knightRectangle.X += (1 * gameTime.ElapsedGameTime.Milliseconds);
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //{
            //    knightRectangle.Y += (1 * gameTime.ElapsedGameTime.Milliseconds);
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    knightRectangle.Y -= (1 * gameTime.ElapsedGameTime.Milliseconds);
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
            //{
            //    knightRectangle.Y = 0;
            //    knightRectangle.X = 0;

            //}
            #endregion




            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (GameInfo.collisionManager.CollisionRectangleCheck(knightRectangle, PlayerTest.testRectangle))
            {
                GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.Pink);
            }
            else
            {
                GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);
            }

            GameInfo.spriteBatch.Draw(testTexture, knightRectangle, Color.White);

            // base.Draw(gameTime);
        }

    }
}
