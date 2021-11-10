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
                && firstTargetToCheck.X < secondTargetToCheck.X + secondTargetToCheck.Width
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

        public void GoThrughAllEntitiesWithCollision(Rectangle playerHitbox)
        {
            

        }


    }
}
