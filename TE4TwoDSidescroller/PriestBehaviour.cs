using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class PriestBehaviour : CharacterInput
    {
        private Vector2 escapeDistance;
        private Vector2 attackRadius;

        float attackTimer;
        float jumpTimer;

        public PriestBehaviour(Character character) : base(character)
        {

            escapeDistance = new Vector2(400, 400);
            attackRadius = new Vector2(700, 700);

            attackTimer = 0;
            jumpTimer = 0;
        }



    
        public override void Update(GameTime gameTime)
        {

            attackTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (Priest.distanceBetweenPlayerAndPriest.Length() <= escapeDistance.Length() &&
                Priest.priestPosition.X  > GameInfo.player1Position.X)
            {

                character.MoveRight();

            }

            if (Priest.distanceBetweenPlayerAndPriest.Length() <= escapeDistance.Length() &&
               Priest.priestPosition.X < GameInfo.player1Position.X)
            {

                character.MoveLeft();

            }

            if (Priest.distanceBetweenPlayerAndPriest.Length() <= attackRadius.Length()
                && attackTimer > 1500)
            {

                character.Attack1();

                attackTimer = 0;
            }


        }

    }
}
