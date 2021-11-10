using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Character : Entity
    {
        protected bool ifHit;
        protected int health;
        protected int speed;
        Character()
        {
            
        }

        protected void Health()
        {

        }

        protected void Mana(int mana)
        {
            mana = 100;

        //    if (/*ability use or button press*/)
        //    {
        //        mana = mana - 20;
        //    }
        }

        protected void Speed()
        {
            speed = 1;
        }

        protected void Invincibility(int tmpValue)
        {
            tmpValue = health;

            //if (health <= )
            //{

            //}
        }

        protected void Sprint(int stamina)
        {
            stamina = 100;

            //while (/*key hold*/)
            //{
            //    stamina -= 1;

            //    while (speed < 3)
            //    {
            //        speed = speed + 2;
            //    }
            //}

            speed = 1;
        }
    }
}
