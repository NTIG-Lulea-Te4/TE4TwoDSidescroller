using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using MonoGame;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace TE4TwoDSidescroller
{
    class Background : LevelTutorial
    {
        Texture2D myTexture;
        Rectangle myRectangle;
        Rectangle sourceRectangle;
        Vector3 scrollSpeed;
        float layer;
        float rotation;
        
        

        public Background()
        {
            layer = 0.0f;
            rotation = 0f;
            scrollSpeed = new Vector3();
            myRectangle = new Rectangle(0, 0, 1280, 720);
            sourceRectangle = new Rectangle(0, 0, 320, 180);
            
            string currentPath =
           Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/" + "Background.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {

                myTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }

        }

        public override void Update(GameTime gameTime)
        {
            
            


        }

        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw
                (myTexture, myRectangle, myRectangle, Color.White, rotation, position, SpriteEffects.None, layer);


        }

    }
}
