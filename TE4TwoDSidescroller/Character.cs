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

        private Vector2 characterPosition;

        private int runSpeed;
        private int walkSpeed;

        private int characterVelocity;

        private int characterJumpHeight;

        private bool isRunning;

        private bool ifHit;
        private int health;
        private int speed;

        
        public bool sprint;
        public int staminga;

        private int tickTimer;
        public Character()
        {

            characterPosition.Y = 50;
            characterPosition.X = 50;

            staminga = 100;
            tickTimer = 0;
            sprint = false;
        }

        #region Properties

        public int CharacterVelocity
        {
            get
            {
                return characterVelocity;
            }

            set
            {
                characterVelocity = value;
            }
        }

        public int RunSpeed
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

        public int WalkSpeed
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

        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                isRunning = value;
            }
        }
        public int CharacterJumpHeight
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
