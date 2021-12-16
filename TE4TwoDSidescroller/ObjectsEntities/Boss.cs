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
<<<<<<< HEAD
        private Texture2D bossTexture;
        private Texture2D heavyAttackTexture;
        Vector2 bossPosition;
        Health health;
        List<Vector2> heavyAttacks;
        double heavyAttackTimer;
        Vector2 attack1;

        Animation tempIdle;
        Animation tempOuch;
        Animation tempFirstAttack;
        Animation tempSecondAttack;
        Animation tempBigRockAnimation;

        public Boss()
        {
            bossPosition = new Vector2(1150, 600);
=======
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
>>>>>>> parent of d90306e (Damage and attack fixed)
            currentHealth = maxHealth;
            heavyAttacks = new List<Vector2>();
            heavyAttackTimer = 0;
            health = new Health();
            tag = Tags.Boss.ToString();
<<<<<<< HEAD
<<<<<<< HEAD
            collisionBox = new Rectangle(0, 0, 64, 96);
            attack1 = new Vector2(0, 3);
            float attack1Dmg = 10f;

=======
            bossAttackdmg = 10;
            bossAttack1dmg = 50;
>>>>>>> parent of 1400a7f (a)
            LoadTextrue2D();

            GodDictionary();
=======
            bossAttack1dmg = 10;
            LoadTextrue2D();
            //bossSourceRectangle = new Rectangle(0, 0, 64, 96);
            //bossOrgin = new Vector2(0, 0);
            //bossScale = new Vector2(1, 1);
>>>>>>> parent of d90306e (Damage and attack fixed)
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

        private void GodDictionary()
        {
            animationManager.animations.TryGetValue("godIdle", out tempIdle);
            animationManager.animations.TryGetValue("godOuch", out tempOuch);
            animationManager.animations.TryGetValue("godFirstAttack", out tempFirstAttack);
            animationManager.animations.TryGetValue("godSecondAttack", out tempSecondAttack);
            animationManager.animations.TryGetValue("bigRock", out tempBigRockAnimation);
        }

        private void GodAnimation()
        {

        }

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
<<<<<<< HEAD
=======

            if (collider.tag == Tags.Player.ToString())
            {

            }
>>>>>>> parent of d90306e (Damage and attack fixed)
        }

        public override void Attack1()
        {
<<<<<<< HEAD
            tag = Tags.BossAttack1.ToString();
            collisionBox = new Rectangle((int) attack1.X, (int) attack1.Y, 64, 96);
            for (int i = 0; i < heavyAttacks.Count; i++)
            {
                heavyAttacks[i] = heavyAttacks[i] + attack1;
            }

            if (GameInfo.player1Position.X - GameInfo.bossPosition.X < 500 && heavyAttackTimer > 2)
            {
                heavyAttackTimer = 0;
                heavyAttacks.Add(new Vector2(GameInfo.player1Position.X, 0));
            }
        }

        public override void Attack2()
        {
            tag = Tags.BossAttack2.ToString();

        }

        //public override void Attack1() //byt till virtual i fall om det inte funkar
        //{

        //}

        public override void Update(GameTime gameTime)
        {

            heavyAttackTimer += gameTime.ElapsedGameTime.TotalSeconds;
            //// *base.Update(gameTime);  
            Attack1();
=======
            Entity BossAttack = new BossAttack(this);
            GameInfo.entityManager.AddEntity(BossAttack);

            Entity BossAttack1 = new BossAttack1(this);
            GameInfo.entityManager.AddEntity(BossAttack1);
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);          
>>>>>>> parent of d90306e (Damage and attack fixed)
        }

        public override void Draw(GameTime gameTime)
        {
            //animationManager.animation.Draw(gameTime);

            GameInfo.spriteBatch.Draw(bossTexture, bossPosition, Color.White);
<<<<<<< HEAD
            foreach (Vector2 heavyAttack in heavyAttacks)
            {
                GameInfo.spriteBatch.Draw(heavyAttackTexture, heavyAttack, Color.White);
            }

=======
>>>>>>> parent of d90306e (Damage and attack fixed)
        }
    }
}
