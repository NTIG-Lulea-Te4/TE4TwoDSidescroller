using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Priest : Character
    {

        GameInformationSystem gameInfoSystem;

        private Texture2D priestTexture;
        private Rectangle sourceRectangle;
        static public Vector2 movementDirection;
        static public Vector2 priestPosition;
        private Vector2 priestOrigin;
        private Vector2 priestVelocity;
        private Vector2 priestScale;
        private float priestRotation;
        private float priestJumpHeight;

        private Health health;


        public Priest()
        {

            characterInput = new PriestBehaviour(this);

            tag = Tags.Priest.ToString();

            IsGrounded = false;
            isActive = true;
            hasCollider = true;

            movementSpeed = 0.8f;
            maxHealth = 10;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            health = new Health();

            gameInfoSystem = new GameInformationSystem();

            sourceRectangle = new Rectangle(0, 0, 64, 96);
            priestPosition = new Vector2(300, 0);
            movementDirection = new Vector2();
            priestVelocity = new Vector2(0, 0);

            priestOrigin = new Vector2(0, 0);
            priestScale = new Vector2(1, 1);
            movementVector = new Vector2(0, 0);
            priestRotation = 0;

            collisionBox = new Rectangle(0, 0, 64, 96);

            LoadTexture2D();

            colorData = new Color[priestTexture.Width * priestTexture.Height];
            priestTexture.GetData(colorData);
        }

        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/Enemies/" + "PriestIdlePic.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                priestTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
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


        public override void Attack1()
        {


        }

        #endregion

        public override void Update(GameTime gameTime)
        {


            movementDirection = GameInfo.player1Position - priestPosition;

            priestVelocity = new Vector2(0, 0);
            priestJumpHeight = 0;

            priestPosition += movementVector;

            collisionBox.X = (int)priestPosition.X;
            collisionBox.Y = (int)priestPosition.Y;

            base.Update(gameTime);

            if (!IsGrounded)
            {

                increasingGravity += gameInfoSystem.gravity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            }

            priestVelocity.Y += increasingGravity - priestJumpHeight;

            movementVector += priestVelocity;


        }

        public override void Draw(GameTime gameTime)
        {


            GameInfo.spriteBatch.Draw(priestTexture, priestPosition, sourceRectangle,
                Color.White, priestRotation, priestOrigin, priestScale,
                SpriteEffects.None, 0f);


        }

    }
}
