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
        public  Texture2D currentTexture;
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

        //int currentFrame;
        //int frameHeight;
        //int frameWidth;

        float timer;
        float frameSpeed; //An int that is the threhold for timer.

        Rectangle[] sourceRectangles;

        int previousAnimationIndex;
        int currentAnimationIndex;

        Floor floorTest;

        public Player()
        {
            characterInput = new PlayerInput(this);
            playerSourceRectangle = new Rectangle(0, 0, 64, 96); // 256 * 96 - 64
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


            AnimateRight();


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

        public Texture2D CurrentTexture
        {
            get
            {
                return currentTexture;
            }
            set
            {
                currentTexture = value;
            }
        }

        public void AnimateRight()
        {
            animation = new Animation(currentTexture, 4);
            animation.isLooping = true;
            animation.FramePerSecond = 5;
            animation.position = playerPosition;
        }

        //public int FrameHeight { get; set; }

        //public int FrameWidth { get; set; }

        public void LoadPlayerTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/MainCharacters/" + "ShadowRunRight.png";
            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                currentTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string path2 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/MainCharacters/" + "ShadowRunLeft.png";
            using (Stream textureStream = new FileStream(path2, FileMode.Open))
            {
                leftWalk = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }
        }

        //public void Animator(GameTime gameTime)
        //{

        //    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        //    if (timer > frameSpeed)
        //    {
        //        if (currentAnimationIndex == 0)
        //        {
        //            if (previousAnimationIndex == 3)
        //            {
        //                currentAnimationIndex = 2;
        //            }
        //            else if (previousAnimationIndex == 2)
        //            {
        //                currentAnimationIndex = 1;
        //            }
        //            else if (previousAnimationIndex == 1)
        //            {
        //                currentAnimationIndex = 0;
        //            }
        //            previousAnimationIndex = currentAnimationIndex;
        //        }
        //        else
        //        {
        //            currentAnimationIndex = 0;
        //        }
        //        timer = 0;
        //    }
        //    else
        //    {
        //        timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        //    }


        //}

        //public void AnimateRight(GameTime gameTime)
        //{
        //    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
        //    if (timer > frameSpeed)
        //    {
        //        currentFrame++;
        //        timer = 0;
        //        if (currentFrame > 3)
        //        {
        //            currentFrame = 0;
        //        }
        //    }
        //}

        #region Input

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

        #endregion

        public override void Update(GameTime gameTime)
        {
            
            playerVelocity = new Vector2(0, 0);
            playerJumpHeight = 0;

            //playerSourceRectangle = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
            //playerOrigin = new Vector2(playerSourceRectangle.Width / 2, playerSourceRectangle.Height / 2);

            playerPosition += movementVector;
            animation.Update(gameTime);

            base.Update(gameTime);


            //if (!GameInfo.collisionManager.RectangleCollision(playerHitBox, floorTest.myRectangle) && !IsGrounded)
            //{
            //    increasingGravity += (float)(GameInfo.gameInformationSystem.gravity * (float)gameTime.ElapsedGameTime.TotalMilliseconds);
            //}

            if (playerPosition.Y > 620)
            {
                IsGrounded = true;
            }
            else if (playerPosition.Y > 10 || playerPosition.Y < 0)
            {
                increasingGravity += ((float)GameInfo.gameInformationSystem.gravity * (float)gameTime.ElapsedGameTime.TotalMilliseconds);
            }

            //playerHitBox.X = (int)playerPosition.X; 
            //playerHitBox.Y = (int)playerPosition.Y;

            playerVelocity.Y += increasingGravity - playerJumpHeight;


            movementVector += playerVelocity;

            #region Harry's Code
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

            #endregion

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
            GameInfo.spriteBatch.Draw(currentTexture, playerPosition, playerSourceRectangle/*[currentAnimationIndex]*/, Color.White, playerRotation, playerOrigin, playerScale, SpriteEffects.None, 0.0f);
            animation.Draw(gameTime);
        }
    }
}
