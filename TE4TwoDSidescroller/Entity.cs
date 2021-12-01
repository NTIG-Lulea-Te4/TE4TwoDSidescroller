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

        public EntityAnimation entityAnimation;

        public int uniqeId;
        public bool isActive;
        public bool hasCollider;
        public bool isPlayer;
        private bool isGrounded;
        public bool isFloor;

        public float increasingGravity;
        public float amplifiedYForce;

        protected int currentHealth;
        protected int manaCheck;
        protected int maxHealth;
        protected int manaTick;
        protected int mana;
        protected float movementSpeed;
        protected int jumpHeight;


        public float rotation;
        public float scale;
        public Vector2 position;


        public Color[] colorData;
        public Rectangle collisionBox;
        public Vector2 movementVector;


        public Entity()
        {
            increasingGravity = 0;
            nextEntity = null;
            isActive = true;
            hasCollider = false;
            //isGrounded = false;  //Can have it On incase we want that every Entity falls down unless it's grounded.

        }

        public bool IsGrounded
        {
            get
            {
                return isGrounded;
            }
            set
            {
                isGrounded = value;
                if (isGrounded)
                {
                    increasingGravity = 0;
                }
            }
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
