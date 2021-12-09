using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Level3
    {

        public Level3()
        {



        }

        public static void LoadContent()
        {

            Entity background;
            Entity playerEntity;
            Entity floor;
            Entity camera;

            Entity levelGoal;

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            camera = new VisionManager();
            GameInfo.entityManager.AddEntity(camera);

            levelGoal = new LevelGoals(3);
            GameInfo.entityManager.AddEntity(levelGoal);
        }

        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();


        }

    }
}
