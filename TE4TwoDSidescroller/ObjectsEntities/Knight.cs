using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Knight : Character
    {
        #region Variables/Fields
        GameInformationSystem gameInfoSystem;

        private Texture2D knightWalk;

        public static Rectangle sourceRectangle;

        //public  Vector2 knightPosition;
        private Vector2 knightOrigin;
        private Vector2 knightVelocity;
        private Vector2 knightScale;
        private float knightRotation;
        private float knightJumpHeight;
        private Vector2 trackingDistance;

        private Health health;

        public static bool knightIsFacingRight;
        bool isWalkingRight;
        bool hasTakenDamage;
        bool isAttacking;

        public static int knightDamage;

        #region Animations
        Animation tempWalkRight;
        Animation tempWalkLeft;
        Animation tempIdle;
        Animation tempJump;
        Animation tempFlipJump;
        Animation tempOuch;
        Animation tempFlipOuch;
        Animation tempAttack;
        Animation tempFlipAttack;
        #endregion

        #endregion

        public Knight()
        {
            characterInput = new KnightBehaviour(this);

            tag = Tags.Knight.ToString();

            IsGrounded = false;
            isActive = true;
            hasCollider = true;
            knightIsFacingRight = true;

            movementSpeed = 0.3f;
            maxHealth = 1000;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            health = new Health();

            gameInfoSystem = new GameInformationSystem();

            sourceRectangle = new Rectangle(0, 0, 64, 96);
            position = new Vector2(500, 500);
            movementDirection = new Vector2();
            knightVelocity = new Vector2(0, 0);

            knightOrigin = new Vector2(0, 0);
            knightScale = new Vector2(1, 1);
            movementVector = new Vector2(0, 0);
            knightRotation = 0;
            trackingDistance = new Vector2(300, 300);

            collisionBox = new Rectangle(0, 0, 64, 96);

            KnightDictionary();
            KnightAnimation();

            colorData = new Color[knightWalk.Width * knightWalk.Height];
            knightWalk.GetData(colorData);

            knightDamage = 5;

        }

        private void KnightDictionary()
        {
            animationManager.animations.TryGetValue("kngihtIdle", out tempIdle);
            animationManager.animations.TryGetValue("knightJump", out tempJump);
            animationManager.animations.TryGetValue("knightFlipJump", out tempFlipJump);
            animationManager.animations.TryGetValue("knightOuch", out tempOuch);
            animationManager.animations.TryGetValue("knightFlipOuch", out tempFlipOuch);
            animationManager.animations.TryGetValue("knightAttack", out tempAttack);
            animationManager.animations.TryGetValue("knightFlipAttack", out tempFlipAttack);
            animationManager.animations.TryGetValue("knightWalkRight", out tempWalkRight);
            animationManager.animations.TryGetValue("knightWalkLeft", out tempWalkLeft);
        }


        public void KnightAnimation()
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

            else if (isAttacking && position.X <= GameInfo.player1Position.X)
            {
                animationManager.animation = tempAttack;
                isAttacking = false;
            }

            else if (isAttacking && position.X >= GameInfo.player1Position.X)
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

            else if (!IsGrounded && (movementVector.Y != 0 && movementVector.X >= 0))
            {
                animationManager.animation = tempJump;
            }

            else if (!IsGrounded && (movementVector.Y != 0 && movementVector.X <= 0))
            {
                animationManager.animation = tempFlipJump;
            }

            else if (IsGrounded && movementVector.Y == 0 && movementVector.X == 0)
            {
                animationManager.animation = tempIdle;
            }

        }

        public override void HasCollidedWith(Entity collider)
        {

            if (collider.tag == Tags.Floor.ToString())
            {
                IsGrounded = true;

            }

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

        #region Behaviour

        public override void MoveRight()
        {
            movementVector.X += movementSpeed;
            knightIsFacingRight = true;


            isWalkingRight = true;

        }

        public override void MoveLeft()
        {
            movementVector.X -= movementSpeed;
            knightIsFacingRight = false;


            isWalkingRight = false;

        }

        //public override void Jump(GameTime gameTime)
        //{
        //    if (IsGrounded)
        //    {
        //        IsGrounded = false;
        //        movementVector.Y -= movementSpeed * 50;
        //    }
        //}


        public override void Attack1()
        {
            Entity knightAttack = new KnightAttack(this);
            GameInfo.entityManager.AddEntity(knightAttack);
            isAttacking = true;
        }

        #endregion

        public override void Update(GameTime gameTime)
        {
            #region Controls for testing
            //if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //{
            //    knightPosition.X -= movementSpeed;
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //{
            //    knightPosition.X += movementSpeed;
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //{
            //    knightPosition.Y += movementSpeed;
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    knightPosition.Y -= movementSpeed;
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
            //{
            //    knightPosition.Y = 0;
            //    knightPosition.X = 0;

            //}
            #endregion


            movementDirection = GameInfo.player1Position - position;

            knightVelocity = new Vector2(0, 0);
            position += movementVector;

            KnightAnimation();

            animationManager.animation.position = position;

            base.Update(gameTime);

            if (!IsGrounded)
            {
                increasingGravity += gameInfoSystem.gravity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            knightVelocity.Y += increasingGravity - knightJumpHeight;

            movementVector += knightVelocity;

            collisionBox.X = (int)position.X;
            collisionBox.Y = (int)position.Y;


        }

        public override void Draw(GameTime gameTime)
        {

            //GameInfo.spriteBatch.Draw(knightTexture, knightPosition, sourceRectangle,
            //    Color.White, knightRotation, knightOrigin, knightScale,
            //    SpriteEffects.None, 0f);

            animationManager.animation.Draw(gameTime);

            // base.Draw(gameTime);
        }

    }
}