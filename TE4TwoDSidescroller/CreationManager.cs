﻿using System;
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



        }

        public void CreationCycle()
        {



        }

        public void StartLevel()
        {


            LevelTutorial.LoadContent();

            Level1.LoadContent();

            Level2.LoadContent();

            Level3.LoadContent();


        }

        //säger när allt ska skapas, intialize, skaffa tillgång till bilden?, 
    }
}
