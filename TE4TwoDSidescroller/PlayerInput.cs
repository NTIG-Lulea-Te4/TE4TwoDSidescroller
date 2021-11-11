﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    class PlayerInput : CharacterInput
    {
        Character character;

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

        public enum KeyboardMap
        {

        }


        private PlayerInput(Character character) 
            : base(character)
        {

            leftKey = Keys.A;
            rightKey = Keys.D;
            upKey = Keys.W;
            downKey = Keys.S;

            jumpKey = Keys.Space;
            runKey = Keys.LeftShift;
        }

        public override void Update(GameTime gameTime)
        {
            //Movements

            if (Keyboard.GetState().IsKeyDown(upKey))
            {
                character.GoesUp();
            }

            if (Keyboard.GetState().IsKeyDown(downKey))
            {

                character.GoesDown();
            }

            if (Keyboard.GetState().IsKeyDown(leftKey))
            {

                character.GoesLeft();
            }

            if (Keyboard.GetState().IsKeyDown(rightKey))
            {

                character.GoesRight();
            }


            if (Keyboard.GetState().IsKeyDown(runKey))
            {
                character.Run();
            }


            if (Keyboard.GetState().IsKeyDown(jumpKey))
            {

                character.Jump();
            }

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

            //Combat

            if (Keyboard.GetState().IsKeyDown(lightAttackKey))
            {
                character.LightAttack();
            }

            if (Keyboard.GetState().IsKeyDown(heavyAttackKey))
            {
                character.HeavyAttack();
            }

            if (Keyboard.GetState().IsKeyDown(specialAttackKey))
            {
                character.SpecialAttack();
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

            //Conditions

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
        }
    }
}
