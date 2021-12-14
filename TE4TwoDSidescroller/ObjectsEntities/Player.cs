using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TE4TwoDSidescroller
{

    //:D
    class Player : Character
    {
        #region Variables/Fields
        public Texture2D currentTexture;


        Health health;

        private Rectangle playerSourceRectangle;
        private Vector2 playerPosition;                                                                                                                                                                                                                                       
        private Vector2 playerVelocity;

        private Rectangle detectionHitBox;

        private Vector2 playerScale;
        private float playerRotation;
        private Vector2 playerOrigin;

        private float moveSpeed;
        private float runSpeed;
        private float walkSpeed;

        float deltaTime;
        float time;

        bool isWalkingRight;
        bool isWalkingLeft;
        bool isJumping;
        public bool isFacingRight;
        bool hasTakenDamage;

        public static int playerDamage;

        #endregion

        public Player()
        {

            tag = Tags.Player.ToString();
            characterInput = new PlayerInput(this);

            health = new Health();

            playerSourceRectangle = new Rectangle(0, 0, 67, 96); // 256 * 96 - 64/67

            playerVelocity = new Vector2(0, 0);
            movementVector = new Vector2(0, 0);

            playerScale = new Vector2(1, 1);
            playerRotation = 0;
            playerOrigin = new Vector2(0, 0);

            playerPosition = new Vector2(0, 0);

            moveSpeed = 2;
            walkSpeed = 2;
            runSpeed = 4;

            IsGrounded = false;
            hasCollider = true;
            isActive = true;
            isFacingRight = true;

            collisionBox = new Rectangle(0, 0, playerSourceRectangle.Width, playerSourceRectangle.Height);

            Animate();

            maxHealth = 1000;
            currentHealth = maxHealth;
            
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            playerDamage = 10;

        }


        public void Animate()
        {
            Animation tempBase;
            Animation tempRunRight;
            Animation tempRunLeft;
            Animation tempIdle;
            Animation tempFlipIdle;
            Animation tempJump;
            Animation tempFlipJump;
            Animation tempOuch;
            Animation tempFlipOuch;

            animationManager.animations.TryGetValue("playerBase", out tempBase);
            animationManager.animations.TryGetValue("playerIdle", out tempIdle);
            animationManager.animations.TryGetValue("playerFlipIdle", out tempFlipIdle);
            animationManager.animations.TryGetValue("playerJump", out tempJump);
            animationManager.animations.TryGetValue("playerOuch", out tempOuch);
            animationManager.animations.TryGetValue("playerFlipOuch", out tempFlipOuch);
            animationManager.animations.TryGetValue("playerFlipJump", out tempFlipJump);
            animationManager.animations.TryGetValue("playerRunRight", out tempRunRight);
            animationManager.animations.TryGetValue("plyaerRunLeft", out tempRunLeft);

            //animation = tempBase;

            if (hasTakenDamage && movementVector.X >= 0 && isFacingRight)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animationManager.animation = tempOuch;
                hasTakenDamage = false;
            }

            else if (hasTakenDamage && movementVector.X <= 0 && !isFacingRight)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animationManager.animation = tempFlipOuch;
                hasTakenDamage = false;
            }

            else if (IsGrounded && movementVector.Y == 0 && movementVector.X == 0 && isWalkingRight)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animationManager.animation = tempIdle;

            }

            else if (IsGrounded && movementVector.Y == 0 && movementVector.X == 0 && !isWalkingRight)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animationManager.animation = tempFlipIdle;
            }

            else if (!IsGrounded && (movementVector.Y != 0 && movementVector.X >= 0))
            {
                tempFlipJump.frameIndex = 0;

                animationManager.animation = tempJump;

            }

            else if (!IsGrounded && (movementVector.Y != 0 && movementVector.X <= 0))
            {
                tempJump.frameIndex = 0;

                animationManager.animation = tempFlipJump;
            }

            else if (movementVector.Y == 0 && movementVector.X >= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animationManager.animation = tempRunRight;

            }

            else if (movementVector.Y == 0 && movementVector.X <= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animationManager.animation = tempRunLeft;

            }
        }

        public override void HasCollidedWith(Entity collider)
        {
            if (collider.tag == Tags.Floor.ToString())
            {
                IsGrounded = true;
            }

            if (collider.tag == Tags.KnightAttack.ToString())
            {
                currentHealth = health.TakeDamage(currentHealth, Knight.knightDamage, this);
                hasTakenDamage = true;
            }

            if (collider.tag == Tags.DeathZone.ToString())
            {

                currentHealth = health.TakeDamage(currentHealth, 9999, this);

            }

            if (collider.tag == Tags.PriestAttack.ToString())
            {
                currentHealth = health.TakeDamage(currentHealth, Priest.priestDamage, this);
                hasTakenDamage = true;
            }

        }

        #region Input

        public override void Reset()
        {
            playerPosition = new Vector2(200, 50);
            IsGrounded = false;
        }

        //public override void MoveUp()
        //{
        //    movementVector.Y -= moveSpeed;
        //    //Modife later to implant accelartion and friction. (acceleration - friction * movementVector.Y)
        //}

        //public override void MoveDown()
        //{
        //    movementVector.Y += moveSpeed;
        //}

        public override void MoveLeft()
        {
            movementVector.X -= moveSpeed;

            isWalkingRight = false;
            isFacingRight = false;
        }

        public override void MoveRight()
        {
            movementVector.X += moveSpeed;

            isWalkingRight = true;
            isFacingRight = true;
        }

        public override void Run()
        {
            moveSpeed = runSpeed;
        }

        public override void DoNotRun()
        {
            moveSpeed = walkSpeed;
        }

        public override void Jump(GameTime gameTime)
        {
            movementVector.Y -= moveSpeed + 1;
            IsGrounded = false;
        }

        public override void Attack1()
        {

            GameInfo.creationManager.InitializePlayerMeleeAttack();

        }

        public override void Attack2()
        {
            GameInfo.creationManager.InitializePlayerRangeAttack();
        }

        #endregion

        public override void Update(GameTime gameTime)
        {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            playerVelocity = new Vector2(0, 0);
            playerPosition += movementVector;

            Animate();

            animationManager.animation.position = playerPosition;

            GameInfo.player1Position = playerPosition;
            GameInfo.Player1TextureSize = playerSourceRectangle;
            GameInfo.player1IsFacingRight = isFacingRight;
            GameInfo.playerOneCurrentHealth = currentHealth;

            base.Update(gameTime);

            if (!IsGrounded)
            {
                increasingGravity += GameInfo.gameInformationSystem.gravity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            detectionHitBox.X = (int)playerPosition.X;
            detectionHitBox.Y = (int)playerPosition.Y;
            collisionBox.X = (int)playerPosition.X;
            collisionBox.Y = (int)playerPosition.Y;
            
            playerVelocity.Y += increasingGravity;
            movementVector += playerVelocity;

            

            #region Harry's Code
            manaTick++;
            if (mana < manaCheck && manaTick == 15)
            {
                mana++;
                manaTick = 0;
            }

            //gör en bool som checkar ifall du kan checka enemy collision
            //så när du blir skadad slår du av den för 0.5 sek

            //ifall fienders vapen overlappar med kroppen så ta skada
            /* if (true)
             {
                 character.TakeDamage(currentHEalth, 10);
             }*/

            #endregion
        }

        public override void Draw(GameTime gameTime)
        {
            //GameInfo.spriteBatch.Draw(currentTexture, playerPosition, playerSourceRectangle, Color.White, playerRotation, playerOrigin, playerScale, SpriteEffects.None, 0.0f);
            animationManager.animation.Draw(gameTime);
        }
    }
}
