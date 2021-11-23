﻿using Microsoft.Xna.Framework;
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
        Rectangle myRectangle;
        Rectangle sourceRectangle;
        int frames;
        


        public Farmer()
        {
            maxHealth = 50;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            movementSpeed = 5;
            jumpHeight = 3;
            frames = 0;

            

            myRectangle = new Rectangle((int)myPosition.X, (int)myPosition.Y, myTexture.Width, myTexture.Height);
            sourceRectangle = new Rectangle(32 * frames, 0, 32, 48);
            string currentPath = 
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ "/Farmer.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {

                myTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }

            
        }


        #region Actions

        public override void MoveRight()
        {

            myPosition.X = myPosition.X + movementSpeed * (float)GameInfo.gameTime.ElapsedGameTime.TotalMilliseconds;

        }

        public override void MoveLeft()
        {

            myPosition.X = myPosition.X - movementSpeed * (float)GameInfo.gameTime.ElapsedGameTime.TotalMilliseconds;

        }

        public override void Jump(GameTime gameTime)
        {

            myPosition.Y = myPosition.Y + jumpHeight * (float)GameInfo.gameTime.ElapsedGameTime.TotalMilliseconds;

        }

        public override void Attack1()
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





        }

        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw(myTexture, myRectangle, sourceRectangle , Color.White);

        }



    }
}
