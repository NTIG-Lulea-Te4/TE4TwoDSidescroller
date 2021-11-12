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

            characterVelocity = 1.5f;
            runSpeed = 3f;

            characterPosition.Y = 50;
            characterPosition.X = 50;

            characterJumpHeight = 3;

            staminga = 100;
            tickTimer = 0;
            sprint = false;
        }

        #region Movement
        public virtual void GoesUp()
        {
            characterPosition.Y -= characterVelocity;
        }

        public virtual void GoesDown()
        {
            characterPosition.Y += characterVelocity;
        }

        public virtual void GoesLeft()
        {
            characterPosition.X -= characterVelocity;
        }

        public virtual void GoesRight()
        {
            characterPosition.X += characterVelocity;
        }

        public virtual void Run()
        {
            characterVelocity = runSpeed;
        }

        public virtual void Jump()
        {
            characterPosition.Y += characterJumpHeight;
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

        #region Combat

        public virtual void LightAttack()
        {

        }

        public virtual void HeavyAttack()
        {

        }

        public virtual void SpecialAttack()
        {

        }

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

        #region Conditions

        public virtual void SwitchWeapon()
        {

        }

        public virtual void Interact()
        {

        }

        public virtual void OpenInGameMenu()
        {

        }

        public virtual void OpenInventory()
        {

        }

        public virtual void ConsumeHealthPotion()
        {

        }

        public virtual void ConsumeManaPotion()
        {

        }

        public virtual void ExitToMainMenu()
        {

        }

        public virtual void ExitGame()
        {

        }

        #endregion
        public int Healing(int maxHealth, int currentHealth, int healingAmount)
        {

            currentHealth = currentHealth + healingAmount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            return currentHealth;
        }

        public int TakeDamage(int currentHEalth, int amountOfDamage)
        {
            currentHEalth = currentHEalth - amountOfDamage;

            if (currentHEalth <= 0)
            {
                //destroy entity
            }


            return currentHEalth;
        }



        public bool UseMana(int manaPool, int amountOfManaUsed)
        {
            if (manaPool < amountOfManaUsed)
            {
                return false;
            }

            manaPool = manaPool - amountOfManaUsed;
            
            //detta behövs inte men ifall man senare vill ha ett item som ökar ens manaregen så kan detta 
            //var ett bra sätt att göra det men det kan också bero på ifall det skulle vara ett permanent eller temporärt item
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


        public void Invincibility()
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
