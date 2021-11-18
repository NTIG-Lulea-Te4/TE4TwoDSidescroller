using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Farmer : Character
    {
        
        int currentHealth;
        int manaCheck;
        int maxHealth;
        int manaTick;
        int mana;

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
    }
}
