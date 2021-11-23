using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    public class Entity
    {

        //man bör göra getseters för uniqeId och isActive
        public Entity nextEntity;
        public int uniqeId;
        public bool isActive;
        public bool hasCollider;
        public bool isPlayer;

        protected int currentHealth;
        protected int manaCheck;
        protected int maxHealth;
        protected int manaTick;
        protected int mana;
        protected int movementSpeed;
        protected int jumpHeight;



        public float rotation;
        public float scale;
        public Vector2 position;

        public Rectangle rectangle;

        public Entity()
        {

            nextEntity = null;
            isActive = true;
            hasCollider = false;

        }

        //update och draw
        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime)
        {

        }

        public virtual void HasCollidedWith(Entity collider)
        {

        }
    }
}
