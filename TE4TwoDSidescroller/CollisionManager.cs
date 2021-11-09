using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TE4TwoDSidescroller
{
    class CollisionManager
    {
        public static bool CollisionRectangleCheck(Rectangle firstTargetToCheck, Rectangle secondTargetToCheck)
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
    }
}
