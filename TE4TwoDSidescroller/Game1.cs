using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    public class Game1 : Game
    {
            Floor floorTest;

        public Game1()
        {
            floorTest = new Floor();
            GameInfo.graphicsDevice = new GraphicsDeviceManager(this);
            GameInfo.collisionManager = new CollisionManager();
            GameInfo.entityManager = new EntityManagear();
            GameInfo.collisionManager = new CollisionManager();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {


            floorTest.Initialize();
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
                Exit();
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);
            GameInfo.entityManager.AddEntity(floorTest);

            GameInfo.spriteBatch.Begin();

            GameInfo.entityManager.Draw(gameTime);

            GameInfo.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
