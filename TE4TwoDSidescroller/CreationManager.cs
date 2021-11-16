using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace TE4TwoDSidescroller
{
    public class CreationManager
    {
        GameTime spawnTimer;
        Floor floor;
        Player player;

        public CreationManager()
        {

            floor = new Floor();
            player = new Player();

        }

        public void Initialize()
        {
            floor.Initialize();
            player.Initialize();


        }

        public void CreationCycle()
        {

            GameInfo.entityManager.AddEntity(floor);
            GameInfo.entityManager.AddEntity(player);

        }


        //säger när allt ska skapas, intialize, skaffa tillgång till bilden?, 
    }
}
