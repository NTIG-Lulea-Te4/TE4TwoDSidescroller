using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TE4TwoDSidescroller
{
    class Player : Character
    {
        #region Variables/Fields
        public Texture2D currentTexture;
        private Texture2D playerRunRight;
        private Texture2D playerIdle;
        private Texture2D playerJump;
        private Texture2D playerOuch;

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

            detectionHitBox = new Rectangle(0, 0, 500, 500);
            collisionBox = new Rectangle(0, 0, playerSourceRectangle.Width, playerSourceRectangle.Height);

            LoadPlayerTexture2D();
            PlayerDictionary();
            Animate();

            maxHealth = 150;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            playerDamage = 10;

        }

        public Vector2 PlayerPosition
        {
            get
            {
                return playerPosition;
            }
            set
            {
                playerPosition = value;
            }
        }

        public Texture2D CurrentTexture
        {
            get
            {
                return currentTexture;
            }
            set
            {
                currentTexture = value;
            }
        }

        public void LoadPlayerTexture2D()
        {
            string path2 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/MainCharacters/" + "ShadowIdleAnim.png";
            using (Stream textureStream = new FileStream(path2, FileMode.Open))
            {
                playerIdle = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string path3 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/MainCharacters/" + "ShadowJumpAnim.png";
            using (Stream textureStream = new FileStream(path3, FileMode.Open))
            {
                playerJump = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string currentPath = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/MainCharacters/" + "ShadowRunRight.png";
            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                playerRunRight = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string path4 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/MainCharacters/" + "ShadowOuchAnim.png";
            using (Stream textureStream = new FileStream(path4, FileMode.Open))
            {
                playerOuch = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }
        }

        public void PlayerDictionary()
        {
            animations = new Dictionary<string, Animation>();

            Animation baseAnimation = new Animation(playerIdle, 4);
            baseAnimation.FramePerSecond = 4;
            animations.Add("base", baseAnimation);

            Animation runRight = new Animation(playerRunRight, 4);
            runRight.isLooping = true;
            runRight.FramePerSecond = 5;
            animations.Add("runRight", runRight);

            Animation runLeft = new Animation(playerRunRight, 4);
            runLeft.isLooping = true;
            runLeft.FramePerSecond = 5;
            runLeft.spriteEffects = SpriteEffects.FlipHorizontally;
            animations.Add("runLeft", runLeft);

            Animation idle = new Animation(playerIdle, 4);
            idle.isLooping = true;
            idle.FramePerSecond = 5;
            animations.Add("idle", idle);

            Animation flipIdle = new Animation(playerIdle, 4);
            flipIdle.isLooping = true;
            flipIdle.FramePerSecond = 5;
            animations.Add("flipIdle", flipIdle);

            Animation jump = new Animation(playerJump, 21);
            jump.isLooping = true;
            jump.FramePerSecond = 14;
            animations.Add("jump", jump);

            Animation flipJump = new Animation(playerJump, 21);
            flipJump.isLooping = true;
            flipJump.FramePerSecond = 14;
            flipJump.spriteEffects = SpriteEffects.FlipHorizontally;
            animations.Add("flipJump", flipJump);

            Animation ouch = new Animation(playerOuch, 3);
            ouch.isLooping = false;
            ouch.FramePerSecond = 10;
            animations.Add("ouch", ouch);

            Animation flipOuch = new Animation(playerOuch, 3);
            flipOuch.isLooping = false;
            flipOuch.FramePerSecond = 8;
            flipOuch.spriteEffects = SpriteEffects.FlipHorizontally;
            animations.Add("flipOuch", flipOuch);
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

            animations.TryGetValue("base", out tempBase);
            animations.TryGetValue("idle", out tempIdle);
            animations.TryGetValue("flipIdle", out tempFlipIdle);
            animations.TryGetValue("jump", out tempJump);
            animations.TryGetValue("ouch", out tempOuch);
            animations.TryGetValue("flipOuch", out tempFlipOuch);
            animations.TryGetValue("flipJump", out tempFlipJump);
            animations.TryGetValue("runRight", out tempRunRight);
            animations.TryGetValue("runLeft", out tempRunLeft);

            animation = tempBase;
            if (IsGrounded && movementVector.Y == 0 && movementVector.X == 0 && isWalkingRight)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;
                 
                animation = tempIdle;

            }

            else if (IsGrounded && movementVector.Y == 0 && movementVector.X == 0 && !isWalkingRight)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempFlipIdle;
            }

            else if (!IsGrounded && (movementVector.Y != 0 && movementVector.X >= 0))
            {
                tempFlipJump.frameIndex = 0;

                animation = tempJump;

            }

            else if (!IsGrounded && (movementVector.Y != 0 && movementVector.X <= 0))
            {
                tempJump.frameIndex = 0;

                animation = tempFlipJump;
            }

            else if (movementVector.Y == 0 && movementVector.X >= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempRunRight;

            }

            else if (movementVector.Y == 0 && movementVector.X <= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempRunLeft;

            }

            else if (hasTakenDamage)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempOuch;
            }

        }

        public override void HasCollidedWith(Entity collider)
        {
            if (collider.tag == Tags.Floor.ToString())
            {
                IsGrounded = true;
            }

            if (collider.tag == Tags.KnghtAttack.ToString())
            {
                health.TakeDamage(currentHealth, Knight.knightDamage, this);
                hasTakenDamage = true;
            }

        }

        #region Input

        public override void Reset()
        {
            playerPosition = new Vector2(200, 50);
            IsGrounded = false;
        }

        public override void MoveUp()
        {
            movementVector.Y -= moveSpeed;
            //Modife later to implant accelartion and friction. (acceleration - friction * movementVector.Y)
        }

        public override void MoveDown()
        {
            movementVector.Y += moveSpeed;
        }

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

            animation.position = playerPosition;
            animation.Update(gameTime);

            GameInfo.player1Position = playerPosition;
            GameInfo.Player1TextureSize = playerSourceRectangle;
            GameInfo.player1IsFacingRight = isFacingRight;

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
            animation.Draw(gameTime);
        }
    }
}
