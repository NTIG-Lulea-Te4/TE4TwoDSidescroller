using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace TE4TwoDSidescroller
{
    public class Game1 : Game
    {
        SoundInput soundInput;
        public Game1()
        {
           // soundInput = new SoundInput();
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

            GameInfo.creationManager.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            

            GameInfo.spriteBatch = new SpriteBatch(GameInfo.graphicsDevice.GraphicsDevice);
            GameInfo.creationManager.Initialize();

        }

        protected override void Update(GameTime gameTime)
        {
            //soundInput.PlaySound();
            GameInfo.entityManager.Update(gameTime);

            GameInfo.collisionManager.CollisionUpdate();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

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
