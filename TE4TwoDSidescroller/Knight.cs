﻿using Microsoft.Xna.Framework;
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

        GameInformationSystem gameInfoSystem;
        PlayerTest playerTest;

        private Texture2D knightTexture;
        private Rectangle detectionHitbox;
        private Rectangle sourceRectangle;
        private Vector2 movementDirection;
        private Vector2 distance;
        private Vector2 knightPosition;
        private Vector2 knightOrigin;
        private Vector2 knightVelocity;
        private Vector2 knightScale;
        private float knightRotation;
        private Color[] colorData;

        private Health health;

        float currentGravity;

        bool isGrounded;
        bool hasCollided;

        public Knight()
        {

            isGrounded = false;
            isActive = true;
            hasCollider = true;
            hasCollided = false;

            movementSpeed = 2f;
            maxHealth = 150;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            health = new Health();

            playerTest = new PlayerTest();

            detectionHitbox = new Rectangle(0, 0, 500, 500);
            sourceRectangle = new Rectangle(0, 0, 65, 106);
            knightPosition = new Vector2();
            movementDirection = new Vector2();
            knightVelocity = new Vector2(0, 0);
            distance = new Vector2(300, 300);
            knightOrigin = new Vector2(0, 0);
            knightScale = new Vector2(1, 1);
            knightRotation = 0;

            collisionBox = new Rectangle(0, 0, sourceRectangle.Width, sourceRectangle.Height);
            gameInfoSystem = new GameInformationSystem();

            LoadTexture2D();

            colorData = new Color[knightTexture.Width * knightTexture.Height];
            knightTexture.GetData(colorData);
        }

        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/Enemies/" + "KnightIdlePic.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                knightTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }

        public override void HasCollidedWith(Entity collider)
        {
            if (collider.isPlayer || collider.isFloor /*collider == playerTest*/)
            {
                hasCollided = true;
            }
            else
            {
                hasCollided = false;
            }

            if (collider.isFloor)
            {
                isGrounded = true;
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

            if (movementDirection.Length() < distance.Length())
            {
                movementDirection.Normalize();
                knightPosition += movementDirection * movementSpeed/* * gameTime.ElapsedGameTime.Milliseconds*/;

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

            GameInfo.spriteBatch.Draw(knightTexture, knightPosition, sourceRectangle, Color.White, knightRotation, knightOrigin, knightScale, SpriteEffects.None, 0.0f);

            // base.Draw(gameTime);
        }

    }
}
