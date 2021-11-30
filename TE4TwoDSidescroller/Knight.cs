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

        GameInformationSystem gameInfoSystem;
        PlayerTest playerTest;

        private Texture2D knightTexture;
        private Rectangle detectionHitbox;
        private Rectangle sourceRectangle;
        static public Vector2 movementDirection;
        private Vector2 knightPosition;
        private Vector2 knightOrigin;
        private Vector2 knightVelocity;
        private Vector2 knightScale;
        private float knightRotation;
        private float knightJumpHeight;

        private Color[] colorData;


        private Health health;

        float currentGravity;


        bool hasCollided;

        Texture2D[] Sprites;
        int frameWidth;
        int frameHeight;
        int currentFrame;


        public Knight()
        {

            characterInput = new KnightBehaviour(this);

            frameWidth = 64;
            currentFrame = frameWidth;
            frameHeight = 96;


            IsGrounded = false;
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
            sourceRectangle = new Rectangle(0, 0, 64, 96);
            knightPosition = new Vector2();
            movementDirection = new Vector2();
            knightVelocity = new Vector2(0, 0);
            
            knightOrigin = new Vector2(0, 0);
            knightScale = new Vector2(1, 1);
            movementVector = new Vector2();
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
             + "/Content/Pngs/Enemies/" + "KnightWalkAnim.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                knightTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }

        public void PixelCollision()
        {

            // GameInfo.collisionManager.PixelPerfectCollision();


        }

        public override void HasCollidedWith(Entity collider)
        {

            if (collider.isFloor)
            {
                IsGrounded = true;
            }
            else
            {
                IsGrounded = false;
            }

        }

        #region Movement

        public override void MoveRight()
        {
            
            movementDirection.Normalize();
            knightPosition.X += movementDirection.X * movementSpeed;

        }

        public override void MoveLeft()
        {



        }



        #endregion

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

            movementDirection.X = PlayerTest.playerPosition.X - knightPosition.X;

            knightVelocity = new Vector2(0, 0);
            knightJumpHeight = 0;


            if (!IsGrounded)
            {

                increasingGravity += 0.004f * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            }

            knightVelocity.Y += increasingGravity /*- knightJumpHeight*/;

            knightPosition += knightVelocity;

            detectionHitbox.X = (int)knightPosition.X;
            detectionHitbox.Y = (int)knightPosition.Y;
            collisionBox.X = (int)knightPosition.X;
            collisionBox.Y = (int)knightPosition.Y;

            #region Animation Stuff

            //if (frameTimer >= frameThreshHold)
            //{

            //    frameCounter++;
            //    currentFrame = frameCounter * frameWidth;

            //    sourceRectangle.Width = currentFrame;

            //    frameTimer = 0;

            //    if (frameCounter == 4)
            //    {
            //        frameCounter = 1;
            //    }

            //}

            //frameTimer += gameTime.ElapsedGameTime.Milliseconds;

            //if (movementDirection.X > 0.1f)
            //{

            //}
            //else if (movementDirection.X < 0.1f)
            //{
            //    knightScale.X *= -1;
            //}

            #endregion

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
