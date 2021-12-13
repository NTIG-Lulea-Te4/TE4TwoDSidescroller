using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class KnightBehaviour : CharacterInput
    {

        private Vector2 trackingDistance;

        int spacingBetweenEntities;
        float attackTimer;
        float jumpTimer;

        public KnightBehaviour(Character character) : base(character)
        {

            trackingDistance = new Vector2(400, 400);
            attackTimer = 0;
            jumpTimer = 0;
            spacingBetweenEntities = 50;
        }
        
        public override void Update(GameTime gameTime)
        {


            attackTimer += gameTime.ElapsedGameTime.Milliseconds;
            jumpTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (character.movementDirection.Length() <= trackingDistance.Length() &&
                character.position.X + spacingBetweenEntities < GameInfo.player1Position.X)
            {

                character.MoveRight();
                
            }

            if (character.movementDirection.Length() <= trackingDistance.Length() &&
                character.position.X - spacingBetweenEntities > GameInfo.player1Position.X)
            {

                character.MoveLeft();

            }

            if (character.position.Y > GameInfo.player1Position.Y)
            {

                character.Jump(gameTime);

                jumpTimer = 0;
            }

            if (character.movementDirection.Length() <= trackingDistance.Length() - 250
                && attackTimer > 2000)
            {

                character.Attack1();

                attackTimer = 0;
            }

        }


    }



}

