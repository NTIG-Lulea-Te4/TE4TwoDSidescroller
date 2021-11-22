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
        public Vector2 playerVelocity;



        private Vector2 playerScale;
        private float playerRotation;
        private Vector2 playerOrigin;

        private float acceleration;

        Floor floorTest;

        private int currentHEalth;
        private int manaCheck;
        private int maxHealth;
        private int manaTick;
        private int mana;

        private int currentFrame;
        private int frameCounter;

        private Texture2D currentTexture;

        public Player()
        {
            characterInput = new PlayerInput(this);
            playerSourceRectangle = new Rectangle(0, 0, 32, 48); //Need to find how to scale the picture.
            playerVelocity = new Vector2(0, 0);

            moveSpeed = 2;
            walkSpeed = 2;
            runSpeed = 4;

            gravity = 0.4f;


            playerScale = new Vector2(3, 3);
            playerRotation = 0;
            playerOrigin = new Vector2(0, 0);

            playerPosition.X = 100;
            playerPosition.Y = 100;


            characterJumpHeight = 0.2f; //With each -0.1 you lose 2 pixel heights

            isGrounded = true;

            LoadPlayerTexture2D();

            maxHealth = 150;
            currentHEalth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;

            floorTest = new Floor();
        }


        public override void MoveUp()
        {
            playerVelocity.Y -= moveSpeed;
        }

        public override void MoveDown()
        {
            playerVelocity.Y += moveSpeed;
        }

        public override void MoveLeft()
        {
            playerVelocity.X -= moveSpeed;
        }

        public override void MoveRight()
        {
            playerVelocity.X += moveSpeed;
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
            if (isGrounded && playerVelocity.Y == 0)
            {
                playerVelocity.Y -= (float)(characterJumpHeight * gameTime.ElapsedGameTime.TotalMilliseconds);

            }
        }

        public override void DoubleJump()
        {

            //Use the flag for IsGrounded to nullify gravity and let another Jump runs
        }

        public void LoadPlayerTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/" + "ShadowRunRight.png";
            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                rightWalk = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }

        public override void Update(GameTime gameTime)
        {
            //Make varible null or change them here before up
            //gravity, position, jump fall and such
            //movement.Normelize();


            characterInput.Update(gameTime);

            //if (playerVelocity != Vector2.Zero)
            //{
            //    playerVelocity.Normalize();
            //}

            /// <summary>
            ///  Check if the Player is grounded, if it is the velocity in Y-axel will be zero. If not the Player will fall down until the flag is true.
            /// </summary>

            if (!isGrounded)
            {
                playerVelocity.Y += (float)(gravity * gameTime.ElapsedGameTime.TotalMilliseconds);
            }


            playerPosition += playerVelocity;

            playerVelocity = Vector2.Zero;


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

        }


        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw(rightWalk, playerPosition, playerSourceRectangle, Color.White, playerRotation, playerOrigin, playerScale, SpriteEffects.None, 0.0f);

        }
    }
}
