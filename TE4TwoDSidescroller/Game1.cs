using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace TE4TwoDSidescroller
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphicsDeviceManager;
        public Texture2D rightWalk;
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;
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
            destinationRectangle = new Rectangle(100, 100, 32, 46);
            // TODO: Add your initialization logic here


            floorTest.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            GameInfo.spriteBatch = new SpriteBatch(GameInfo.graphicsDevice.GraphicsDevice);

            string currentPath = Path.GetDirectoryName(
          System.Reflection.Assembly.GetExecutingAssembly().Location)
          + "/Content/Pngs/" + "ShadowRunRight.png";
            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                rightWalk = Texture2D.FromStream(GraphicsDevice, textureStream);
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            sourceRectangle = new Rectangle(0, 0, 32, 46);
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);
            GameInfo.entityManager.AddEntity(floorTest);

            GameInfo.spriteBatch.Begin();

            //GameInfo.entityManager.Draw(gameTime);

            floorTest.Draw(gameTime);
            
            GameInfo.spriteBatch.Draw(rightWalk, destinationRectangle, sourceRectangle, Color.White);
            GameInfo.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
