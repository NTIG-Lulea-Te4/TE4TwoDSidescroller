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
        Texture2D heavyAttackTexture;
        private int attackWidth;
        private int attackHeigh;
        private int attackSpeed;

        public BossAttack1(Character character)
        {
            tag = Tags.BossAttack.ToString();
            isActive = true;
            hasCollider = true;
            attackWidth = 80;
            attackHeigh = 80;
            attackSpeed = 5;

            if (GameInfo.player1Position.X - GameInfo.bossPosition.X < 500)
            {
                collisionBox = new Rectangle((int)GameInfo.bossPosition.X,
                (int)GameInfo.bossPosition.Y,
                attackWidth, attackHeigh);
            }
            LoadTextrue();
        }

        public void LoadTextrue()
        {
            string currentPath =
             Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs" + "/Box.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                heavyAttackTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }
        }

        public override void Update(GameTime gameTime)
        {
            collisionBox.X += attackSpeed;
        }

        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(heavyAttackTexture, collisionBox, Color.White);
        }
    }
}
