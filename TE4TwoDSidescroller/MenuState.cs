using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    public class MenuState : States
    {

        private List<Component> components;
        public MenuState(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, graphics, content)
        {
            //ladda in file till en texture 2d och en spritefont
            
            Texture2D buttonTexture;
            SpriteFont buttonFont = content.Load<SpriteFont>("ButtonFont.xml");

            
            string secondPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/MainCharacters/" + "ShadowRunRight.png";
            using (Stream textureStream = new FileStream(secondPath, FileMode.Open))
            {
                buttonTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            MenuButton newGameButton = new MenuButton(buttonTexture, buttonFont)
            {

                position = new Vector2(300, 200),
                text = "Start Game",

            };

            newGameButton.click += newGameButton_Click;

            MenuButton quitGameButton = new MenuButton(buttonTexture, buttonFont)
            {

                position = new Vector2(300, 250),
                text = "Start Game",

            };

            quitGameButton.click += quitGameButton_Click;

            components = new List<Component>()
            {
                newGameButton,
                quitGameButton,
            };
            
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameState(game, graphicsDevice, content));
        }
        private void quitGameButton_Click(object sender, EventArgs e)
        {
            game.Exit();
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (Component component in components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //remove sprites if not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Component component in components)
            {
                component.Update(gameTime);
            }
        }
    }
}
