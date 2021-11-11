using System;
using System.Collections.Generic;
using System.Drawing;
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


        public void CheckCollisionWithThisObject()
        {



        }

        public void GoThrughAllEntitiesWithCollision(Entity player)
        {

            Entity tempEntity = GameInfo.entityManager.firstEntity;

            while (tempEntity != null)
            {
                if (tempEntity.isActive && tempEntity != player)
                {
                    //CollisionCheck
                    if (tempEntity.rectangle.Width + tempEntity.rectangle.X >= player.rectangle.X
                    && tempEntity.rectangle.Height + tempEntity.rectangle.Y >= player.rectangle.Y
                    || tempEntity.rectangle.X < player.rectangle.X + player.rectangle.Width
                    && tempEntity.rectangle.Y < player.rectangle.Y + player.rectangle.Height)
                    {

                    }

                }

                tempEntity = tempEntity.nextEntity;
            }

        }


    }
}
