using System;
using System.Collections.Generic;
using System.Text;
using TE4TwoDSidescroller.Levels;

namespace TE4TwoDSidescroller
{
    class Level4
    {

        public Level4()
        {



        }

        public static void LoadContent()
        {

            Entity background;
            Entity playerEntity;
            Entity floor;
            Entity camera;

            Entity levelGoal;

            Entity deathZone = new DeathZone();
            GameInfo.entityManager.AddEntity(deathZone);

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            camera = new VisionManager();
            GameInfo.entityManager.AddEntity(camera);

            levelGoal = new LevelGoals(4);
            GameInfo.entityManager.AddEntity(levelGoal);


            Entity knight = new Knight(500, 500);
            GameInfo.entityManager.AddEntity(knight);


        }

        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();

        }
    }
}
