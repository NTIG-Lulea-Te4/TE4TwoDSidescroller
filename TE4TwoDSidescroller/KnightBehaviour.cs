using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class KnightBehaviour : CharacterInput
    {

        private Vector2 distance;

        float attackTimer;
        float jumpTimer;

        public KnightBehaviour(Character character) : base(character)
        {

            distance = new Vector2(300, 300);

            attackTimer = 0;
            jumpTimer = 0;
        }
        
        public override void Update(GameTime gameTime)
        {


            attackTimer += gameTime.ElapsedGameTime.Milliseconds;
            jumpTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (Knight.movementDirection.Length() <= distance.Length() &&
                Knight.knightPosition.X < GameInfo.player1Position.X)
            {

                character.MoveRight();

            }

            if (Knight.movementDirection.Length() <= distance.Length() &&
                Knight.knightPosition.X > GameInfo.player1Position.X)
            {

                character.MoveLeft();

            }

            if (Knight.knightPosition.Y > GameInfo.player1Position.Y
                && jumpTimer > 1500)
            {

                character.Jump(gameTime);

                jumpTimer = 0;
            }

            if (Knight.movementDirection.Length() <= distance.Length() - 250
                && attackTimer > 2000)
            {

                character.Attack1(gameTime);

                attackTimer = 0;
            }

        }


    }



}

