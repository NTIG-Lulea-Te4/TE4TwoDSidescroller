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

        public string text = "asdw";
        public string text1;
        public string text2;
        public double timer = 0;
        public Texture2D bossTexture;

        public Boss()
        {
            string currentPath =
          Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/GodIdlePic.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {

                bossTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }
        }

        public static void LoadContent()
        {
            //text = "asd";
        }
        public override void Update(GameTime gameTime)
        {
            if (timer < 2)
            {
                text = "idk why";
            }
            if (timer > 2)
            {
                text = "it dosent even matter";
            }
            if (timer > 4)
            {
                text = "how hard u try";
            }
            if (timer > 6)
            {
                text = "";
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Begin();
            GameInfo.spriteBatch.Draw(bossTexture, position, Color.White);
            GameInfo.spriteBatch.End();
            


            base.Draw(gameTime);
        }

    }

    


}

