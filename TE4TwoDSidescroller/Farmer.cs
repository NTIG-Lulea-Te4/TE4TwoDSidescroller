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
        
        int currentHealth;
        int manaCheck;
        int maxHealth;
        int manaTick;
        int mana;

        Texture2D myTexture;
        Vector2 myPosition;
        Rectangle myRectangle;

        public Farmer()
        {
            maxHealth = 50;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
        }

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
        
            GameInfo.spriteBatch.Draw();

        }



    }
}
