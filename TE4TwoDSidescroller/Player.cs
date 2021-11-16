using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TE4TwoDSidescroller
{
    class Player : Character
    {
        public Texture2D rightWalk;
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;
        Floor floorTest;
        int currentHEalth;
        int manaCheck;
        int maxHealth;
        int manaTick;
        int mana;
        

        public Player()
        {
            GameInfo.spriteBatch = new SpriteBatch(GameInfo.graphicsDevice.GraphicsDevice);
            destinationRectangle = new Rectangle(100, 100, 32, 48);
            floorTest = new Floor();
            maxHealth = 150;
            currentHEalth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            

            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/" + "ShadowRunRight.png";
            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                rightWalk = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }
        }


        public void Initialize()
        {



            // TODO: Add your initialization logic here


            floorTest.Initialize();
            
        }

        public override void Update(GameTime gameTime)
        {
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

            sourceRectangle = new Rectangle(0, 0, 32, 48);
        }


        public override void Draw(GameTime gameTime)
        {
            
            GameInfo.spriteBatch.Draw(rightWalk, destinationRectangle, sourceRectangle, Color.White);
            //GameInfo.entityManager.Draw(gameTime);
            //floorTest.Draw(gameTime);
            

        }
    }
}
