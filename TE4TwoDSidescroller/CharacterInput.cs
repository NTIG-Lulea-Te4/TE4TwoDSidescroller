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

        private Vector2 position;

        private float walkSpeed;
        private float runSpeed;

        protected virtual void MovementInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= walkSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += walkSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= walkSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += walkSpeed;
            }
        }
    }
}
