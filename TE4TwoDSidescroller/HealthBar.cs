using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class HealthBar : Entity
    {
        //skapa rektangel i vänster hörn
        //ladda in två bilder ena är högre en den andra
        //koppla ihop med player hp
        //och uppdatera med rektangelns

        Rectangle healthBar;
        Rectangle healthBarFont;

        Vector2 healtBarPosition;
        Vector2 healtBarFontPosition;

        Texture2D healthBarFontTexture;
        Texture2D healthBarTexture;
        ContentManager content;

        Player player;

        float layer;
        float layerTwo;
        float scale;
        float rotation;


        public HealthBar()
        {
            player = new Player();

            scale = 1.1f;
            layer = 0.0001f; 
            layerTwo = 0.0002f;
            rotation = 0f;

            healtBarPosition.X = -50;
            healtBarPosition.Y = -50;
            healtBarFontPosition.X = -45;
            healtBarFontPosition.Y = -45;

            // healthBarTexture = content.Load<Texture2D>("Pngs/healthBar.png");

            #region FileLoads
            string currentPath =
          Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) 
          + "/Content/Pngs/" + "Box.png";

          using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
          {

                healthBarFontTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

          }

            string secondPath =
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            + "/Content/Pngs/" + "PurpleBox.png";

            using (Stream textureStream = new FileStream(secondPath, FileMode.Open))
            {

                healthBarTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }
            #endregion

            healthBar = new Rectangle((int)healtBarPosition.X, (int)healtBarPosition.Y, player.playerHealthBar * 2 , 50);
            healthBarFont = new Rectangle((int)healtBarFontPosition.X, (int)healtBarFontPosition.Y, player.playerHealthBar * 2 + 10, 60);
        }

       

        public override void Update(GameTime gameTime)
        {

            healthBar.Width = player.playerHealthBar * 2; 

        }

        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw(healthBarFontTexture, GameInfo.viewportPosition, healthBarFont, Color.White, rotation, healtBarFontPosition, scale, SpriteEffects.None, layer);
            GameInfo.spriteBatch.Draw(healthBarTexture, GameInfo.viewportPosition, healthBar, Color.White, rotation, healtBarPosition, scale, SpriteEffects.None, layerTwo);

        }
    }
}
