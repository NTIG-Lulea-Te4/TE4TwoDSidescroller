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

        private Rectangle detectionHitBox;

        private Vector2 playerScale;
        private float playerRotation;
        private Vector2 playerOrigin;

        private float moveSpeed;
        private float runSpeed;
        private float walkSpeed;

        private Vector2 playerJumpHeight;

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
          
            playerVelocity = new Vector2(0, 0);
            movementVector = new Vector2(0, 0);

            playerScale = new Vector2(1, 1);
            playerRotation = 0;
            playerOrigin = new Vector2(0, 0);

            playerPosition = new Vector2(0, 0);

            playerJumpHeight = new Vector2(); 

            moveSpeed = 2;
            walkSpeed = 2;
            runSpeed = 4;

            IsGrounded = false;
            hasCollider = true;
            isActive = true;
            isPlayer = true;

            detectionHitBox = new Rectangle(0, 0, 500, 500);
            collisionBox = new Rectangle(0, 0, playerSourceRectangle.Width, playerSourceRectangle.Height);

            LoadPlayerTexture2D();

            maxHealth = 150;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;

            floorTest = new Floor();

            //visionManager 

            entityAnimation = new Dictionary<string, EntityAnimation>();
            EntityAnimation RunRight = new EntityAnimation(rightWalk, 0, 4, playerOrigin, PlayerPosition, playerSourceRectangle, 
                playerScale, 0, SpriteEffects.None, 0);

            entityAnimation.Add("RunRight", RunRight);

            animation = new Animation(rightWalk, 4);
            animation.isLooping = true;
            animation.FramePerSecond = 5;
            animation.position = PlayerPosition;

            //previousAnimationIndex = 3;

            //currentAnimationIndex = 0;

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

        #region Input

        public override void MoveUp()
        {
            movementVector.Y -= moveSpeed; 
            //Modife later to implant accelartion and friction. (acceleration - friction * movementVector.Y)
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
                playerJumpHeight.Y += (float)(2.4f * (gameTime.ElapsedGameTime.TotalMilliseconds) );
            }
        }

        public override void DoubleJump()
        {
            //Use the flag for IsGrounded to nullify gravity and let another Jump runs
        }

        #endregion

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

        public override void Update(GameTime gameTime)
        {            
            playerVelocity = new Vector2(0, 0);
            playerJumpHeight = new Vector2(0, 0);

            PlayerPosition += movementVector;
            animation.Update(gameTime);

            base.Update(gameTime);

            if (!IsGrounded)
            {
                increasingGravity += (float)(GameInfo.gameInformationSystem.gravity * (float)gameTime.ElapsedGameTime.TotalMilliseconds);
            }

            detectionHitBox.X = (int)PlayerPosition.X;
            detectionHitBox.Y = (int)PlayerPosition.Y;
            collisionBox.X = (int)PlayerPosition.X;
            collisionBox.Y = (int)PlayerPosition.Y;

            playerVelocity.Y += increasingGravity - playerJumpHeight.Y;

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
            GameInfo.spriteBatch.Draw(rightWalk, PlayerPosition, playerSourceRectangle/*[currentAnimationIndex]*/, Color.White, playerRotation, playerOrigin, playerScale, SpriteEffects.None, 0.0f);
            animation.Draw(gameTime);
        }
    }
}
