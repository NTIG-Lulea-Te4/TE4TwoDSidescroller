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


        Health health;
        Texture2D farmerIdle;
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
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            + "/Content/Pngs/Enemies" + "/FarmerIdlePic.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {

                farmerIdle = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }

            sourceRectangle = new Rectangle(0, 0, farmerIdle.Width, farmerIdle.Height);
            myPosition = new Vector2(myPosition1, myPosition2);
            
            collisionBox = new Rectangle((int)myPosition.X, (int)myPosition.Y, farmerIdle.Width, farmerIdle.Height);
            health = new Health();
        }


        public override void HasCollidedWith(Entity collider)
        {

            if (collider.tag == Tags.PlayerAttack.ToString())
            {
                health.TakeDamage(currentHealth, Player.playerDamage, this);

            }


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

        public override void Attack1( )
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

            GameInfo.spriteBatch.Draw(farmerIdle, myPosition, sourceRectangle , Color.White);

        }



    }
}
