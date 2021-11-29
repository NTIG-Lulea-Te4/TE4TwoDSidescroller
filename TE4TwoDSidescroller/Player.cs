using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TE4TwoDSidescroller
{
    class Player : Character
    {
        static Texture2D rightWalk;
        static Texture2D leftWalk;

        private Rectangle playerSourceRectangle;
        private Vector2 playerPosition;
        private Vector2 playerVelocity;

        private Rectangle playerHitBox;

        private Vector2 playerScale;
        private float playerRotation;
        private Vector2 playerOrigin;

        private float moveSpeed;
        private float runSpeed;
        private float walkSpeed;

        private float playerJumpHeight;

        Floor floorTest;

        private Texture2D currentTexture;

        public Player()
        {
            characterInput = new PlayerInput(this);
            playerSourceRectangle = new Rectangle(0, 0, 65, 106); //Need to find picture.
            playerHitBox = new Rectangle(0, 0, 32, 48);

            playerVelocity = new Vector2(0, 0);
            movementVector = new Vector2(0, 0);

            moveSpeed = 2;
            walkSpeed = 2;
            runSpeed = 4;

            playerScale = new Vector2(1, 1);
            playerRotation = 0;
            playerOrigin = new Vector2(0, 0);

            playerPosition = new Vector2(0, 0);

            playerJumpHeight = 0.0f; 

            IsGrounded = false;

            LoadPlayerTexture2D();

            maxHealth = 150;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;

            floorTest = new Floor();
        }

        public Vector2 PlayerPosition
        {
            get
            {
                return playerPosition;
            }
            set
            {
                playerPosition = value;
            }
        }

        public void LoadPlayerTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/MainCharacters/" + "ShadowRunRight.png";
            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                rightWalk = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string path2 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/MainCharacters/" + "ShadowRunLeft.png";
            using (Stream textureStream = new FileStream(path2, FileMode.Open))
            {
                leftWalk = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }
        }



        public override void MoveUp()
        {
            movementVector.Y -= moveSpeed; //Modife later to implant accelartion and friction. (acceleration - friction * movementVector.Y)
        }

        public override void MoveDown()
        {
            movementVector.Y += moveSpeed;
        }

        public override void MoveLeft()
        {
            movementVector.X -= moveSpeed;
        }

        public override void MoveRight()
        {
            movementVector.X += moveSpeed;
        }

        public override void Run()
        {

            moveSpeed = runSpeed;
        }

        public override void DoNotRun()
        {

            moveSpeed = walkSpeed;
        }

        public override void Jump(GameTime gameTime)
        {

            if (IsGrounded && playerVelocity.Y == 0)
            {
                playerJumpHeight += (float)(0.6f * (gameTime.ElapsedGameTime.TotalMilliseconds));
            }
        }

        public override void DoubleJump()
        {

            //Use the flag for IsGrounded to nullify gravity and let another Jump runs
        }


        public override void Update(GameTime gameTime)
        {
            //moveSpeed = 1; //null the multiplier
            playerVelocity = new Vector2(0, 0);
            playerJumpHeight = 0;
            playerPosition += movementVector;


            base.Update(gameTime);

            characterInput.Update(gameTime);

            //if (!GameInfo.collisionManager.RectangleCollision(playerHitBox, floorTest.myRectangle) && !IsGrounded)
            //{
            //    increasingGravity += (float)(/*GameInfo.gameInformationSystem.gravity*/ 0f * gameTime.ElapsedGameTime.TotalMilliseconds);
            //}

            if (playerPosition.Y > 500)
            {
                IsGrounded = true;
            }
            else if (playerPosition.Y > 10 || playerPosition.Y < 0)
            {
                increasingGravity += (/*((float)GameInfo.gameInformationSystem.gravity / 2450f)*/ 0.004f * (float)gameTime.ElapsedGameTime.TotalMilliseconds);
            }

            //playerHitBox.X = (int)playerPosition.X; 
            //playerHitBox.Y = (int)playerPosition.Y;

            playerVelocity.Y += increasingGravity - playerJumpHeight;

            //SetPlayerAnimation();

            movementVector += playerVelocity;


            manaTick++;
            if (mana < manaCheck && manaTick == 15)
            {
                mana++;
                manaTick = 0;
            }

            //gör en bool som checkar ifall du kan checka enemy collision
            //så när du blir skadad slår du av den för 0.5 sek

            //ifall fienders vapen overlappar med kroppen så ta skada
            /* if (true)
             {
                 character.TakeDamage(currentHEalth, 10);
             }*/

        }

        //public void MovementUpdate(GameTime gameTime)
        //{

        //    movementVector.Normalize();
        //    if (playerVelocity != Vector2.Zero)
        //    {
        //        movementVector.Normalize();
        //    }

        //    characterInput.Update(gameTime);
        //    playerPosition += movementVector;

        //    if (!IsGrounded)
        //    {
        //        increasingGravity += (float)(0.5f * gameTime.ElapsedGameTime.TotalMilliseconds);
        //    }

        //    if (!GameInfo.collisionManager.RectangleCollision(playerHitBox, floorTest.myRectangle) && !IsGrounded)
        //    {
        //        increasingGravity += (float)(0.5f * gameTime.ElapsedGameTime.TotalMilliseconds);
        //    }
        //    playerVelocity.Y += increasingGravity;
        //    movementVector += playerVelocity;


        //    playerHitBox.X = (int)playerPosition.X;
        //    playerHitBox.Y = (int)playerPosition.Y;


        //}

        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(rightWalk, playerPosition, playerSourceRectangle, Color.White, playerRotation, playerOrigin, playerScale, SpriteEffects.None, 0.0f);
        }
    }
}
