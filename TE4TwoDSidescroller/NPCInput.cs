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

        public Vector2 startPoint = new Vector2(100, 450);
        public bool moveRight = true;
        public int pointA = 100;
        public int pointB = 200;
        public float npcSpeed = 0.2f;

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
            //if (startPoint.X > pointB || startPoint.X < pointA)
            //{
            //    moveRight = !moveRight;
            //}

            do
            {
                Console.WriteLine("yey");
            } while (1 > 0);


        }




    }
}
