using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{

//if (firstTargetToCheck.Width + firstTargetToCheck.Height > secondTargetToCheck.X
//    && firstTargetToCheck.Width + firstTargetToCheck.Height > secondTargetToCheck.Y
//    && firstTargetToCheck.X < secondTargetToCheck.Width + secondTargetToCheck.Height
//    && firstTargetToCheck.Y < secondTargetToCheck.Width + secondTargetToCheck.Height)
//{
//
//
//}

public class CollisionManager
{
    public bool CollisionRectangleCheck(Rectangle firstTargetToCheck, Rectangle secondTargetToCheck)
    {

        if (firstTargetToCheck.Width + firstTargetToCheck.Height > secondTargetToCheck.X
            && firstTargetToCheck.Width + firstTargetToCheck.Height > secondTargetToCheck.Y
            && firstTargetToCheck.X < secondTargetToCheck.Width + secondTargetToCheck.Height
            && firstTargetToCheck.Y < secondTargetToCheck.Width + secondTargetToCheck.Height)
        {

            return true;

        }
        else
        {
            return false;

        }


    }

    public void Collision(Entity firstCollision, Entity secondCollision)
    {

        //CollisionCheck
        if (CollisionRectangleCheck(firstCollision.rectangle, secondCollision.rectangle))
        {

            //Skicka tillbaks info som säger att objekt har kråkat

            firstCollision.HasCollidedWith(secondCollision);
            secondCollision.HasCollidedWith(firstCollision);

        }


    }



    public void ReturnCollidedObjects()
    {
        Entity stepEntity = GameInfo.entityManager.firstEntity;
        Entity secondStepEntity = GameInfo.entityManager.firstEntity;
        //Entity tempEntity;

        while (stepEntity != null)
        {

            if (stepEntity.isActive)
            {

                if (stepEntity.hasCollider)
                {

                    while (secondStepEntity != null)
                    {
                        if (secondStepEntity.isActive)
                        {
                            if (secondStepEntity.hasCollider)
                            {
                                if (stepEntity != secondStepEntity)
                                {
                                    if (CollisionRectangleCheck(stepEntity.rectangle, secondStepEntity.rectangle))
                                    {
                                        stepEntity.HasCollidedWith(secondStepEntity);
                                        secondStepEntity.HasCollidedWith(stepEntity);
                                    }

                                }
                            }
                        }

                        secondStepEntity = secondStepEntity.nextEntity;

                    }

                }

            }

            stepEntity = stepEntity.nextEntity;
            secondStepEntity = GameInfo.entityManager.firstEntity;

        }

    }

}

}

