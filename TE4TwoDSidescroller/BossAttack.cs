using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class BossAttack : Entity
    {
        Texture2D heavyAttackTexture;
        //List<Vector2> heavyAttacks;
        //double heavyAttackTimer;
        private int attackWidth;
        private int attackHeigh;
        private int attackSpeed;
             


        public BossAttack(Character character)
        {
            //heavyAttacks = new List<Vector2>();
            //heavyAttackTimer = 0;
            tag = Tags.BossAttack.ToString();
            isActive = true;
            hasCollider = true;
            LoadTextrue();
            attackWidth = 80;
            attackHeigh = 80;
            attackSpeed = 5; 

            if (GameInfo.player1Position.X - GameInfo.bossPosition.X < 500)
            {
                collisionBox = new Rectangle((int)GameInfo.player1Position.X,
                0,
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
        //public override void Attack1()
        //{
        //    for (int i = 0; i < heavyAttacks.Count; i++)
        //    {
        //        heavyAttacks[i] = heavyAttacks[i] + new Vector2(0, 2);
        //    }

        //    if (GameInfo.player1Position.X - GameInfo.bossPosition.X < 500 && heavyAttackTimer > 2)
        //    {
        //        heavyAttackTimer = 0;
        //        heavyAttacks.Add(new Vector2(GameInfo.player1Position.X, 0));
        //    }


        //}

        //private void bossAttack2()
        //{
        //    if (heavyAttackTimer > 2)
        //    {
        //        heavyAttackTimer = 0;
        //        heavyAttacks.Add(new Vector2(GameInfo.player1Position.X, 0));
        //    }
        //}

        //private void bossAttack1()
        //{
        //    if (heavyAttackTimer > 2)
        //    {
        //        heavyAttackTimer = 0;
        //        heavyAttacks.Add(new Vector2(GameInfo.player1Position.X, 0));
        //    }
        //}


        //private void bossAttack1()
        //{
        //    if (heavyAttackTimer > 2)
        //    {
        //        heavyAttackTimer = 0;
        //        heavyAttacks.Add(new Vector2(GameInfo.player1Position.X, 0));
        //    }
        //}

        //private void bossAttack2()
        //{
        //    throw new NotImplementedException();
        //}
        public override void Update(GameTime gameTime)
        {

            //heavyAttackTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            collisionBox.Y += attackSpeed;
            

        }

        public override void Draw(GameTime gameTime)
        {
            //foreach (Vector2 heavyAttack in heavyAttacks)
            //{
            //    GameInfo.spriteBatch.Draw(heavyAttackTexture, heavyAttack, Color.White);
            //}
            
            GameInfo.spriteBatch.Draw(heavyAttackTexture, collisionBox, Color.White);
                
            
        }
    }
}
