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
        public GameTime spawnTimer;

        public CreationManager()
        {



        }

        public void Initialize()
        {
            Entity tempEntity = new Player();
            GameInfo.entityManager.AddEntity(tempEntity);
           

        }

        public void CreationCycle()
        {



        }


        //säger när allt ska skapas, intialize, skaffa tillgång till bilden?, 
    }
}
