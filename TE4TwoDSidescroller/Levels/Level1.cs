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
            Entity camera;

            Entity Farmer;
            Entity levelGoal;

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            camera = new VisionManager();
            GameInfo.entityManager.AddEntity(camera);

            Entity knight = new Knight();
            GameInfo.entityManager.AddEntity(knight);

            Farmer = new Farmer(500, 610);
            GameInfo.entityManager.AddEntity(Farmer);

            levelGoal = new LevelGoals(1);
            GameInfo.entityManager.AddEntity(levelGoal);
        }

        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();


        }

    }
}
