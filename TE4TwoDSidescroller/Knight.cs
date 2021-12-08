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

        //int gravity; - Game info
        //int currentYAxis; - Entity
        //int currentGravity; - Entity
        //int multiplier;
        //isGrounded - Entity

        GameInformationSystem gameInfoSystem;

        private Texture2D knightTexture;
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

        Texture2D[] Sprites;




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

            colorData = new Color[knightTexture.Width * knightTexture.Height];
            knightTexture.GetData(colorData);
        }

        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/Enemies/" + "KnightWalkAnim.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                knightTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }


        public override void HasCollidedWith(Entity collider)
        {

            if (collider.isFloor)
            {
                IsGrounded = true;
                
            }

            if (collider.tag == Tags.PlayerAttack.ToString())
            {
                hasCollided = true;
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

        }

        public override void MoveLeft()
        {
            
            movementVector.X -= movementSpeed;

        }

        public override void Jump(GameTime gameTime)
        {

            if (IsGrounded)
            {
                IsGrounded = false;
                movementVector.Y -= movementSpeed * 10;

            }

        }


        public override void Attack1(GameTime gameTime)
        {

            weaponCollsion = new Rectangle(collisionBox.X + collisionBox.Width, 
                collisionBox.Y + collisionBox.Width, 32, 10);

            weaponCollsion.Y += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (weaponCollsion.Y > collisionBox.Y)
            {
                weaponCollsion = new Rectangle(collisionBox.X + collisionBox.Width,
                collisionBox.Y + collisionBox.Width, 0, 0);
            }

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

            if (hasCollided)
            {
                GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.Red);
            }
            else
            {
                GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            GameInfo.spriteBatch.Draw(knightTexture, knightPosition, sourceRectangle, 
                Color.White, knightRotation, knightOrigin, knightScale, 
                SpriteEffects.None, 0f);

            // base.Draw(gameTime);
        }

    }
}
