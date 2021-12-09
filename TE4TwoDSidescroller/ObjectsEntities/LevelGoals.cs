using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller.ObjectsEntities
{
    class LevelGoals : Entity
    {
        protected bool levelFinished;
        public LevelGoals()
        {



        }

        public override void HasCollidedWith(Entity collider)
        {
            if (collider.tag == Tags.Player.ToString())
            {
                levelFinished = true;
            }
            else
            {
                levelFinished = false;
            }
        }


        public override void Update(GameTime gameTime)
        {


            if (levelFinished == true)
            {
                LevelTutorial.RemoveContent();
                Level1.LoadContent();
            }

        }
    }
}
