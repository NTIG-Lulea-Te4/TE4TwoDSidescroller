using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class BossBehaviour : CharacterInput
    {
        double heavyAttackTimer;
        //static SpriteFont font;

        public BossBehaviour(Character character) : base(character)
        {
            heavyAttackTimer = 0;
        }
        //public static void ContentLoad(ContentManager content)
        //{
        //    font = content.Load<SpriteFont>("Fonts/Arial16");
        //}
        public override void Update(GameTime gameTime)
        {
            heavyAttackTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GameInfo.bossPosition.X - GameInfo.player1Position.X < 500 && heavyAttackTimer > 2)
            {
                heavyAttackTimer = 0;
                character.Attack1();
                character.Attack2();
            }
            if ( heavyAttackTimer > 2)
            {
                heavyAttackTimer = 0;
                character.Attack2();
            }
        }
    }
}
