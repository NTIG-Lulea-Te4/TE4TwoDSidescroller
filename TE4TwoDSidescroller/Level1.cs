using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Level1
    {

        public Level1()
        {


        }


        public static void LoadContent()
        {

            Entity background;
            Entity playerEntity;
            Entity floor;
            Entity tutorialGoal;
            Entity camera;

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            tutorialGoal = new TutorialGoal();
            GameInfo.entityManager.AddEntity(tutorialGoal);

            camera = new VisionManager();
            GameInfo.entityManager.AddEntity(camera);
        }

        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();


        }

    }
}
