﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Level4
    {

        public Level4()
        {



        }

        public static void LoadContent()
        {
            HealthBar menu;
            Entity background;
            Entity playerEntity;
            Entity floor;
            Entity camera;

            Entity levelGoal;
            Entity knight;

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

            knight = new Knight();
            GameInfo.entityManager.AddEntity(knight);

            menu = new HealthBar();
            GameInfo.entityManager.AddEntity(menu);

        }

        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();

        }
    }
}
