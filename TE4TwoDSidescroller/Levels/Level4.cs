﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
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

            Entity platform;
            Entity platformTwo;
            Entity platformThree;
            Entity platformFour;
            Entity platformFive;
            Entity platformSix;
            Entity platformSeven;
            Entity platformEight;

            Entity levelGoal;


            Entity knight;

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

            platform = new Platform(new Vector2(400, 350), 200, 40);
            GameInfo.entityManager.AddEntity(platform);

            platformTwo = new Platform(new Vector2(800, 550), 400, 40);
            GameInfo.entityManager.AddEntity(platformTwo);

            platformThree = new Platform(new Vector2(1350, 500), 200, 40);
            GameInfo.entityManager.AddEntity(platformThree);

            platformFour = new Platform(new Vector2(1800, 300), 200, 40);
            GameInfo.entityManager.AddEntity(platformFour);

            platformFive = new Platform(new Vector2(2400, 100), 20, 600);
            GameInfo.entityManager.AddEntity(platformFive);

            platformSix = new Platform(new Vector2(2400, 200), 350, 40);
            GameInfo.entityManager.AddEntity(platformSix);

            platformSeven = new Platform(new Vector2(2800, 550), 800, 30);
            GameInfo.entityManager.AddEntity(platformSeven);

            platformEight = new Platform(new Vector2(3600, 350), 400, 30);
            GameInfo.entityManager.AddEntity(platformEight);

            levelGoal = new LevelGoals(4);
            GameInfo.entityManager.AddEntity(levelGoal);

            knight = new Knight(500, 500);
            GameInfo.entityManager.AddEntity(knight);

        }

        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();

        }
    }
}
