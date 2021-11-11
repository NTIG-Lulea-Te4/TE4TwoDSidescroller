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
        public Character()
        {
            characterInput = new CharacterInput(this);
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
        protected void Health()
        {

        }

        protected void Mana(int mana)
        {
            mana = 100;

        //    if (/*ability use or button press*/)
        //    {
        //        mana = mana - 20;
        //    }
        }

        protected void Speed()
        {
            speed = 1;
        }

        protected void Invincibility(int tmpValue)
        {
            tmpValue = health;

            //if (health <= )
            //{

            //}
        }

        protected void Sprint(int stamina)
        {
            stamina = 100;

            //while (/*key hold*/)
            //{
            //    stamina -= 1;

            //    while (speed < 3)
            //    {
            //        speed = speed + 2;
            //    }
            //}

            speed = 1;
        }
    }
}
