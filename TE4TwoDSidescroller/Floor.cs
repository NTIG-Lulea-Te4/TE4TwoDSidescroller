﻿using Microsoft.Xna.Framework;
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
        Vector2 floorPosition;

        public Floor()
        {
            isActive = true;
            hasCollider = true;
            isFloor = true;
            collisionBox = new Rectangle();
            PixelDraw();
        }


        public void PixelDraw()
        {

            floorPosition = new Vector2(0, 300);
            collisionBox = new Rectangle((int)floorPosition.X, (int)floorPosition.Y, 900, 50);
            myTexture = new Texture2D
                (GameInfo.graphicsDevice.GraphicsDevice, collisionBox.Width, collisionBox.Height);
            Color[] data = new Color[collisionBox.Width * collisionBox.Height];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.Red;
            }

            myTexture.SetData(data);

        }





        public override void Draw(GameTime gameTime)
        {


            GameInfo.spriteBatch.Draw(myTexture, collisionBox, Color.Red);


        }
        public override void Update(GameTime gameTime)
        {



        }



    }
}
