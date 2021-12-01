﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class KnightBehaviour : CharacterInput
    {

        private Vector2 distance;

        public KnightBehaviour(Character character) : base(character)
        {

            distance = new Vector2(300, 300);


        }

        public override void Update(GameTime gameTime)
        {

            if (Knight.movementDirection.Length() <= distance.Length())
            {

                character.MoveRight();

            }

            if (Knight.movementDirection.Length() <= distance.Length())
            {

                character.MoveLeft();

            }

            if (Knight.movementDirection.Length() <= distance.Length() && 
                Knight.knightPosition.Y - 30 > PlayerTest.playerPosition.Y)
            {

                character.Jump(gameTime);

            }

            if (Knight.movementDirection.Length() <= distance.Length() - 250)
            {

                character.Attack1();

            }

        }


    }



}
