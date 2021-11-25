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

        PlayerTest playerTest;

        private Texture2D knightTexture;
        private Rectangle detectionHitbox;
        private Rectangle sourceRectangle;
        private Vector2 movementDirection;
        private Vector2 distance;
        private Vector2 knightPosition;
        private Vector2 knightOrigin;
        private Color[] colorData;

        private Health health;



        bool hasCollided;

        public Knight()
        {

            isActive = true;
            hasCollider = true;

            hasCollided = false;

            movementSpeed = 0.1f;
            maxHealth = 150;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            health = new Health();

            playerTest = new PlayerTest();

            detectionHitbox = new Rectangle(0, 0, 500, 500);
            sourceRectangle = new Rectangle(0, 0, 0, 0);
            knightPosition = new Vector2();
            movementDirection = new Vector2();
            distance = new Vector2(100, 100);
            knightOrigin = new Vector2(0, 0);

            collisionBox = new Rectangle(0, 0, 101, 101);


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

        public override void HasCollidedWith(Entity collider)
        {
            if (collider.isPlayer)
            {
                hasCollided = true;
            }
            else
            {
                hasCollided = false;
            }
        }



        public override void Update(GameTime gameTime)
        {
            #region Controls for testing
            //if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //{
            //    knightPosition.X -= (movementSpeed * gameTime.ElapsedGameTime.Milliseconds);
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //{
            //    knightPosition.X += (movementSpeed * gameTime.ElapsedGameTime.Milliseconds);
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //{
            //    knightPosition.Y += (movementSpeed * gameTime.ElapsedGameTime.Milliseconds);
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    knightPosition.Y -= (movementSpeed * gameTime.ElapsedGameTime.Milliseconds);
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
            //{
            //    knightPosition.Y = 0;
            //    knightPosition.X = 0;

            //}
            #endregion

            movementDirection = PlayerTest.playerPosition - knightPosition;
            movementDirection.Normalize();

            if (movementDirection.Length() < distance.Length())
            {
                knightPosition += movementDirection * movementSpeed * gameTime.ElapsedGameTime.Milliseconds;

            }


            detectionHitbox.X = (int)knightPosition.X;
            detectionHitbox.Y = (int)knightPosition.Y;
            collisionBox.X = (int)knightPosition.X;
            collisionBox.Y = (int)knightPosition.Y;


        }

        public override void Draw(GameTime gameTime)
        {
            if (hasCollided)
            {
                GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.Pink);
            }
            else
            {
                GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);
            }

            GameInfo.spriteBatch.Draw(knightTexture, knightPosition, collisionBox, Color.White);

            // base.Draw(gameTime);
        }

    }
}
