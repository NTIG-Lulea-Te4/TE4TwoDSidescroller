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

        public bool moveRight = true;
        public float startPosition;
        //public Vector2 startPoint (100, 200);
        //public float npcSpeed = 0.2f;


        private NPCInput(Character character) 
            : base(character)
        {
            character.position.X = startPosition;
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

       
            if (character.position.X > startPosition + 100 || character.position.X < startPosition)
            {
                moveRight = !moveRight;
            }


            do
            {
                Console.WriteLine("yey");
            } while (1 > 0);


        }




    }
}
