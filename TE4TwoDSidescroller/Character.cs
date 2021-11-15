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
        public virtual void MoveUp()
        {
            characterPosition.Y -= characterVelocity;
        }

        public virtual void MoveDown()
        {
            characterPosition.Y += characterVelocity;
        }

        public virtual void MoveLeft()
        {
            characterPosition.X -= characterVelocity;
        }

        public virtual void MoveRight()
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
