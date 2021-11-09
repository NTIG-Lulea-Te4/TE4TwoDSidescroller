using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    class CharacterInput
    {

        private Vector2 characterPosition;

        private float walkSpeed;
        private float runSpeed;

        private float characterVelocity;

        private float characterJumpHeight;

        private Keys left;
        private Keys right;
        private Keys up;
        private Keys down;

        private Keys jump;

        private Keys run;


        #region Keys
        protected virtual Keys Left
        {
            get
            {
                return left;
            }
            //set
            //{
            //    left = Keys.A;
            //}
        }

        protected virtual Keys Right
        {
            get
            {
                return right;
            }
            //set
            //{
            //    right = Keys.D;
            //}
        }

        protected virtual Keys Up
        {
            get
            {
                return up;
            }
            //set
            //{
            //    up = Keys.W;
            //}
        }

        protected virtual Keys Down
        {
            get
            {
                return down;
            }
            //set
            //{
            //    down = Keys.S;
            //}
        }

        protected virtual Keys Jump
        {
            get
            {
                return jump;
            }
            //set
            //{
            //    jump = Keys.Space;
            //}
        }

        protected virtual Keys Run
        {
            get
            {
                return run;
            }
            //set
            //{
            //    run = Keys.LeftShift;
            //}
        }

        //private Keys left { get; set; }

        #endregion

        #region CharacterMovement
        protected virtual void CharacterUp()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                characterPosition.Y -= characterVelocity;
            }
        }

        protected virtual void CharacterDown()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                characterPosition.Y += characterVelocity;
            }
        }

        protected virtual void CharacterLeft()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                characterPosition.X -= characterVelocity;
            }
        }

        protected virtual void CharacterRight()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                characterPosition.X += characterVelocity;
            }
        }

        protected virtual void CharacterIsRunningCheck()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                characterVelocity = runSpeed;
            }
            else
            {
                characterVelocity = walkSpeed;
            }
        }

        protected virtual void CharaterIsJumping()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                characterPosition.Y -= characterJumpHeight;
            }
        }
    }

    #endregion
}
