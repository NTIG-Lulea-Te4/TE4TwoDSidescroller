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
            Entity platform;

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            camera = new VisionManager();
            GameInfo.entityManager.AddEntity(camera);

            platform = new Platform(new Microsoft.Xna.Framework.Vector2(300, 450), 300, 40);
            GameInfo.entityManager.AddEntity(platform);

            levelGoal = new LevelGoals(3);
            GameInfo.entityManager.AddEntity(levelGoal);
        }

        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();


        }

    }
}
