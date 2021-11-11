using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    public class CollisionManager
    {
        public bool CollisionRectangleCheck(Rectangle firstTargetToCheck, Rectangle secondTargetToCheck)
        {

            if (firstTargetToCheck.Width + firstTargetToCheck.X >= secondTargetToCheck.X
                && firstTargetToCheck.Height + firstTargetToCheck.Y >= secondTargetToCheck.Y
                || firstTargetToCheck.X < secondTargetToCheck.X + secondTargetToCheck.Width
                && firstTargetToCheck.Y < secondTargetToCheck.Y + secondTargetToCheck.Height)
            {

                return true;

            }
            else
            {
                return false;

            }
        }

        public void ReturnCollidedObjects()
        {
            Entity entityStepper = GameInfo.entityManager.firstEntity;
            Entity firstTempEntity = GameInfo.entityManager.firstEntity;
            Entity secondTempEntity = GameInfo.entityManager.firstEntity;
            bool firstFlag = false;
            bool secondFlag = false;

            while (entityStepper != null)
            {
                //måse fixa ett sätt vart entitystepper inte sparas i samma temps
                if (entityStepper.isActive)
                {
                    firstTempEntity = entityStepper;
                    firstFlag = true;
                }

                if (entityStepper.isActive && firstTempEntity != null)
                {
                    secondTempEntity = entityStepper;
                    secondFlag = true;
                }

                if (firstFlag && secondFlag)
                {
                    //Skickatillbaks kollision info

                    firstTempEntity = null;
                    secondTempEntity = null;
                    firstFlag = false;
                    secondFlag = false;
                }

                entityStepper = entityStepper.nextEntity;
            }

            firstTempEntity = null;
            secondTempEntity = null;
        }

        public Entity PlayerCollisionWithEnemy(Entity player)
        {

            Entity tempEntity = GameInfo.entityManager.firstEntity;

            while (tempEntity != null)
            {
                if (tempEntity.isActive && tempEntity != player)
                {
                    //CollisionCheck
                    if (CollisionRectangleCheck(player.rectangle, tempEntity.rectangle))
                    {
                        //Skicka tillbaks info som säger att objekt har kråkat
                        return tempEntity;
                    }

                    return null;
                }
                
                tempEntity = tempEntity.nextEntity;
            }

            return null; 
        }


    }
}
