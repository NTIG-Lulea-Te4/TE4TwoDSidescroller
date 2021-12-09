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


        GameInformationSystem gameInfoSystem;

        private Texture2D knightTexture;
        protected Rectangle sourceRectangle;
        public static Vector2 movementDirection;
        public static Vector2 knightPosition;
        private Vector2 knightOrigin;
        private Vector2 knightVelocity;
        private Vector2 knightScale;
        private float knightRotation;
        private float knightJumpHeight;
        private Vector2 trackingDistance;

        private Health health;

        
        public bool knightIsFacingRight;

        public Knight()
        {

            characterInput = new KnightBehaviour(this);

            tag = Tags.Knight.ToString();

            IsGrounded = false;
            isActive = true;
            hasCollider = true;
            knightIsFacingRight = true;

             

            movementSpeed = 0.3f;
            maxHealth = 10;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            health = new Health();

            gameInfoSystem = new GameInformationSystem();

            sourceRectangle = new Rectangle(0, 0, 64, 96);
            knightPosition = new Vector2(500, 500);
            movementDirection = new Vector2();
            knightVelocity = new Vector2(0, 0);

            knightOrigin = new Vector2(0, 0);
            knightScale = new Vector2(1, 1);
            movementVector = new Vector2(0, 0);
            knightRotation = 0;
            trackingDistance = new Vector2(300, 300);
            

            collisionBox = new Rectangle(0, 0, 64, 96);

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

            if (collider.tag == Tags.Floor.ToString())
            {
                IsGrounded = true;

            }

            if (collider.tag == Tags.PlayerMeleeAttack.ToString())
            {

                health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

            if (collider.tag == Tags.PlayerRangeAttack.ToString())
            {
                health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

        }

        #region Behaviour

        public override void MoveRight()
        {



            movementVector.X += movementSpeed;
            knightIsFacingRight = true;


        }

        public override void MoveLeft()
        {

            movementVector.X -= movementSpeed;
            knightIsFacingRight = false;


        }

        public override void Jump(GameTime gameTime)
        {

            if (IsGrounded)
            {
                IsGrounded = false;
                movementVector.Y -= movementSpeed;

            }

        }


        public override void Attack1()
        {


            GameInfo.creationManager.InitializeKnightAttack();



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


        }

        public override void Draw(GameTime gameTime)
        {


            GameInfo.spriteBatch.Draw(knightTexture, knightPosition, sourceRectangle,
                Color.White, knightRotation, knightOrigin, knightScale,
                SpriteEffects.None, 0f);

            // base.Draw(gameTime);
        }

    }
}
