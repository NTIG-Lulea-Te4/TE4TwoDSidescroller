﻿using Microsoft.Xna.Framework;
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
        Vector2 attack1;
        static float attack1Dmg;


        public Boss()
        {
            bossPosition = new Vector2(1150, 600);
            heavyAttacks = new List<Vector2>();
            heavyAttackTimer = 0;
            health = new Health();
            maxHealth = 2000;
            currentHealth = maxHealth;
            tag = Tags.Boss.ToString();
            collisionBox = new Rectangle(1150, 600, 64, 96);
            attack1 = new Vector2(0, 3);
            attack1Dmg = 10f;

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

            if (collider.tag == Tags.PlayerMeleeAttack.ToString())
            {
                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

            if (collider.tag == Tags.PlayerRangeAttack.ToString())
            {
                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
            }
                 
        }
        public void Collection()
        {
            //if (collider.tag == Tags.Player.ToString())
            //{
            //    heavyAttacks = null;
            //}
        }

        public override void Attack1()
        {
            //tag = Tags.BossAttack1.ToString();

            if (GameInfo.player1Position.X - GameInfo.bossPosition.X < 500 && heavyAttackTimer > 2)
            {
                heavyAttackTimer = 0;
                heavyAttacks.Add(new Vector2(GameInfo.player1Position.X, 0));
            }
            for (int i = 0; i < heavyAttacks.Count; i++)
            {
                heavyAttacks[i] = heavyAttacks[i] + attack1;
            }

            collisionBox = new Rectangle((int)attack1.X, (int)attack1.Y, 64, 96);
        }

        public override void Attack2()
        {
            //tag = Tags.BossAttack2.ToString();

        }

        //public override void Attack1() //byt till virtual i fall om det inte funkar
        //{

        //}

        public override void Update(GameTime gameTime)
        {

            heavyAttackTimer += gameTime.ElapsedGameTime.TotalSeconds;
            //// *base.Update(gameTime);  
            Attack1();
            Collection();
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
