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
        #region variable
        private Texture2D bossTexture;
        public Vector2 bossPosition;
        Health health;
        public static int bossAttack1dmg;
        //private Rectangle bossSourceRectangle;
        //protected Vector2 bossOrgin;
        //protected Vector2 bossScale;
        //public SpriteFont font;
        #endregion

        public Boss()
        {

            characterInput = new BossBehaviour(this);
            bossPosition = new Vector2(1250, 600);
            health = new Health();
            maxHealth = 200;
            currentHealth = maxHealth;
            tag = Tags.Boss.ToString();
            bossAttack1dmg = 10;
            LoadTextrue2D();
            //bossSourceRectangle = new Rectangle(0, 0, 64, 96);
            //bossOrgin = new Vector2(0, 0);
            //bossScale = new Vector2(1, 1);
        }

        #region LoadTextrue
        public void LoadTextrue2D()
        {
            string currentPath =
             Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/Enemies" + "/GodIdlePic.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                bossTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }
        }
        #endregion

        #region Collision
        public override void HasCollidedWith(Entity collider)
        {

            if (collider.tag == Tags.PlayerMeleeAttack.ToString())
            {
                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

            if (collider.tag == Tags.PlayerRangeAttack.ToString())
            {
                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

            if (collider.tag == Tags.Player.ToString())
            {

            }
        }
        #endregion

        public override void Attack1()
        {
            Entity BossAttack = new BossAttack(this);
            GameInfo.entityManager.AddEntity(BossAttack);

            Entity BossAttack1 = new BossAttack1(this);
            GameInfo.entityManager.AddEntity(BossAttack1);
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);          
        }

        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(bossTexture, bossPosition, Color.White);
        }
    }
}
