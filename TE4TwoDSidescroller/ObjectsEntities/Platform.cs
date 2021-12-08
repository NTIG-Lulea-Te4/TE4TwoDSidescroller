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
    class Platform : Entity
    {
        Texture2D myTexture;
        Vector2 floorPosition;

        public Platform()
        {

            LevelTutorial.LoadContent();

            floorPosition = new Vector2(0, 700);
            collisionBox = new Rectangle((int)floorPosition.X, (int)floorPosition.Y, 1280, 20);
            myTexture = new Texture2D
                (GameInfo.graphicsDevice.GraphicsDevice, collisionBox.Width, collisionBox.Height);
            Color[] data = new Color[collisionBox.Width * collisionBox.Height];
            for (int i = 0; i < data.Length; i++)
            {
                if (i < data.Length / 3)
                {

                    data[i] = Color.OrangeRed;

                }

                if (i > data.Length / 3)
                {

                    data[i] = Color.Black;

                }

            }

            myTexture.SetData(data);

        }

    }
}
