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
            Entity boss;


            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            Entity playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            TutorialGoal = new TutorialGoal();
            GameInfo.entityManager.AddEntity(TutorialGoal);

            boss = new Boss(1100, 600);
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
