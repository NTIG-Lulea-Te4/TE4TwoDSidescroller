using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TE4TwoDSidescroller
{
    class LevelTutorial : Entity
    {



        public LevelTutorial()
        {


        }


        public static void LoadContent()
        {
            Entity background;
            Entity floor;
            Entity TutorialGoal;
            Entity viewport;
            Entity farmer;

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            Entity playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            TutorialGoal = new TutorialGoal();
            GameInfo.entityManager.AddEntity(TutorialGoal);

            viewport = new VisionManager();
            GameInfo.entityManager.AddEntity(viewport);

            farmer = new Farmer(100, 220);
            GameInfo.entityManager.AddEntity(farmer);

        }

        public override void Update(GameTime gameTime)
        {


        }

        public override void Draw(GameTime gameTime)
        {
            


        }

        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();


        }

    }
}
