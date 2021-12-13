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
            Entity playerEntity;
            Entity floor;
            Entity camera;
            Entity tutorialGoal;
            HealthBar menu;

            Entity boss;


            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            camera = new VisionManager();
            GameInfo.entityManager.AddEntity(camera);

            tutorialGoal = new TutorialGoal();
            GameInfo.entityManager.AddEntity(tutorialGoal);

            menu = new HealthBar();
            GameInfo.entityManager.AddEntity(menu);

            boss = new Boss();
            GameInfo.entityManager.AddEntity(boss);



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
