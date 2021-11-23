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

        private Rectangle playerSourceRectangle;
        private Vector2 playerPosition;
        private Vector2 movementVelocity;

        private Rectangle playerHitBox;

        private Vector2 playerScale;
        private float playerRotation;
        private Vector2 playerOrigin;

        Floor floorTest;



        private int currentFrame;
        private int frameCounter;

        private Texture2D currentTexture;

        /// <summary>
        /// constructor
        /// </summary>
        public Player()
        {
            characterInput = new PlayerInput(this);
            playerSourceRectangle = new Rectangle(0, 0, 32, 48); //Need to find how to scale the picture.
            playerHitBox = new Rectangle(0, 0, 32, 48);

            movementVelocity = new Vector2(0, 0);

            moveSpeed = 2;
            walkSpeed = 2;
            runSpeed = 4;

            playerScale = new Vector2(3, 3);
            playerRotation = 0;
            playerOrigin = new Vector2(0, 0);

            playerPosition.X = 100;
            playerPosition.Y = 100;


            characterJumpHeight = 8.5f; //With each -0.1 you lose 2 pixel heights

            IsGrounded = false;
            
            LoadPlayerTexture2D();

            maxHealth = 150;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;

            floorTest = new Floor();
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
            
        }

        public override void MoveUp()
        {
            movementVector.Y -= moveSpeed;
            
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
            //Is on the ground and the velocity.Y is zero
            if (GameInfo.collisionManager.RectangleCollision(playerHitBox, floorTest.myRectangle) && movementVelocity.Y == 0)
            {
                movementVelocity.Y -= (float)(characterJumpHeight * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
        }

        public override void DoubleJump()
        {

            //Use the flag for IsGrounded to nullify gravity and let another Jump runs
        }


        public override void Update(GameTime gameTime)
        {

            //movementVector.Normelize();
            //if (playerVelocity != Vector2.Zero)
            //{
            //    movementVector.Normalize();
            //}

            characterInput.Update(gameTime);


            if (!GameInfo.collisionManager.RectangleCollision(playerHitBox, floorTest.myRectangle) && !IsGrounded)
            {
               increasingGravity += (float)(GameInfo.gameInformationSystem.gravity * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
       
            

            playerPosition += movementVector;

            playerHitBox.X = (int)playerPosition.X;
            playerHitBox.Y = (int)playerPosition.Y;


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

            //sourceRectangle = new Rectangle(0, 0, 32, 48);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(rightWalk, playerPosition, playerSourceRectangle, Color.White, playerRotation, playerOrigin, playerScale, SpriteEffects.None, 0.0f);
        }
    }
}
