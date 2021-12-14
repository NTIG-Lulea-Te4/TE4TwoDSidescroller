using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class BossAttack1 : Entity
    {

        int attackWidth;
        int attackHeight;
        int movementSpeed;
        Texture2D BossAttack1Texture;
        Vector2 projectileDirection;

        public BossAttack1(Character character)
        {

            projectileDirection = new Vector2();
            projectileDirection = character.movementDirection;

            attackWidth = 40;
            attackHeight = 20;

            movementSpeed = 4;

            isActive = true;
            hasCollider = true;
            tag = Tags.BossAttack1.ToString();



            collisionBox = new Rectangle((int)GameInfo.player1Position.X, 0
                ,
                attackWidth, attackHeight);




            LoadPriestTexture2D();



        }

        public void LoadPriestTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/" + "Box.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                BossAttack1Texture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }

        //public override void HasCollidedWith(Entity collider)
        //{

        //    GameInfo.entityManager.RemoveEntity(this.uniqeId);

        //}
        //public void Animate()
        //{
        //    if (GameInfo.player1IsFacingRight)
        //    {
        //        animation.spriteEffects = SpriteEffects.None;
        //    }
        //    else
        //    {
        //        animation.spriteEffects = SpriteEffects.FlipHorizontally;
        //    }
        //}

        public override void Update(GameTime gameTime)
        {
            //projectileDirection.X += movementSpeed;
            //projectileDirection.Y += movementSpeed;


            collisionBox.Y += movementSpeed;
            //collisionBox.Y += (int)projectileDirection.Y;

            //Animate();

            //animation.position.X = collisionBox.X;
            //animation.position.Y = collisionBox.Y - 50;
            //animation.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw(BossAttack1Texture, collisionBox, Color.White);
            //animation.Draw(gameTime);
        }
    }



}


