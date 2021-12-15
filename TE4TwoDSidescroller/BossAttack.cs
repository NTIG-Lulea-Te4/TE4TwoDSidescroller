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
        private int attackWidth;
        private int attackHeigh;
        private int attackSpeed;
        public static bool damage;
             
        public BossAttack(Character character)
        {
            tag = Tags.BossAttack.ToString();
            hasCollider = true;
            attackWidth = 80;
            attackHeigh = 80;
            attackSpeed = 5;
            damage = false;

        
            collisionBox = new Rectangle((int)GameInfo.player1Position.X,
            0,
            attackWidth, attackHeigh);
            
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
        public override void HasCollidedWith(Entity collider)
        {
            if (collider.tag == Tags.Player.ToString())
            {
                GameInfo.entityManager.RemoveEntity(this.uniqeId);
                damage = true;
            }
        }

        //public override void HasCollidedWith(Entity collider)
        //{
        //    if (collider.tag == Tags.Player.ToString())
        //    {
        //        currentHealth = Player.health.TakeDamage(currentHealth, Boss.bossAttackdmg, this);
        //        hasTakenDamage = true;
        //        GameInfo.entityManager.RemoveEntity(this.uniqeId);
        //    }
        //}

        public override void Update(GameTime gameTime)
        {
            collisionBox.Y += attackSpeed;
        }

        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(heavyAttackTexture, collisionBox, Color.White);
        }
    }
}
