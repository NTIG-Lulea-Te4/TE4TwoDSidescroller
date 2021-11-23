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

        //int gravity; - Game info
        //int currentYAxis; - Entity
        //int currentGravity; - Entity
        //int multiplier;
        //isGrounded - Entity

        private Texture2D knightTexture;
        private Rectangle detectionHitbox;
        private Rectangle knightRectangle;
        private Rectangle sourceRectangle;
        private Vector2 movementDirection;
        private Vector2 knightPosition;
        private Vector2 knightOrigin;
        private int posistionX;
        private int posistionY;
        private Color[] colorData;

        private Health health;
        private float speed;


        public Knight()
        {

            speed = 0.1f;

            health = new Health();
            detectionHitbox = new Rectangle(0, 0, 500, 500);
            knightRectangle = new Rectangle(0, 0, 101, 101);
            sourceRectangle = new Rectangle(0, 0, 0, 0);
            knightPosition = new Vector2();
            movementDirection = new Vector2();
            knightOrigin = new Vector2(0, 0);

            LoadTexture2D();

            colorData = new Color[knightTexture.Width * knightTexture.Height];
            knightTexture.GetData(colorData);
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
                knightPosition.X -= (speed * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                knightPosition.X += (speed * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                knightPosition.Y += (speed * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                knightPosition.Y -= (speed * gameTime.ElapsedGameTime.Milliseconds);
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

            GameInfo.spriteBatch.Draw(knightTexture, knightPosition, knightRectangle, Color.White);

            // base.Draw(gameTime);
        }

    }
}
