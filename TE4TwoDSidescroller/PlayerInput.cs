using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    class PlayerInput : CharacterInput
    {

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        MouseState currentMouseState;
        MouseState previousMouseState;

        private Keys[] keys;

        #region Keys
        private Keys upKey;
        private Keys downKey;
        private Keys leftKey;
        private Keys rightKey;

        private Keys runKey;

        private Keys jumpKey;
        private Keys doubleJumpKey;

        private Keys crouchKey;
        private Keys dashKey;

        private Keys weaponSwitchKey;

        private Keys lightAttackKey;
        private Keys heavyAttackKey;
        private Keys specialAttackKey;

        private Keys parryKey;
        private Keys blockKey;
        private Keys dodgeKey;

        private Keys healthPotionKey;
        private Keys manaPotionKey;

        private Keys interactKey;

        private Keys inventoryKey;

        private Keys inGameMenuKey;

        private Keys exitToMainMenuKey;

        private Keys exitGameKey;

        #endregion

        public enum KeyboardMap
        {

        }

        public PlayerInput(Character character)
            : base(character)
        {

            currentKeyboardState = Keyboard.GetState();

            currentMouseState = Mouse.GetState();

            keys = new Keys[]
            {
                Keys.W,
                Keys.S,
                Keys.A,
                Keys.D,

                Keys.LeftShift,

                Keys.Space,

                Keys.C,
                Keys.LeftAlt,

                Keys.T,
            };

            upKey = Keys.W;
            downKey = Keys.S;
            leftKey = Keys.A;
            rightKey = Keys.D;

            jumpKey = Keys.Space;
            runKey = Keys.LeftShift;
            //doubleJumpKey = Keys.Space;
        }


        public override void Update(GameTime gameTime)
        {
            #region Movements

            if (Keyboard.GetState().IsKeyDown(upKey))
            {

                character.MoveUp();
            }

            //if(currentKeyboardState.IsKeyDown(upKey) && previousKeyboardState.IsKeyDown(upKey))
            //{
            //    character.MoveUp();
            ////    //if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            ////    //{

            ////    //}
            //}

            if (Keyboard.GetState().IsKeyDown(downKey))
            {

                character.MoveDown();
            }

            if (Keyboard.GetState().IsKeyDown(leftKey))
            {

                character.MoveLeft();
            }

            if (Keyboard.GetState().IsKeyDown(rightKey))
            {

                character.MoveRight();
            }


            if (Keyboard.GetState().IsKeyDown(runKey) /*&& character.HasRunned == false*/)
            {
                character.Run();
                //character.HasRunned = true;

            }

            if (Keyboard.GetState().IsKeyUp(runKey))
            {
                character.DontRun();
            }

            if (Keyboard.GetState().IsKeyDown(jumpKey) && character.HasJumped == false)
            {

                character.Jump(gameTime);
                //character.HasJumped = true;
            }

            //if (Keyboard.GetState().IsKeyUp(jumpKey) && character.HasJumped == true)
            //{

            //    character.Jump();
            //}

            if (Keyboard.GetState().IsKeyDown(doubleJumpKey))
            {
                character.DoubleJump();
            }


            if (Keyboard.GetState().IsKeyDown(crouchKey))
            {
                character.Crouch();
            }
            if (Keyboard.GetState().IsKeyDown(dashKey))
            {
                character.Dash();
            }

            #endregion

            #region Combat

            if (Keyboard.GetState().IsKeyDown(lightAttackKey))
            {
                character.Attack1();
            }

            if (Keyboard.GetState().IsKeyDown(heavyAttackKey))
            {
                character.Attack2();
            }

            if (Keyboard.GetState().IsKeyDown(specialAttackKey))
            {
                character.Attack3();
            }


            if (Keyboard.GetState().IsKeyDown(parryKey))
            {
                character.Parry();
            }

            if (Keyboard.GetState().IsKeyDown(blockKey))
            {
                character.Block();
            }

            if (Keyboard.GetState().IsKeyDown(dodgeKey))
            {
                character.Dodge();
            }

            #endregion

            #region Conditions

            if (Keyboard.GetState().IsKeyDown(weaponSwitchKey))
            {
                character.SwitchWeapon();
            }

            if (Keyboard.GetState().IsKeyDown(interactKey))
            {
                character.Interact();
            }

            if (Keyboard.GetState().IsKeyDown(inGameMenuKey))
            {
                character.OpenInGameMenu();
            }

            if (Keyboard.GetState().IsKeyDown(inventoryKey))
            {
                character.OpenInventory();
            }

            if (Keyboard.GetState().IsKeyDown(healthPotionKey))
            {
                character.ConsumeHealthPotion();
            }

            if (Keyboard.GetState().IsKeyDown(manaPotionKey))
            {
                character.ConsumeManaPotion();
            }

            if (Keyboard.GetState().IsKeyDown(exitToMainMenuKey))
            {
                character.ExitToMainMenu();
            }

            if (Keyboard.GetState().IsKeyDown(exitGameKey))
            {
                character.ExitGame();
            }

            #endregion

            //previousKeyboardState = currentKeyboardState;
            //previousMouseState = currentMouseState;

            base.Update(gameTime);
        }
    }
}
