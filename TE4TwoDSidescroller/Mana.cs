using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Mana 
    {
        int manaRegenAmount;
        public bool UseMana(int manaPool, int amountOfManaUsed)
        {
            if (manaPool < amountOfManaUsed)
            {
                return false;
            }

            manaPool = manaPool - amountOfManaUsed;
           
            return true;


        }

            //detta behövs inte men ifall man senare vill ha ett item som ökar ens manaregen så kan detta 
            //var ett bra sätt att göra det men det kan också bero på ifall det skulle vara ett permanent eller temporärt item
            /*if (manaPool < 100 && manaRegenAmount != 1)
            {
                manaRegenAmount = 1;
            }
            else if (manaPool == 100)
            {
                manaRegenAmount = 0;
            }*/


    }
}
