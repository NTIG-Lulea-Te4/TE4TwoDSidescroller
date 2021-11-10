using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    public class Entity
    {

        //man bör göra getseters för uniqeId och isActive
        public Entity nextEntity;
        public int uniqeId;
        public bool isActive;



        public Entity()
        {

            nextEntity = null;

            isActive = false;

        }

        //update och draw
        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime)
        {

        }
    }
}
