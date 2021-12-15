using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        static SpriteFont font;
        private string text;
        public Texture2D bossTexture;
        public Vector2 bossPosition;
        Health health;
        public static int bossAttackdmg;
        public static int bossAttack1dmg;
        bool hasTakenDamage;
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
            maxHealth = 100;
            currentHealth = maxHealth;
            tag = Tags.Boss.ToString();
            bossAttackdmg = 10;
            bossAttack1dmg = 50;
            LoadTextrue2D();
            collisionBox = new Rectangle((int)bossPosition.X, (int)bossPosition.Y,
                                          bossTexture.Width, bossTexture.Height);
            //bossSourceRectangle = new Rectangle(0, 0, 64, 96);
            //bossScale = new Vector2(1, 1);
            hasCollider = true;
            text = "ada";
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
                hasTakenDamage = true;
            }

            if (collider.tag == Tags.PlayerRangeAttack.ToString())
            {
                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
                hasTakenDamage = true;
            }

            //if (collider.tag == Tags.Player.ToString())
            //{
            //    GameInfo.entityManager.RemoveEntity(this.uniqeId);
            //}

        }
        #endregion

        public override void Attack1()
        {
            Entity BossAttack = new BossAttack(this);
            GameInfo.entityManager.AddEntity(BossAttack);
        }

        public override void Attack2()
        {
            Entity BossAttack1 = new BossAttack1(this);
            GameInfo.entityManager.AddEntity(BossAttack1);
        }

        //public static void ContentLoad(ContentManager content)
        //{
        //    font = content.Load<SpriteFont>("Fonts/Arial16");
        //}

        public override void Update(GameTime gameTime)
        {
            GameInfo.bossPosition = bossPosition;
            base.Update(gameTime);
        }

      
        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(bossTexture, bossPosition, Color.White);
            //if (font != null)
            //{
            //    GameInfo.spriteBatch.DrawString(font, text, new Vector2(200, 500), Color.White) ;
            //}
        }
    }
}
