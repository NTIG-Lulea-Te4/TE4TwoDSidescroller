using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Level2
    {

        public Level2()
        {


        }

        public static void LoadContent()
        {

            Entity background;
            Entity playerEntity;
            Entity floor;
            Entity camera;

            Entity levelGoal;

            Entity farmerOne;
            Entity farmerTwo;
            Entity platform;

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            camera = new VisionManager();
            GameInfo.entityManager.AddEntity(camera);

            farmerOne = new Farmer(500, 610);
            GameInfo.entityManager.AddEntity(farmerOne);

            platform = new Platform(new Microsoft.Xna.Framework.Vector2(400, 350), 100, 40);
            GameInfo.entityManager.AddEntity(platform);

            farmerTwo = new Farmer(400, 250);
            GameInfo.entityManager.AddEntity(farmerTwo);

            levelGoal = new LevelGoals(2);
            GameInfo.entityManager.AddEntity(levelGoal);

        }
        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();


        }

    }
}
