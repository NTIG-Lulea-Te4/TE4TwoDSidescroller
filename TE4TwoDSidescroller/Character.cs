using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Character : Entity
    {
        protected bool ifHit;
       
        protected int speed;
        protected int manaRegenAmount;
        public bool sprint;
        public int staminga;
        
        private int tickTimer;
        
        Character()
        {
            staminga = 100;
            tickTimer = 0;
            sprint = false;
    
        }

        //Skicka in två int 
        protected int Healing(int maxHealth, int currentHealth, int healingAmount)
        {

            currentHealth = currentHealth + healingAmount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            return currentHealth;
        }

        protected int TakeDamage(int currentHEalth, int amountOfDamage)
        {
            currentHEalth = currentHEalth - amountOfDamage;

            if (currentHEalth <= 0)
            {
                //destroy entity
            }


            return currentHEalth;
        }

       

        protected bool UseMana(int manaPool, int amountOfManaUsed)
        {
            if (manaPool < amountOfManaUsed)
            {
                return false;
            }

            manaPool = manaPool - amountOfManaUsed;

            if (manaPool < 100 && manaRegenAmount != 1)
            {
                manaRegenAmount = 1;
            } else if (manaPool == 100)
            {
                manaRegenAmount = 0;
            }

            return true;

            //ska vara i karaktärernas som kan använda manas update
            /*if (tickTimer == 2)
            {

                mana += manaRegenAmount;
                tickTimer = 0;
            
            }
            tickTimer++;*/

        }


        protected void Invincibility()
        {


           //stopp checking collision for half a second
            
        }

        protected void Speed()
        {
            speed = 1;
        }

        public override void Update(GameTime gameTime)
        {
            //gör så att när man håller ner shift så är sprint true

            if (sprint == false)
            {

                if (tickTimer == 2 && staminga != 100)
                {

                    staminga++;
                    tickTimer = 0;
            
                }
                tickTimer++;

            } else if (sprint)
            {

                if (tickTimer == 2 && staminga != 0)
                {

                    staminga--;
                    tickTimer = 0;

                }
                tickTimer++;

            }
        }
    }
}
