﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class LevelBoss
    {

        public LevelBoss()
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
            Entity boss;

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            camera = new VisionManager();
            GameInfo.entityManager.AddEntity(camera);

            levelGoal = new LevelGoals(5);
            GameInfo.entityManager.AddEntity(levelGoal);

            boss = new Boss();
            GameInfo.entityManager.AddEntity(boss);

            menu = new HealthBar();
            GameInfo.entityManager.AddEntity(menu);

        }


        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();

        }
    }
}
