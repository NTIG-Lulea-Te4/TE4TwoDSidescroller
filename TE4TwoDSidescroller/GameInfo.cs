using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{


    public static class GameInfo
    {
        static public Game1 game1;
        static public GraphicsDeviceManager graphicsDevice;

        static public void Initialize()
        {
            graphicsDevice = new GraphicsDeviceManager(game1);
            


        }
        
        static public GraphicsDeviceManager GraphicsManager()
        {

            return graphicsDevice;

        }
    }

}
