using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace TE4TwoDSidescroller
{
    public class Game1 : Game
    {
        bool isDrawing;
        
        public Game1()
        {
            
            GameInfo.graphicsDevice = new GraphicsDeviceManager(this);
            GameInfo.collisionManager = new CollisionManager();
            GameInfo.entityManager = new EntityManagear();
            GameInfo.collisionManager = new CollisionManager();
            GameInfo.creationManager = new CreationManager();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            isDrawing = true;
        }

        protected override void Initialize()
        {

        

            // TODO: Add your initialization logic here




            base.Initialize();
        }

        protected override void LoadContent()
        {


            GameInfo.spriteBatch = new SpriteBatch(GameInfo.graphicsDevice.GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            // TODO: Add your update logic here

            GameInfo.entityManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);

            GameInfo.spriteBatch.Begin();

            if (isDrawing)
            {
                 GameInfo.entityManager.Draw(gameTime);
                 
            }

            

            GameInfo.spriteBatch.End();

           
            base.Draw(gameTime);
        }
    }
}
