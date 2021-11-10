using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace TE4TwoDSidescroller
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphicsDeviceManager;
        public static Game1 myGame;
        public Texture2D rightWalk;

        public Game1()
        {
            GameInfo.graphicsDevice = new GraphicsDeviceManager(this);
            GameInfo.collisionManager = new CollisionManager();
            GameInfo.entityManager = new EntityManagear();
            GameInfo.collisionManager = new CollisionManager();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected static void Initialize(Game1 game1)
        {
            graphicsDeviceManager = new GraphicsDeviceManager(game1);
            myGame = game1;
            // TODO: Add your initialization logic here
        }

        protected override void LoadContent()
        {
            GameInfo.spriteBatch = new SpriteBatch(GraphicsDevice);

            string currentPath = Path.GetDirectoryName(
          System.Reflection.Assembly.GetExecutingAssembly().Location)
          + "/Content/Pngs/" + "ShadowRunRight.png";
            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                rightWalk = Texture2D.FromStream(myGame.GraphicsDevice, textureStream);
            }

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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GameInfo.spriteBatch.Begin();

            GameInfo.spriteBatch.Draw(rightWalk, new Rectangle(100, 100, 32, 26), new Rectangle(0, 0, 32, 26), Color.White);

            GameInfo.spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
