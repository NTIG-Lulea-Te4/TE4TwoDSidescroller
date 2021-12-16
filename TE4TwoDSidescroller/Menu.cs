﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    public class Menu : Entity
    {

        Rectangle buttonHolder;
        Rectangle startButton;
        Rectangle quitButton;
        Rectangle mouseCheck;

        MouseState currentMouse;
        MouseState previosMouse;

        Vector2 startTextPosition;
        Vector2 quitTextPosition;
        Vector2 titleTextPosition;

        Texture2D buttons;
        static SpriteFont font;

        bool isStartHovering;
        bool isQuitHovering;
        

        int buttonsHeigth;
        int buttonWidth;

        string startText;
        string quitText;
        string titleText;
        Color textColor;

        public Menu()
        {
            
            buttonsHeigth = 100;
            buttonWidth = 200;

            buttonHolder = new Rectangle(0,0,GameInfo.graphicsDevice.PreferredBackBufferWidth, GameInfo.graphicsDevice.PreferredBackBufferHeight);
            startButton = new Rectangle(buttonHolder.Width/2 - buttonWidth / 2, 300, buttonWidth, buttonsHeigth);
            quitButton = new Rectangle(buttonHolder.Width/2 - buttonWidth / 2, 500, buttonWidth, buttonsHeigth);

            wantExit = false;

            startText = "start";
            quitText = "quit";
            titleText = "MediEvil";
           
            textColor = Color.Red;

            LoadTexture2D();
            
        }


        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/" + "PurpleBox.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                buttons = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }

        public static void ContentLoad(ContentManager content)
        {
            //font = content.Load<SpriteFont>("Fonts/Arial16");
        }

        //fixa så att rektanglarna deaktiveras efter att spelet börjar
        public override void Update(GameTime gameTime)
        {
            //uppdatera musen och checka ifall den är över knapparna
            previosMouse = currentMouse;
            currentMouse = Mouse.GetState();

            mouseCheck = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isStartHovering = false;
            isQuitHovering = false;

            //checka ifall de overlappar med knapparna
            if (GameInfo.collisionManager.RectangleCollision(mouseCheck, startButton))
            {
                isStartHovering = true;

                if (currentMouse.LeftButton == ButtonState.Released && previosMouse.LeftButton == ButtonState.Pressed)
                {
                    LevelTutorial.LoadContent();
                    SoundInput.SongPlay(SoundInput.preBossMusic);
                    GameInfo.entityManager.RemoveEntity(this.uniqeId);
                }
            }
            if (GameInfo.collisionManager.RectangleCollision(mouseCheck, quitButton))
            {
                isQuitHovering = true;

                if (currentMouse.LeftButton == ButtonState.Released && previosMouse.LeftButton == ButtonState.Pressed)
                {

                    wantExit = true;

                }
            }
            
        }

        public override void Draw(GameTime gameTime)
        {
            Color startColour = Color.White;
            Color quitColour = Color.White;

            if (isStartHovering)
            {
                startColour = Color.Gray;
            }
            if (isQuitHovering)
            {
                quitColour = Color.Gray;
            }

            GameInfo.spriteBatch.Draw(buttons, startButton, startColour);
            GameInfo.spriteBatch.Draw(buttons, quitButton, quitColour);

            //rita ut texten här
            //if (!string.IsNullOrEmpty(startText))
            //{
            //    #region textPosition
            //    startTextPosition.X = (startButton.X + (startButton.Width / 2) - (font.MeasureString(startText).X / 2));
            //    startTextPosition.Y = (startButton.Y + (startButton.Height / 2) - (font.MeasureString(startText).X / 2));


            //    quitTextPosition.X = (quitButton.X + (quitButton.Width / 2) - (font.MeasureString(quitText).X / 2));
            //    quitTextPosition.Y = (quitButton.Y + (quitButton.Height / 2) - (font.MeasureString(quitText).X / 2));
                
            //    titleTextPosition.X = (buttonHolder.X + (buttonHolder.Width / 2 - 25) - (font.MeasureString(quitText).X / 2));
            //    titleTextPosition.Y = (buttonHolder.Y + (buttonHolder.Height / 6) - (font.MeasureString(quitText).X / 2));
             
            //    #endregion
            //    if (font != null)
            //    {

            //         GameInfo.spriteBatch.DrawString(font, startText, startTextPosition, textColor);
            //         GameInfo.spriteBatch.DrawString(font, quitText, quitTextPosition, textColor);
            //         GameInfo.spriteBatch.DrawString(font, titleText, titleTextPosition, textColor);

            //    }
            //}
        }
    }
}
