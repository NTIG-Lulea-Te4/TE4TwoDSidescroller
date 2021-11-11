using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace TE4TwoDSidescroller
{
    class Floor : LevelTutorial
    {
        Texture2D myTexture;
        Vector2 myPosition;
        Rectangle myRectangle;
        public Floor()
        {
            
            
        }
        public void Initialize()
        {
            myPosition = new Vector2(1, 1);
            myRectangle = new Rectangle((int)myPosition.X, (int)myPosition.Y , 50, 50);
            myTexture = new Texture2D
                (GameInfo.graphicsDevice.GraphicsDevice, myRectangle.Width, myRectangle.Height);
            
            


        }
        public override void Draw(GameTime gameTime)
        {

            
            GameInfo.spriteBatch.Draw(myTexture, myRectangle, Color.Red);
            

        }
        public override void Update(GameTime gameTime) 
        { 
        
        
        
        }



    }
}
