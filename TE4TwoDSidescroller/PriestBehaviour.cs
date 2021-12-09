using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class PriestBehaviour : CharacterInput
    {
        private Vector2 distance;

        float attackTimer;
        float jumpTimer;

        public PriestBehaviour(Character character) : base(character)
        {

            distance = new Vector2(300, 300);

            attackTimer = 0;
            jumpTimer = 0;
        }



    
        public override void Update(GameTime gameTime)
        {
           




        }

    }
}
