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

        public float moveSpeed;

        public float runSpeed;
        public float walkSpeed;

        public float characterJumpHeight;

        public bool isRunning;
        public bool hasJumped;
        
        public Character()
        {

        }


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

        public virtual void DoNotRun()
        {

        }

        public virtual void Jump(GameTime gameTime)
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
            movementVector = Vector2.Zero;
        }
    }
}
