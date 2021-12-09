﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller.Levels
{
    class Level4
    {

        public Level4()
        {



        }

        public void LoadContent()
        {

            Entity background;
            Entity playerEntity;
            Entity floor;
            Entity camera;

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            camera = new VisionManager();
            GameInfo.entityManager.AddEntity(camera);

        }

        public void RemoveContent()
        {



        }
    }
}
