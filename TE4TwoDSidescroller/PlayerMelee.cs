using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class PlayerMelee : Entity
    {

        Texture2D playerAttackTexture;
        int attackWidth;
        int attackHeight;
        float attackDuration;
        public PlayerMelee()
        {
            //isPlayerAttack = true;
            attackWidth = 40;
            attackHeight = 20;

            isActive = true;
            hasCollider = true;
            tag = Tags.PlayerMeleeAttack.ToString();
            if (GameInfo.player1IsFacingRight)
            {

                collisionBox = new Rectangle((int)GameInfo.player1Position.X + GameInfo.Player1TextureSize.Width, 
                    (int)GameInfo.player1Position.Y + GameInfo.Player1TextureSize.Height / 2, 
                    attackWidth, attackHeight);

            }
            else
            {
                collisionBox = new Rectangle((int)GameInfo.player1Position.X - GameInfo.Player1TextureSize.Width,
                    (int)GameInfo.player1Position.Y + GameInfo.Player1TextureSize.Height / 2,
                    attackWidth, attackHeight);
            }

            LoadTexture2D();

        }

        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/" + "Box.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                playerAttackTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
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

            GameInfo.spriteBatch.Draw(playerAttackTexture, collisionBox, Color.White);

        }
    }
}
