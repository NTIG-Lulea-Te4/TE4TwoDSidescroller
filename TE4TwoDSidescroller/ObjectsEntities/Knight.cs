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
        // :D
        //int gravity; - Game info
        //int currentYAxis; - Entity
        //int currentGravity; - Entity
        //int multiplier;
        //isGrounded - Entity

        GameInformationSystem gameInfoSystem;

        Animation animation;
        Dictionary<string, Animation> knightDictionary;

        private Texture2D knightWalk;
        private Texture2D knightJump;
        private Texture2D knightOuch;
        private Texture2D knightIdle;
        private Texture2D knightAttack;

        private Rectangle sourceRectangle;
        static public Vector2 movementDirection;
        static public Vector2 movementDirectionOnXAxis;
        static public Vector2 knightPosition;
        private Vector2 knightOrigin;
        private Vector2 knightVelocity;
        private Vector2 knightScale;
        private float knightRotation;
        private float knightJumpHeight;


        private Health health;

        bool hasCollided;
        bool isWalkingRight;
        bool hasTakenDamage;

        Texture2D[] Sprites;

        public static int knightDamage;


        public Knight()
        {

            characterInput = new KnightBehaviour(this);

            tag = Tags.Knight.ToString();

            IsGrounded = false;
            isActive = true;
            hasCollider = true;

            hasCollided = false;

            movementSpeed = 0.5f;
            maxHealth = 10;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            health = new Health();

            gameInfoSystem = new GameInformationSystem();

            sourceRectangle = new Rectangle(0, 0, 64, 96);
            knightPosition = new Vector2(500, 0);
            movementDirection = new Vector2();
            //movementDirectionOnXAxis = new Vector2();
            knightVelocity = new Vector2(0, 0);
            
            knightOrigin = new Vector2(0, 0);
            knightScale = new Vector2(1, 1);
            movementVector = new Vector2(0, 0);
            knightRotation = 0;

            collisionBox = new Rectangle(0, 0, 64, 96);
            //weaponCollsion = new Rectangle();

            LoadTexture2D();

            KnightDictionary();
            KnightAnimation();

            colorData = new Color[knightWalk.Width * knightWalk.Height];
            knightWalk.GetData(colorData);

            knightDamage = 5;


        }

        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/Enemies/" + "KnightWalkAnim.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                knightWalk = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string Path4 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/Enemies/" + "KnightJumpAnim.png";

            using (Stream textureStream = new FileStream(Path4, FileMode.Open))
            {
                knightJump = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string Path1 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/Enemies/" + "KnightAttackAnim.png";

            using (Stream textureStream = new FileStream(Path1, FileMode.Open))
            {
                knightAttack = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string Path2 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/Enemies/" + "KnightIdlePic.png";

            using (Stream textureStream = new FileStream(Path2, FileMode.Open))
            {
                knightIdle = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string Path3 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/Enemies/" + "KnightOuchAnim.png";

            using (Stream textureStream = new FileStream(Path3, FileMode.Open))
            {
                knightOuch = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }

        public void KnightDictionary()
        {
            knightDictionary = new Dictionary<string, Animation>();

            Animation baseAnimation = new Animation(knightIdle, 1);
            baseAnimation.isLooping = true;
            baseAnimation.FramePerSecond = 1;
            knightDictionary.Add("base", baseAnimation);

            Animation walkRight = new Animation(knightWalk, 4);
            walkRight.isLooping = true;
            walkRight.FramePerSecond = 5;
            knightDictionary.Add("walkRight", walkRight);

            Animation walkLeft = new Animation(knightWalk, 4);
            walkLeft.isLooping = true;
            walkLeft.FramePerSecond = 5;
            walkLeft.spriteEffects = SpriteEffects.FlipHorizontally;
            knightDictionary.Add("walkLeft", walkLeft);

            Animation jump = new Animation(knightJump, 10);
            jump.isLooping = true;
            jump.FramePerSecond = 7;
            knightDictionary.Add("jump", jump);

            Animation flipJump = new Animation(knightJump, 10);
            flipJump.isLooping = true;
            flipJump.FramePerSecond = 7;
            flipJump.spriteEffects = SpriteEffects.FlipHorizontally;
            knightDictionary.Add("flipJump", flipJump);

            Animation attack = new Animation(knightAttack, 4);
            attack.isLooping = true;
            attack.FramePerSecond = 5;
            knightDictionary.Add("attack", attack);

            Animation flipAttack = new Animation(knightAttack, 4);
            flipAttack.isLooping = true;
            flipAttack.FramePerSecond = 5;
            flipAttack.spriteEffects = SpriteEffects.FlipHorizontally;

            Animation ouch = new Animation(knightOuch, 3);
            ouch.isLooping = false;
            ouch.FramePerSecond = 10;
            knightDictionary.Add("ouch", ouch);

            Animation flipOuch = new Animation(knightOuch, 3);
            flipOuch.isLooping = false;
            flipOuch.FramePerSecond = 10;
            flipOuch.spriteEffects = SpriteEffects.FlipHorizontally;
            knightDictionary.Add("flipOuch", flipOuch);
        }

        public void KnightAnimation()
        {
            Animation tempBase;
            Animation tempWalkRight;
            Animation tempWalkLeft;
            Animation tempIdle;
            Animation tempJump;
            Animation tempFlipJump;
            Animation tempOuch;
            Animation tempFlipOuch;

            knightDictionary.TryGetValue("base", out tempBase);
            knightDictionary.TryGetValue("idle", out tempIdle);
            knightDictionary.TryGetValue("jump", out tempJump);
            knightDictionary.TryGetValue("ouch", out tempOuch);
            knightDictionary.TryGetValue("flipOuch", out tempFlipOuch);
            knightDictionary.TryGetValue("flipJump", out tempFlipJump);
            knightDictionary.TryGetValue("walkRight", out tempWalkRight);
            knightDictionary.TryGetValue("walkLeft", out tempWalkLeft);

            animation = tempBase;
            if (movementVector.Y == 0 && movementVector.X >= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempWalkRight;
            }

            else if (movementVector.Y == 0 && movementVector.X <= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempWalkLeft;
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

            else if (IsGrounded && movementVector.Y == 0 && movementVector.X == 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempBase;
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

            if (collider.tag == Tags.PlayerAttack.ToString())
            {
                hasCollided = true;
                hasTakenDamage = true;
                health.TakeDamage(currentHealth, Player.playerDamage, this);
            }
            else
            {
                hasCollided = false;
            }
        }

        #region Behaviour

        public override void MoveRight()
        {

            //movementDirectionOnXAxis.Normalize();
            //movementVector.X += movementDirectionOnXAxis.X * movementSpeed;
            movementVector.X += movementSpeed;
            isWalkingRight = true;

        }

        public override void MoveLeft()
        {
            
            movementVector.X -= movementSpeed;
            isWalkingRight = false;

        }

        public override void Jump(GameTime gameTime)
        {

            if (IsGrounded)
            {
                IsGrounded = false;
                movementVector.Y -= movementSpeed * 100;

            }

        }


        public override void Attack1( )
        {


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

            movementDirection = GameInfo.player1Position - knightPosition;

            knightVelocity = new Vector2(0, 0);
            knightJumpHeight = 0;

            knightPosition += movementVector;
            KnightAnimation();

            animation.position = knightPosition;
            animation.Update(gameTime);

            collisionBox.X = (int)knightPosition.X;
            collisionBox.Y = (int)knightPosition.Y;

            base.Update(gameTime);

            if (!IsGrounded)
            {

                increasingGravity += gameInfoSystem.gravity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            }

            knightVelocity.Y += increasingGravity - knightJumpHeight;

            movementVector += knightVelocity;




            #region Animation Stuff

            //if (frameTimer >= frameThreshHold)
            //{

            //    frameCounter++;
            //    currentFrame = frameCounter * frameWidth;

            //    sourceRectangle.Width = currentFrame;

            //    frameTimer = 0;

            //    if (frameCounter == 4)
            //    {
            //        frameCounter = 1;
            //    }

            //}

            //frameTimer += gameTime.ElapsedGameTime.Milliseconds;

            //if (movementDirection.X > 0.1f)
            //{

            //}
            //else if (movementDirection.X < 0.1f)
            //{
            //    knightScale.X *= -1;
            //}

            #endregion

        }

        public override void Draw(GameTime gameTime)
        {

            //if (hasCollided)
            //{
            //    GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.Red);
            //}
            //else
            //{
            //    GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);
            //}

            //GameInfo.spriteBatch.Draw(knightWalk, knightPosition, sourceRectangle, 
            //    Color.White, knightRotation, knightOrigin, knightScale, 
            //    SpriteEffects.None, 0f);
            animation.Draw(gameTime);
            // base.Draw(gameTime);
        }

    }
}
