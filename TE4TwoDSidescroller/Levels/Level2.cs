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
            Entity farmer;
            Entity farmer2;

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            farmer = new Farmer(700, 640);
            GameInfo.entityManager.AddEntity(farmer);

            farmer2 = new Farmer(900, 640);
            GameInfo.entityManager.AddEntity(farmer2);

        }
        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();


        }

    }
}
