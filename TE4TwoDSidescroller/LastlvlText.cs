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
        private string text;

        public LastlvlText()
        {
            text = "ae2";


        }
        public static void ContentLoad(ContentManager content)
        {
            font = content.Load<SpriteFont>("Fonts/Arial16");
        }

        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(bossTexture, bossPosition, Color.White);
            if (font != null)
            {
                GameInfo.spriteBatch.DrawString(font, text, new Vector2(200, 500), Color.White);
            }
        }
    }
}
