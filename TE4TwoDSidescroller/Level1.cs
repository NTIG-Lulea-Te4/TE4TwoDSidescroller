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
            Entity farmer;


            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            farmer = new Farmer(700, 620);
            GameInfo.entityManager.AddEntity(farmer);

        }

        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();


        }

    }
}
