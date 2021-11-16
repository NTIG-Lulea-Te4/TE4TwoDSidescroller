using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace TE4TwoDSidescroller
{
    public class Game1 : Game
    {
            
        Rectangle testRectangle;
        Rectangle testRectangle2;
        MouseState mouseState;
        bool testBool;
        public Game1()
        {
            testRectangle = new Rectangle(0, 0, 5, 5);
            testRectangle2 = new Rectangle(0, 0, 500, 500);
            mouseState = new MouseState();

            GameInfo.graphicsDevice = new GraphicsDeviceManager(this);
            GameInfo.collisionManager = new CollisionManager();
            GameInfo.entityManager = new EntityManagear();
            GameInfo.collisionManager = new CollisionManager();
            GameInfo.creationManager = new CreationManager();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

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

            testRectangle.Location = mouseState.Position;

            if (GameInfo.collisionManager.CollisionRectangleCheck(testRectangle, testRectangle2))
            {
                GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.Red);
            }

            // TODO: Add your update logic here

            GameInfo.entityManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);

            GameInfo.spriteBatch.Begin();

            GameInfo.entityManager.Draw(gameTime);

            GameInfo.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
