﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Health
    {

        public int Healing(int maxHealth, int currentHealth, int healingAmount)
        {

            currentHealth = currentHealth + healingAmount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            return currentHealth;
        }

        public int TakeDamage(int currentHEalth, int amountOfDamage, Entity deathToEntity)
        {
            currentHEalth = currentHEalth - amountOfDamage;

            if (currentHEalth <= 0)
            {
                GameInfo.entityManager.RemoveEntity(deathToEntity.uniqeId);
            }


            return currentHEalth;
        }

    }
}
