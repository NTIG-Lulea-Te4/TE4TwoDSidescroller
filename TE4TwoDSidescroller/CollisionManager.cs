using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{

    //if (Rectangle.Intersect(firstTargetToCheck.rectangle, tempEntity.rectangle);)
    //{

    //}


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

        public void PlayerCollisionWithEnemy(Entity firstCollision, Entity secondCollision)
        {

            //CollisionCheck
            if (CollisionRectangleCheck(firstCollision.rectangle, secondCollision.rectangle))
            {

                //Skicka tillbaks info som säger att objekt har kråkat

                firstCollision.HasCollidedWith(secondCollision);
                secondCollision.HasCollidedWith(firstCollision);


            }


        }


    }


    //public void ReturnCollidedObjects()
    //{
    //    Entity entityStepper = GameInfo.entityManager.firstEntity;
    //    Entity firstTempEntity = GameInfo.entityManager.firstEntity;
    //    Entity secondTempEntity = GameInfo.entityManager.firstEntity;
    //    bool firstFlag = false;
    //    bool secondFlag = false;

    //    while (entityStepper != null)
    //    {
    //        //måse fixa ett sätt vart entitystepper inte sparas i samma temps
    //        if (entityStepper.isActive)
    //        {
    //            firstTempEntity = entityStepper;
    //            firstFlag = true;
    //        }

    //        if (entityStepper.isActive && firstTempEntity != null)
    //        {
    //            secondTempEntity = entityStepper;
    //            secondFlag = true;
    //        }

    //        if (firstFlag && secondFlag)
    //        {

    //            CollisionRectangleCheck(firstTempEntity.rectangle, secondTempEntity.rectangle);

    //            //Skickatillbaks kollision info

    //            firstTempEntity = null;
    //            secondTempEntity = null;
    //            firstFlag = false;
    //            secondFlag = false;
    //        }

    //        entityStepper = entityStepper.nextEntity;
    //    }

    //    firstTempEntity = null;
    //    secondTempEntity = null;
    //}

    //Byt namn
}

