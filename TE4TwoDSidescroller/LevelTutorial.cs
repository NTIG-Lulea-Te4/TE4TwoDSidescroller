using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TE4TwoDSidescroller
{
    class LevelTutorial : Entity
    {

        Entity background;
        Entity playerEntity;
        Entity knight;
        Entity playerTest;


        public LevelTutorial()
        {
            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);
            GameInfo.player1Position = playerEntity.position;

            knight = new Knight();
            GameInfo.entityManager.AddEntity(knight);

            playerTest = new PlayerTest();
            GameInfo.entityManager.AddEntity(playerTest);


        }



        public override void Draw(GameTime gameTime)
        {

            

        }

        public override void Update(GameTime gameTime)
        {

            

        }
    }
}
