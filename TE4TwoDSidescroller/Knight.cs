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

        Texture2D knightTexture;
        Rectangle detectionHitbox;
        Rectangle knightRectangle;
        Rectangle sourceRectangle;
        Vector2 movementDirection;
        Vector2 knightPosition;
        int posistionX;
        int posistionY;
        Color[] colorData;

        Health health;
        int maxHealth;
        int currentHealth;
        float speed;


        public Knight()
        {

            speed = 0.2f;

            health = new Health();
            detectionHitbox = new Rectangle(0, 0, 500, 500);
            knightRectangle = new Rectangle(0, 0, 101, 101);
            sourceRectangle = new Rectangle(0, 0, 101, 101);
            knightPosition = new Vector2();
            movementDirection = new Vector2();

            LoadTexture2D();

            colorData = new Color[knightTexture.Width * knightTexture.Height];
        }

        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/" + "Box.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                knightTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }



        public override void Update(GameTime gameTime)
        {
            #region Controls for testing
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                knightPosition.X -= (1 * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                knightPosition.X += (1 * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                knightPosition.Y += (1 * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                knightPosition.Y -= (1 * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                knightPosition.Y = 0;
                knightPosition.X = 0;

            }
            #endregion

            //movementDirection = PlayerTest.playerPosition - knightPosition;
            //movementDirection.Normalize();


            //if (GameInfo.collisionManager.CollisionRectangleCheck(detectionHitbox, PlayerTest.testRectangle))
            //{

            //    knightPosition += movementDirection * speed * gameTime.ElapsedGameTime.Milliseconds;

            //}

            detectionHitbox.X = (int)knightPosition.X;
            detectionHitbox.Y = (int)knightPosition.Y;
            knightRectangle.X = (int)knightPosition.X;
            knightRectangle.Y = (int)knightPosition.Y;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (GameInfo.collisionManager.PixelPerfectCollision(knightRectangle, PlayerTest.testRectangle,
                colorData, PlayerTest.colorData))
            {
                GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.Pink);
            }
            else
            {
                GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);
            }

            GameInfo.spriteBatch.Draw(knightTexture, knightPosition, sourceRectangle, Color.White);

            // base.Draw(gameTime);
        }

    }
}
