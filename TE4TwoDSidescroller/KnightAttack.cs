using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class KnightAttack : Knight
    {
        Texture2D knightAttackTexture;

        int attackWidth;
        int attackHeight;
        float attackDuration;

        public KnightAttack()
        {

            attackWidth = 40;
            attackHeight = 20;

            isActive = true;
            hasCollider = true;
            tag = Tags.KnightAttack.ToString();
            if (isFacingRight)
            {

                collisionBox = new Rectangle((int)knightPosition.X + sourceRectangle.Width,
                    (int)knightPosition.Y + sourceRectangle.Height / 2,
                    attackWidth, attackHeight);

            }
            else
            {
                collisionBox = new Rectangle((int)knightPosition.X - sourceRectangle.Width,
                    (int)knightPosition.Y + sourceRectangle.Height / 2,
                    attackWidth, attackHeight);
            }



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

            GameInfo.spriteBatch.Draw(knightAttackTexture, collisionBox, Color.White);


        }

    }
}
