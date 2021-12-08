using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace TE4TwoDSidescroller
{
    class Boss : Character
    {
        private Texture2D bossTexture;
        private Vector2 bossPosition;
        Health health;


        public Boss(int X, int Y)
        {
            bossPosition = new Vector2(X, Y);
            currentHealth = maxHealth;
            //tag = Tags.Boss.ToString();

            LoadTextrue2D();
        }

        public void LoadTextrue2D()
        {
            string currentPath =
             Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/GodIdlePic.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {

                bossTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }
        }

        public override void HasCollidedWith(Entity collider)
        {
            if (collider.tag == Tags.PlayerAttack.ToString())
            {
                health.TakeDamage(currentHealth, Player.playerDamage, this);
            }
        }



        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(bossTexture, bossPosition, Color.White);

            
        }
    }
}
