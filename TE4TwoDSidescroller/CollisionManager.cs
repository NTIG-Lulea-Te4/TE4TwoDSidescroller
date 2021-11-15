using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{

    //if (Rectangle.Intersect(firstTargetToCheck.rectangle, tempEntity.rectangle);)
    //{

    //}


    //if (firstTargetToCheck.Width + firstTargetToCheck.X >= secondTargetToCheck.X
    //  && firstTargetToCheck.Height + firstTargetToCheck.Y >= secondTargetToCheck.Y
    //  || firstTargetToCheck.X < secondTargetToCheck.X + secondTargetToCheck.Width
    //  && firstTargetToCheck.Y < secondTargetToCheck.Y + secondTargetToCheck.Height)
    //{

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
            Entity tempEntity;


            while (stepEntity != null)
            {




            }

        }

    }

}

