using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    public class MenuButton : Component
    {

        #region Fields
        private MouseState currentMouse;

        private SpriteFont font;

        private bool isHovering;

        private MouseState previosMouse;

        private Texture2D texture;
        #endregion

        #region Properties

        public EventHandler click;

        public bool clicked { get; private set; }

        public Color penColor { get; set; }

        public Vector2 position { get; set; }

        public Rectangle menuRectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        public string text { get; set; }

        #endregion

        public MenuButton(Texture2D texture, SpriteFont Font)
        {
            this.texture = texture;

            this.font = Font;

            penColor = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Color colour = Color.White;

            if (isHovering)
            {
                colour = Color.Gray;
            }

            spriteBatch.Draw(texture, menuRectangle, colour);

            if (!string.IsNullOrEmpty(text))
            {
                float textX = (menuRectangle.X + (menuRectangle.Width / 2) - (font.MeasureString(text).X / 2));
                float textY = (menuRectangle.Y + (menuRectangle.Height / 2) - (font.MeasureString(text).Y / 2));
                
                spriteBatch.DrawString(font, text, new Vector2(textX, textY), penColor);
            }

        }

        public override void Update(GameTime gameTime)
        {
            previosMouse = currentMouse;
            currentMouse = Mouse.GetState();

            Rectangle mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isHovering = false;

            if (mouseRectangle.Intersects(menuRectangle))
            {
                isHovering = true;

                if (currentMouse.LeftButton == ButtonState.Released && previosMouse.LeftButton == ButtonState.Pressed)
                {
                    click.Invoke(this, new EventArgs());
                }

            }
        }
    }
}
