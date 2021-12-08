using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class PlayerMelee : MeleeAttack
    {

        Texture2D playerAttackTexture;

        public PlayerMelee()
        {
            //isPlayerAttack = true;
            isActive = true;
            hasCollider = true;
            tag = Tags.PlayerAttack.ToString();

            collisionBox = new Rectangle((int)GameInfo.player1Position.X, 
                (int)GameInfo.player1Position.Y, 100, 96);

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

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw(playerAttackTexture, collisionBox, Color.White);

        }
    }
}
