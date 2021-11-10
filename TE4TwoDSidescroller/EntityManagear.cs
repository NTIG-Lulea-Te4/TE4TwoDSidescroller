using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class EntityManagear
    {

        
        static Entity firstEntity;
        static Entity lastEntity;
        public static int uniqeCounter;


        public EntityManagear()
        {
            firstEntity = null;
            lastEntity = null;
            uniqeCounter = 0;

        }

        public static void AddEntity(Entity addEntity)
        {

            uniqeCounter++;
            addEntity.uniqeId = uniqeCounter;


            if (firstEntity != null)
            {

                lastEntity.nextEntity = addEntity;

            }
            else
            {
                firstEntity = addEntity;
            }

            lastEntity = addEntity;

        }

        public static Entity ChoseEntity(int uniqeId)
        {
            Entity tempEntity = firstEntity;
            while (tempEntity != null)
            {

                if (tempEntity.uniqeId == uniqeId)
                {
                    return tempEntity;
                }

                tempEntity = tempEntity.nextEntity;
            }

            return null;
        }

        public static bool RemoveEntity(int id)
        {

            Entity stepEntity = firstEntity;
            if (firstEntity.uniqeId == id)
            {

                firstEntity = firstEntity.nextEntity;
                return true;

            }
            else
            {

                while (stepEntity.nextEntity != null || stepEntity.nextEntity.uniqeId != id)
                {

                    stepEntity = stepEntity.nextEntity;

                }

                if (stepEntity.nextEntity.uniqeId == id)
                {

                    stepEntity.nextEntity = stepEntity.nextEntity.nextEntity;
                    return true;

                }

            }
            return false;

        }

        
       

        public static void Update(GameTime gameTime)
        {
            //gå igenom varje objekt och kör update på det
            Entity tempEntity = firstEntity;
            while (tempEntity != null)
            {

                tempEntity.Update(gameTime);
                tempEntity = tempEntity.nextEntity;

            }

        }

        public static void Draw(GameTime gameTime)
        {
            //gå igenom varje objekt och kör update på det
            Entity tempEntity = firstEntity;
            while (tempEntity != null)
            {

                tempEntity.Draw(gameTime);
                tempEntity = tempEntity.nextEntity;

            }
        }
    }
}
