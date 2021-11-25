using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class PlayerTest : Entity
    {

        Texture2D playerTestTexture;
        public static Color[] colorData;
        public static Vector2 playerPosition;
        
        int positionX;
        int positionY;


        public PlayerTest()
        {
            collisionBox = new Rectangle(positionX, positionY, 101, 101);


            isActive = true;
            hasCollider = true;
            isPlayer = true;

            positionX = 500;
            positionY = 0;

            playerPosition = new Vector2(positionX, positionY);



            LoadTexture2D();

            colorData = new Color[playerTestTexture.Width * playerTestTexture.Height];
            playerTestTexture.GetData(colorData);

        }


        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/" + "PurpleBox.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                playerTestTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }
            
        }



        public override void Update(GameTime gameTime)
        {

            #region Controls for testing

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                positionX -= 1 * gameTime.ElapsedGameTime.Milliseconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                positionX += 1 * gameTime.ElapsedGameTime.Milliseconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                positionY += 1 * gameTime.ElapsedGameTime.Milliseconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                positionY -= 1 * gameTime.ElapsedGameTime.Milliseconds;
            }

            playerPosition.X = positionX;
            playerPosition.Y = positionY;
            collisionBox.X = positionX;
            collisionBox.Y = positionY;
            #endregion


           
        }

        public override void Draw(GameTime gameTime)
        {

            //GameInfo.spriteBatch.Draw(playerTestTexture, testRectangle, Color.White);

        }

    }
}
