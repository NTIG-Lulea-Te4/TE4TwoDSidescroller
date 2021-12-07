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

        private string text;
        private string text1;
        private string text2;
        private string text3;
        private double timer;
        private Texture2D bossTexture;
        public SpriteFont font;
        public Vector2 bossPosition;
        ContentManager content;


        public Boss()
        {

            text1 = "idk why";
            text2 = "it dosent even matter";
            text3 = "how hard u try";
            timer = 0;
            bossPosition = new Vector2(200, 100);

            LoadTexture2D();
            LoadFont();

        }

        public void LoadTexture2D()
        {

            string currentPath =
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/GodIdlePic.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {

                bossTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }
        }

        public void LoadFont()
        {
            font = content.Load<SpriteFont>("SpriteFont");
        }
        
            
        



        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (timer < 2)
            {
                text = text1;
            }
            if (timer > 2)
            {
                text = text2;
            }
            if (timer > 4)
            {
                text = text3;
            }
            if (timer > 6)
            {
                text = "";
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw(bossTexture, bossPosition, Color.White);
            GameInfo.spriteBatch.DrawString(font, text, new Vector2(position.X - 60, position.Y - 20), Color.White);




            base.Draw(gameTime);
        }

    }




}

