using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Player : Character
    {
        int maxHealth;
        int currentHEalth;
        int mana;
        int manaCheck;
        int manaTick;

        public Player()
        {
            mana = 100;
            manaCheck = mana;
            maxHealth = 150;
            currentHEalth = maxHealth;
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
