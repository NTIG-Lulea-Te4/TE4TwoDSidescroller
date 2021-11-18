using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    public class Character : Entity
    {
        public CharacterInput characterInput;

        //private Vector2 characterVelocity;
        //private int characterVelocity;

        private float runSpeed;
        private float walkSpeed;

        private float characterJumpHeight;

        private bool hasRunned;
        private bool hasJumped;
        
        public Character()
        {

        }

        #region Properties

        //public int CharacterVelocity
        //{
        //    get
        //    {
        //        return characterVelocity;
        //    }

        //    set
        //    {
        //        characterVelocity = value;
        //    }
        //}

        //public Vector2 CharacterVelocity
        //{
        //    get
        //    {
        //        return characterVelocity;
        //    }
        //    set
        //    {
        //        characterVelocity = value;
        //    }
        //}

        public float RunSpeed
        {
            get
            {
                return runSpeed;
            }
            set
            {
                runSpeed = value;
            }
        }

        public float WalkSpeed
        {
            get
            {
                return walkSpeed;
            }
            set
            {
                walkSpeed = value;
            }
        }

        public bool HasRunned
        {
            get
            {
                return hasRunned;
            }
            set
            {
                hasRunned = value;
            }
        }

        public float CharacterJumpHeight
        {
            get
            {
                return characterJumpHeight;
            }
            set
            {
                characterJumpHeight = value;
            }
        }

        public bool HasJumped
        {
            get
            {
                return hasJumped;
            }
            set
            {
                hasJumped = value;
            }
        }

        #endregion

        #region Movement
        public virtual void MoveUp()
        {
            
        }

        public virtual void MoveDown()
        {
            
        }

        public virtual void MoveLeft()
        {
            
        }

        public virtual void MoveRight()
        {
            
        }

        public virtual void Run()
        {
            
        }

        public virtual void DontRun()
        {

        }

        public virtual void Jump(GameTime gameTime)
        {
           
        }

        public virtual void DontJump()
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

        #region Combat

        public virtual void Attack1()
        {

        }

        public virtual void Attack2()
        {

        }

        public virtual void Attack3()
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
        


       // ska sättas vars man checkar ifall man blir träffad
        public void Invincibility()
        {

            //stopp checking collision for half a second

        }


        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
