using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    class Character : Entity
    {
        CharacterInput characterInput;

        private Vector2 characterPosition;

        private float walkSpeed;
        private float runSpeed;

        private float characterVelocity;

        private float characterJumpHeight;

        private bool ifHit;
        private int health;
        private int speed;

        protected int manaRegenAmount;
        public bool sprint;
        public int staminga;

        private int tickTimer;
        public Character()
        {
            characterInput = new CharacterInput(this);

            staminga = 100;
            tickTimer = 0;
            sprint = false;
        }

        #region Movement
        public virtual void GoesUp()
        {
            
        }

        public virtual void GoesDown()
        {
            
        }

        public virtual void GoesLeft()
        {
            
        }

        public virtual void GoesRight()
        {
            
        }

        public virtual void Run()
        {
            
        }

        public virtual void Jump()
        {

        }

        public virtual void DoubleJump()
        {

        }

        public virtual void Crouch()
        {

        }

        public virtual void Dash()
        {

        }
        #endregion

        #region Attacks

        public virtual void LightAttack()
        {

        }

        public virtual void HeavyAttack()
        {

        }

        public virtual void SpecialAttack()
        {

        }
        #endregion

        #region Conditions

        public virtual void Parry()
        {

        }

        public virtual void Block()
        {

        }

        public virtual void Dodge()
        {

        }

        #endregion
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
            }
            else if (manaPool == 100)
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

            }
            else if (sprint)
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
