using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    class NPCInput : CharacterInput
    {
        Character character;

        static Vector2 startPoint;
        public bool moveRight = true;
        static int pointA = 100;
        //static Vector2 pointB = character.position.X;
        //public Vector2 character.position.X = startP;
        //public float npcSpeed = 0.2f;
        //character.position.X = new Vector2 st

        private NPCInput(Character character) 
            : base(character)
        {

        }


        public override void Update(GameTime gameTime)
        {
            if (moveRight)
            {
                //startPoint.X += npcSpeed * (float)GameInfo.gameTime.ElapsedGameTime.TotalMilliseconds;
                character.MoveRight();            
            }
            else
            {
                //startPoint.X -= npcSpeed * (float)GameInfo.gameTime.ElapsedGameTime.TotalMilliseconds;
                character.MoveLeft();
            }

            //if (character.position.X > pointB || character.position.X < pointA)
            //{
            //    moveRight = !moveRight;
            //} 
            if (character.position.X > pointB || character.position.X < pointA)
            {
                moveRight = !moveRight;
            }
            character.position

            do
            {
                Console.WriteLine("yey");
            } while (1 > 0);


        }




    }
}
