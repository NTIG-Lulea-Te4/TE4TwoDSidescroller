using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class BossBehaviour : CharacterInput
    {
        double heavyAttackTimer;

        public BossBehaviour(Character character) : base(character)
        {
            heavyAttackTimer = 0;

        }
        public override void Update(GameTime gameTime)
        {
            heavyAttackTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GameInfo.player1Position.X - GameInfo.bossPosition.X < 500 && heavyAttackTimer > 2)
            {
                heavyAttackTimer = 0;
                character.Attack1();
            }   
           
        }

    }
}
