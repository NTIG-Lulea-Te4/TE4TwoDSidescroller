using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{

    public class MeleeAttack : Entity
    {

        Texture2D attackTexture;
        protected float attackDuration;
        public MeleeAttack()
        {

            collisionBox = new Rectangle();

        }

        public override void Update(GameTime gameTime)
        {

            attackDuration += gameTime.ElapsedGameTime.Milliseconds;

            if (attackDuration > 250)
            {
                GameInfo.entityManager.RemoveEntity(this.uniqeId);
                attackDuration = 0;
            }



        }

        public override void Draw(GameTime gameTime)
        {
            


        }

    }
}

