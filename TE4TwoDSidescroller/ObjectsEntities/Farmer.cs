using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace TE4TwoDSidescroller
{
    class Farmer : Character
    {



        Texture2D myTexture;
        Vector2 myPosition;
        Rectangle sourceRectangle;
        int frames;
        


        public Farmer(int myPosition1, int myPosition2)
        {
            characterInput = new FarmerInput(this);
            maxHealth = 50;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            movementSpeed = 2;
            jumpHeight = 3;
            frames = 0;

            hasCollider = true;

            myPosition = new Vector2(myPosition1, myPosition2);

            string currentPath = 
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ "/Content/Pngs/Enemies" + "/FarmerIdlePic.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {

                myTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }

            sourceRectangle = new Rectangle(0, 0, myTexture.Width, myTexture.Height);
            myPosition = new Vector2(myPosition1, myPosition2);
            
            collisionBox = new Rectangle((int)myPosition.X, (int)myPosition.Y, myTexture.Width, myTexture.Height);
        }


        #region Actions

        public override void MoveRight()
        {

            myPosition.X += movementSpeed;

        }

        public override void MoveLeft()
        {

            myPosition.X -= movementSpeed;

        }

        //public override void Jump()
        //{

        //    myPosition.Y = myPosition.Y + jumpHeight * (float)GameInfo.gameTime.ElapsedGameTime.TotalMilliseconds;

        //}

        public override void Attack1(GameTime gameTime)
        {



        }



        #endregion


        #region Texture/Animation

        void GetMyFrame(int frameNumber)
        {

            if (frameNumber == 0)
            {
                frames = frameNumber;

            }

            if (frameNumber == 1)
            {
                frames = frameNumber;

            }
            
            if (frameNumber == 2)
            {
                frames = frameNumber;

            }
            
            if (frameNumber == 3)
            {
                frames = frameNumber;

            }


        }


        #endregion


        public override void Update(GameTime gameTime)
        {
            manaTick++;
            if (mana < manaCheck && manaTick == 15)
            {
                mana++;
                manaTick = 0;
            }

            myPosition += movementVector;

            base.Update(gameTime);




        }

        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw(myTexture, myPosition, sourceRectangle , Color.White);

        }



    }
}
