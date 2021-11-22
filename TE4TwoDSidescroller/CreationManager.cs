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
        

        public CreationManager()
        {

            floor = new Floor();
            
        }

        public void Initialize()
        {
            floor.Initialize();
            GameInfo.entityManager.AddEntity(floor);
           


        }

        public void LoadEntities()
        {


        }


        //säger när allt ska skapas, intialize, skaffa tillgång till bilden?, 
    }
}
