using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Farmer : Character
    {
        #region Variables/Fields
        Health health;
        Texture2D farmerIdle;
        Texture2D farmerAttack;
        Texture2D farmerWalk;
        Texture2D farmerOuch;
        Vector2 myPosition;
        Rectangle sourceRectangle;
        bool hasTakenDamage;
        bool isAttacking;

        public static int farmerDamage;

        #region Animations
        Animation tempIdle;
        Animation tempWalkRight;
        Animation tempWalkLeft;
        Animation tempOuch;
        Animation tempFlipOuch;
        Animation tempAttack;
        Animation tempFlipAttack;
        #endregion

        #endregion

        public Farmer(int myPosition1, int myPosition2)
        {
            characterInput = new FarmerInput(this);
            maxHealth = 50;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            movementSpeed = 2;
            jumpHeight = 3;

            hasCollider = true;
            isActive = true;

            myPosition = new Vector2(myPosition1, myPosition2);

            sourceRectangle = new Rectangle(0, 0, 64, 96);
            myPosition = new Vector2(myPosition1, myPosition2);
            
            collisionBox = new Rectangle((int)myPosition.X, (int)myPosition.Y, 64, 96);
            health = new Health();

            FarmerDictionary();

            FarmerAnimation();
        }

        private void FarmerDictionary()
        {
            animationManager.animations.TryGetValue("farmerIdle", out tempIdle);
            animationManager.animations.TryGetValue("farmerOuch", out tempOuch);
            animationManager.animations.TryGetValue("farmerFlipOuch", out tempFlipOuch);
            animationManager.animations.TryGetValue("farmerAttack", out tempAttack);
            animationManager.animations.TryGetValue("farmerFlipAttack", out tempFlipAttack);
            animationManager.animations.TryGetValue("farmerWalkRight", out tempWalkRight);
            animationManager.animations.TryGetValue("farmerWalkLeft", out tempWalkLeft);
        }

        public void FarmerAnimation()
        {

            if (hasTakenDamage && movementVector.X >= 0)
            {
                animationManager.animation = tempOuch;
                hasTakenDamage = false;
            }

            else if (hasTakenDamage && movementVector.X <= 0)
            {
                animationManager.animation = tempFlipOuch;
                hasTakenDamage = false;
            }

            else if (isAttacking && myPosition.X <= GameInfo.player1Position.X)
            {
                animationManager.animation = tempAttack;
                isAttacking = false;
            }

            else if (isAttacking && myPosition.X >= GameInfo.player1Position.X)
            {
                animationManager.animation = tempFlipAttack;
                isAttacking = false;
            }

            else if (movementVector.Y == 0 && movementVector.X >= 0)
            {
                animationManager.animation = tempWalkRight;
            }

            else if (movementVector.Y == 0 && movementVector.X <= 0)
            {
                animationManager.animation = tempWalkLeft;
            }

            else if (IsGrounded && movementVector.Y == 0 && movementVector.X == 0)
            {
                animationManager.animation = tempIdle;
            }
        }

        public override void HasCollidedWith(Entity collider)
        {

            if (collider.tag == Tags.PlayerMeleeAttack.ToString())
            {
                hasTakenDamage = true;

                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

            if (collider.tag == Tags.PlayerRangeAttack.ToString())
            {
                hasTakenDamage = true;
                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

        }

        #region Actions

        public override void MoveRight()
        {

            myPosition.X += movementSpeed;

        }

        public override void MoveLeft()
        {

            myPosition.X -= movementSpeed;

        }

        public override void Attack1( )
        {



        }



        #endregion


        public override void Update(GameTime gameTime)
        {
            manaTick++;
            if (mana < manaCheck && manaTick == 15)
            {
                mana++;
                manaTick = 0;
            }

            myPosition += movementVector;
            FarmerAnimation();

            animationManager.animation.position = myPosition;

            position = myPosition;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //GameInfo.spriteBatch.Draw(farmerIdle, myPosition, sourceRectangle , Color.White);
            animationManager.animation.Draw(gameTime);
        }

    }
}
