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

        protected bool ifHit;
        protected int health;
        protected int speed;
        public Character()
        {
            characterInput = new CharacterInput(this);

            characterVelocity = 1.5f;
            runSpeed = 3f;

            characterPosition.Y = 50;
            characterPosition.X = 50;

            characterJumpHeight = 3;
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
