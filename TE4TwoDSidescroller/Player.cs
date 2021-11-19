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
        private Vector2 playerVelocity;

        private float jumpTimer;

        private Vector2 playerScale;
        private float playerRotation;
        private Vector2 playerOrigin;

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

            playerVelocity = new Vector2(2.5f, 2.5f);

            jumpTimer = 0.05f;

            playerScale = new Vector2(3, 3);
            playerRotation = 0;
            playerOrigin = new Vector2(0, 0);

            playerPosition.X = 100;
            playerPosition.Y = 100;

            WalkSpeed = 2.5f;
            RunSpeed = 5.5f;

            CharacterJumpHeight = 0.45f; //With each -0.1 you lose 2 pixel heights
            HasJumped = false;

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
            playerPosition.Y -= playerVelocity.Y;
        }

        public override void MoveDown()
        {
            playerPosition.Y += playerVelocity.Y;
        }

        public override void MoveLeft()
        {
            playerPosition.X -= playerVelocity.X;
        }

        public override void MoveRight()
        {
            playerPosition.X += playerVelocity.X;
        }

        public override void Run()
        {
            //for (int Timer = 0; Timer < 180; Timer++)
            //{
            //    if (Timer == 0)
            //    {
            //        CharacterVelocity = RunSpeed;
            //    }
            //    else if (Timer == 179)
            //    {
            //        CharacterVelocity = WalkSpeed;
            //    }
            //}

            HasRunned = false;
            while (!HasRunned )
            {
                playerVelocity.X = RunSpeed;
                if(playerVelocity.X == RunSpeed)
                {
                    HasRunned = true;
                }
            }

            //if (IsRunning == true)
            //{
            //    CharacterVelocity = RunSpeed;
            //}
            //else
            //{
            //    IsRunning = false;
            //    CharacterVelocity = WalkSpeed;
            //}
        }

        public override void DontRun()
        {
            HasRunned = true;
            while (HasRunned == true)
            {
                playerVelocity.X = WalkSpeed;
                if (playerVelocity.X == WalkSpeed)
                {
                    HasRunned = false;
                }
            }
        }

        public override void Jump(GameTime gameTime)
        {
            //float beforeJumpPlayerPosition = playerPosition.Y;
            playerPosition.Y -= (float)(CharacterJumpHeight * gameTime.ElapsedGameTime.TotalMilliseconds);


            //HasJumped = true;

            //    float afterJumpPlayerPosition = playerPosition.Y;
            //    playerPosition.Y += (float)(CharacterJumpHeight * gameTime.ElapsedGameTime.TotalMilliseconds);

            //    if (afterJumpPlayerPosition >= beforeJumpPlayerPosition)
            //    {
            //        playerPosition.Y = beforeJumpPlayerPosition;
            //        HasJumped = false;
            //    }


            //playerVelocity.Y = -5f;
            //HasJumped = true;

            //if(HasJumped == true)
            //{
            //    float i = 1;
            //    playerVelocity.Y += 0.15f * i;
            //}

            //if (playerPosition.Y + Floor.Height >= 20) //Ground check?!
            //{
            //    HasJumped = false;
            //}

            //if(HasJumped == false)
            //{
            //    playerVelocity.Y = 0f;
            //}
        }

        public override void DontJump()
        {
            //playerPosition.Y -= CharacterJumpHeight;

            //HasJumped = true;
            //while (HasJumped == true)
            //{
            //    float i = 1;
            //    playerPosition.Y += 10f * i;

            //    if (playerPosition.Y >= 300)
            //    {
            //        HasJumped = false;
            //        playerPosition.Y = 0;
            //    }
            //}
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





            characterInput.Update(gameTime);

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

            //GameInfo.spriteBatch.Draw(rightWalk, playerSourceRectangle, Color.White);

            GameInfo.spriteBatch.Draw(rightWalk, playerPosition, playerSourceRectangle, Color.White, playerRotation, playerOrigin, playerScale, SpriteEffects.None, 0.0f);

            //floorTest.Draw(gameTime);

        }
    }
}
