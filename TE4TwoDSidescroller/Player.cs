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

        private Rectangle playerRectangle;

        Floor floorTest;



        private int currentFrame;
        private int frameCounter;

        private Texture2D currentTexture;

        public Player()
        {
            characterInput = new PlayerInput(this);

            playerRectangle = new Rectangle(10, 10, 200, 200);

            floorTest = new Floor();

            maxHealth = 150;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;

            CharacterVelocity = 2;

            RunSpeed = 4;

            WalkSpeed = 2;



            CharacterJumpHeight = 3;


            LoadPlayerTexture2D();
        }



        public override void MoveUp()
        {
            playerRectangle.Y -= CharacterVelocity;
        }

        public override void MoveDown()
        {
            playerRectangle.Y += CharacterVelocity;
        }

        public override void MoveLeft()
        {
            playerRectangle.X -= CharacterVelocity;
        }

        public override void MoveRight()
        {
            playerRectangle.X += CharacterVelocity;
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

            IsRunning = false;
            while (IsRunning == false)
            {
                CharacterVelocity = RunSpeed;
                if(CharacterVelocity == RunSpeed)
                {
                    IsRunning = true;
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
            IsRunning = true;
            while (IsRunning == true)
            {
                CharacterVelocity = WalkSpeed;
                if (CharacterVelocity == WalkSpeed)
                {
                    IsRunning = false;
                }
            }
        }

        public override void Jump()
        {
            playerRectangle.Y -= CharacterJumpHeight;
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

            GameInfo.spriteBatch.Draw(rightWalk, playerRectangle, Color.White);

            //floorTest.Draw(gameTime);

        }
    }
}
