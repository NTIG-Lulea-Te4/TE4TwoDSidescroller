using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class HealthBar : Player
    {
        //skapa rektangel i vänster hörn
        //ladda in två bilder ena är högre en den andra
        //koppla ihop med player hp
        //och uppdatera med rektangelns hp

        Player player;

        Rectangle healthBar;
        Vector2 healtBarPosition;
        Texture2D healthBarTexture;


        HealthBar()
        {
            player = new Player();

            healtBarPosition.X = 100;
            healtBarPosition.Y = 100;
            
            healthBar = new Rectangle((int)healtBarPosition.X, (int)healtBarPosition.Y, player.playerHealthBar, 100);
        }

        public void LoadContent(ContentManager content)
        {

           healthBarTexture = content.Load<Texture2D>("healthBar");

        }

        public override void Update(GameTime gameTime)
        {
            // behövver göra det relativt till cameran
            healtBarPosition.X = 100;
            healtBarPosition.Y = 100; 
        }

        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(healthBarTexture, healthBar, Color.White);
        }
    }
}
