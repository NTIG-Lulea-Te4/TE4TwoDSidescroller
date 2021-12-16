using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class LastlvlText : Boss
    {
        static SpriteFont font;
        private string text0;
        private string text;
        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private string text5;
        private string text6;
        private string text7;
        private float timer;
        private Vector2 textposition;

        public LastlvlText()
        {
            text = "";
            text0 = "its the boss, so be carefull champion of hell";
            text1 = "he called Bjarne and he will bully u till u die";
            text2 = "kill him and we will be free";
            text3 = "Who are you";
            text4 = "How dare you to challange me";
            text5 = "Go back while you can";
            text6 = "I will kill you, as what you wish";
            text7 = "";
            timer = 0;
            textposition = new Vector2(200, 500);


        }


        public static void ContentLoad(ContentManager content)
        {
            font = content.Load<SpriteFont>("Fonts/Arial16");
        }

        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > 0)
            {
                text = text0;
            }
            if (timer > 3)
            {
                text = text1;
            }
            if (timer > 6)
            {
                text = text2;
            }
            if (timer > 9)
            {
                textposition = new Vector2(500, 500);
                text = text3;
            }
            if (timer > 12)
            {
                text = text4;
            }
            if (timer > 15)
            {
                text = text5;
            }
            //if (timer > 18)
            //{
            //    text = "";
            //}
            if (timer > 21 || GameInfo.bossPosition.X - GameInfo.player1Position.X < 500)
            {
                timer = 22;
                textposition = new Vector2(700, 500);
                text = text6;
            }
            //if (timer > 21)
            //{
            //    textposition = new Vector2(700, 500);
            //    text = text6;
            //}
            //if (GameInfo.bossPosition.X - GameInfo.player1Position.X < 500)
            //{
            //    timer = 25;
            //    text = text6;
            //}
            //if (timer > 21)
            //{
            //    text = text7;
            //}
            if (timer > 25)
            {
                text = "";
            }
        }
            
        
        public override void Draw(GameTime gameTime)
        {

            if (font != null)
            {
                GameInfo.spriteBatch.DrawString(font, text, textposition, Color.White);
            }

        }
    }
}
