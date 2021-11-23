using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{


    public static class GameInfo
    {
        
        static public Game1 game1;
        static public GraphicsDeviceManager graphicsDevice;
        static public SpriteBatch spriteBatch;
        static public CollisionManager collisionManager;
        static public EntityManagear entityManager;
        static public ScreenManager screenManager;
        static public CreationManager creationManager;
        static public GameInformationSystem gameInformationSystem; 

        #region kommentar
        /*        static public void Initialize()
                {
                    graphicsDevice = new GraphicsDeviceManager(game1);


                }

                static public GraphicsDeviceManager GraphicsManager()
                {

                    return graphicsDevice;

                }

                static public EntityManagear EntityManager()
                {
                    object entityManager;
                    entityManager = new EntityManagear();

                    return (EntityManagear)entityManager;

                }

                public static CollisionManager CollisionManager()
                {
                    object collisionManager;
                    collisionManager = new CollisionManager();

                    return (CollisionManager)collisionManager;

                }

        */
        #endregion
    }

}
