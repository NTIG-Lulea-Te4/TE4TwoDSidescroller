using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Camera
    {
        // pain in my asss
        Matrix camerafollow; 
        Vector2 position;

        public Matrix Camerafollow
        {
            get { return Camerafollow; }
        }

        public int ScreenWidth
        {
            get { return GraphicsDeviceManager.DefaultBackBufferWidth; }
        }

        public int ScreenHeight
        {
            get { return GraphicsDeviceManager.DefaultBackBufferHeight; }
        }

        public void ScreenFolow(Vector2 playerPosition)
        {
            position.X = playerPosition.X - (ScreenWidth/2);
            position.Y = playerPosition.Y - (ScreenHeight / 2);

            if (position.X < 0)
            {
                position.X = 0;
            }
            else if (position.Y < 0)
            {
                position.Y = 0;
            }

            camerafollow = Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}
