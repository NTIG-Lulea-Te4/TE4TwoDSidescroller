using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    public class Character : Entity
    {
        public CharacterInput characterInput;

        public Animation animation;

        public VisionManager visionManager;

        //public AnimationManager animationManager;

        //public Dictionary<string, Animation> animations;

        //public Vector2 characterPosition;

        //public Texture2D characterTexture;


        public Character()
        {
            
        }


        //public Vector2 CharacterPosition
        //{
        //    get
        //    {
        //        return characterPosition;
        //    }
        //    set
        //    {
        //        characterPosition = value;

        //        if (animationManager != null)
        //        {
        //            animationManager.Position = characterPosition;
        //        }
        //    }
        //}

        //public Character(Dictionary<string, Animation> newAnimations)
        //{
        //    animations = newAnimations;
        //    animationManager = new AnimationManager(animations.First().Value); //first animation to pass will be the First/default one
        //}

        //public virtual void SetPlayerAnimation()
        //{
        //    if (movementVector.X > 0)
        //    {
        //        animationManager.Play(animations["RunRight"]);
        //    }

        //    else if (movementVector.X < 0)
        //    {
        //        animationManager.Play(animations["RunLeft"]);
        //    }

        //    else if (movementVector.Y > 0)
        //    {
        //        animationManager.Play(animations["RunDown"]);
        //    }

        //    else if (movementVector.Y < 0)
        //    {
        //        animationManager.Play(animations["RunUp"]);
        //    }
        //}

        #region Movement
        public virtual void MoveUp()
        {

        }

        public virtual void MoveDown()
        {

        }

        public virtual void MoveLeft()
        {

        }

        public virtual void MoveRight()
        {

        }

        public virtual void Run()
        {

        }

        public virtual void DoNotRun()
        {

        }

        public virtual void Jump(GameTime gameTime)
        {

        }

        public virtual void DoubleJump()
        {

        }

        public virtual void Crouch()
        {

        }

        public virtual void Dash()
        {

        }
        #endregion

        #region Combat

        public virtual void Attack1(GameTime gameTime)
        {

        }

        public virtual void Attack2()
        {

        }

        public virtual void Attack3()
        {

        }

        public virtual void Parry()
        {

        }

        public virtual void Block()
        {

        }

        public virtual void Dodge()
        {

        }

        #endregion

        #region Conditions

        public virtual void SwitchWeapon()
        {

        }

        public virtual void Interact()
        {

        }

        public virtual void OpenInGameMenu()
        {

        }

        public virtual void OpenInventory()
        {

        }

        public virtual void ConsumeHealthPotion()
        {

        }

        public virtual void ConsumeManaPotion()
        {

        }

        public virtual void ExitToMainMenu()
        {

        }

        public virtual void ExitGame()
        {

        }

        #endregion


        // ska sättas vars man checkar ifall man blir träffad
        public void Invincibility()
        {

            //stopp checking collision for half a second

        }

        //public virtual void Draw(SpriteBatch spriteBatch)
        //{
        //    if (characterTexture != null)
        //    {
        //        spriteBatch.Draw(characterTexture, characterPosition, Color.White);
        //    }
        //    else if (animationManager != null)
        //    {
        //        animationManager.Draw(spriteBatch);
        //    }
        //    else throw new Exception("You got Fed!");
        //}

        public override void Update(GameTime gameTime)
        {
            //SetPlayerAnimation();

            //animationManager.Update(gameTime);

            movementVector = Vector2.Zero;
            characterInput.Update(gameTime);
        }
    }
}
