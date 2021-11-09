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

        protected virtual void MovementInput()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += 1;
            }
        }
    }
}
