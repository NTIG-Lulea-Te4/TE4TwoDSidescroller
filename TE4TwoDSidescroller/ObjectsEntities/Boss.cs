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
        private Texture2D heavyAttackTexture;
        Vector2 bossPosition;
        Health health;
        List<Vector2> heavyAttacks;
        double heavyAttackTimer;


        public Boss()
        {
            bossPosition = new Vector2(200, 200);
            currentHealth = maxHealth;
            heavyAttacks = new List<Vector2>();
            heavyAttackTimer = 0;

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
            string secondPath =
             Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs" + "/Box.png";

            using (Stream textureStream = new FileStream(secondPath, FileMode.Open))
            {

                heavyAttackTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }


        }

        public override void HasCollidedWith(Entity collider)
        {
            if (collider.tag == Tags.PlayerAttack.ToString())
            {
                health.TakeDamage(currentHealth, Player.playerDamage, this);
            }
        }

        public override void Attack1()
        {
            for (int i = 0; i < heavyAttacks.Count; i++)
            {
                heavyAttacks[i] = heavyAttacks[i] + new Vector2(0, 2);
            }

            if (GameInfo.player1Position.X - GameInfo.bossPosition.X < 500 && heavyAttackTimer > 2)
            {
                heavyAttackTimer = 0;
                heavyAttacks.Add(new Vector2(GameInfo.player1Position.X, 0));
            }
        }

        public override void Attack2()
        {
            
        }

        //public override void Attack1() //byt till virtual i fall om det inte funkar
        //{

        //}

        public override void Update(GameTime gameTime)
        {

            heavyAttackTimer += gameTime.ElapsedGameTime.TotalSeconds;
            //// *base.Update(gameTime);  
            Attack1();
        }

        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(bossTexture, bossPosition, Color.White);
            foreach (Vector2 heavyAttack in heavyAttacks)
            {
                GameInfo.spriteBatch.Draw(heavyAttackTexture, heavyAttack, Color.White);
            }

        }
    }
}
