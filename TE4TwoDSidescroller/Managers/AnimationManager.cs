using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TE4TwoDSidescroller
{
    public class AnimationManager
    {
        public Animation animation;

        public Dictionary<string, Animation> animations;

        private Texture2D playerRunRight;
        private Texture2D playerIdle;
        private Texture2D playerJump;
        private Texture2D playerOuch;

        private Texture2D knightWalk;
        private Texture2D knightJump;
        private Texture2D knightOuch;
        private Texture2D knightIdle;
        private Texture2D knightAttack;

        private Texture2D farmerIdle;
        private Texture2D farmerAttack;
        private Texture2D farmerWalk;
        private Texture2D farmerOuch;

        private Texture2D godIdle;
        private Texture2D godOuch;
        private Texture2D godFirstAttack;
        private Texture2D godSecondAttack;
        private Texture2D bigRockTexture;

        public AnimationManager()
        {
            animations = new Dictionary<string, Animation>();

            LoadPlayerTexture2D();

            LoadKnightTexture2D();

            LoadFarmerTexture2D();

            LoadGodTexture2D();
        }

        public void LoadPlayerTexture2D()
        {
            string playerPath1 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/MainCharacters/" + "ShadowIdleAnim.png";
            using (Stream textureStream = new FileStream(playerPath1, FileMode.Open))
            {
                playerIdle = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation playerBaseAnimation = new Animation(playerIdle, 4, 1, false, SpriteEffects.None);
                animations.Add("playerBase", playerBaseAnimation);

                Animation tempPlayerIdle = new Animation(playerIdle, 4, 5, true, SpriteEffects.None);
                animations.Add("playerIdle", tempPlayerIdle);

                Animation playerFlipIdle = new Animation(playerIdle, 4, 5, true, SpriteEffects.FlipHorizontally);
                animations.Add("playerFlipIdle", playerFlipIdle);
            }

            string playerPath2 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/MainCharacters/" + "ShadowJumpAnim.png";
            using (Stream textureStream = new FileStream(playerPath2, FileMode.Open))
            {
                playerJump = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempPlayerjump = new Animation(playerJump, 21, 14, true, SpriteEffects.None);
                animations.Add("playerJump", tempPlayerjump);

                Animation PlayerFlipJump = new Animation(playerJump, 21, 14, true, SpriteEffects.FlipHorizontally);
                animations.Add("playerFlipJump", PlayerFlipJump);
            }

            string playerPath3 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/MainCharacters/" + "ShadowRunRight.png";
            using (Stream textureStream = new FileStream(playerPath3, FileMode.Open))
            {
                playerRunRight = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempPlayerRunRight = new Animation(playerRunRight, 4, 5, true, SpriteEffects.None);
                animations.Add("playerRunRight", tempPlayerRunRight);

                Animation tempPlayerRunLeft = new Animation(playerRunRight, 4, 5, true, SpriteEffects.FlipHorizontally);
                animations.Add("playerRunLeft", tempPlayerRunLeft);
            }

            string playerPath4 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/MainCharacters/" + "ShadowOuchAnim.png";
            using (Stream textureStream = new FileStream(playerPath4, FileMode.Open))
            {
                playerOuch = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempPlayerOuch = new Animation(playerOuch, 3, 8, true, SpriteEffects.None);
                animations.Add("PlayerOuch", tempPlayerOuch);

                Animation playerFlipOuch = new Animation(playerOuch, 3, 8, true, SpriteEffects.FlipHorizontally);
                animations.Add("PlayerFlipOuch", playerFlipOuch);
            }
        }

        public void LoadKnightTexture2D()
        {
            string knightPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies/" + "KnightWalkAnim.png";
            using (Stream textureStream = new FileStream(knightPath, FileMode.Open))
            {
                knightWalk = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation knightWalkRight = new Animation(knightWalk, 4, 5, true, SpriteEffects.None);
                animations.Add("knightWalkRight", knightWalkRight);

                Animation knightWalkLeft = new Animation(knightWalk, 4, 5, true, SpriteEffects.FlipHorizontally);
                animations.Add("knightWalkLeft", knightWalkLeft);
            }

            string knightPath1 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies/" + "KnightJumpAnim.png";
            using (Stream textureStream = new FileStream(knightPath1, FileMode.Open))
            {
                knightJump = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempKnightJump = new Animation(knightJump, 10, 7, true, SpriteEffects.None);
                animations.Add("knightJump", tempKnightJump);

                Animation knightFlipJump = new Animation(knightJump, 10, 7, true, SpriteEffects.FlipHorizontally);
                animations.Add("knightFlipJump", knightFlipJump);
            }

            string knightPath2 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies/" + "KnightAttackAnim.png";
            using (Stream textureStream = new FileStream(knightPath2, FileMode.Open))
            {
                knightAttack = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempKnightAttack = new Animation(knightAttack, 4, 5, true, SpriteEffects.None);
                animations.Add("kngihtAttack", tempKnightAttack);

                Animation knightFlipAttack = new Animation(knightAttack, 4, 5, true, SpriteEffects.FlipHorizontally);
                animations.Add("knightFlipAttack", knightFlipAttack);
            }

            string knightPath3 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies/" + "KnightIdlePic.png";
            using (Stream textureStream = new FileStream(knightPath3, FileMode.Open))
            {
                knightIdle = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempKnightIdle = new Animation(knightIdle, 1, 1, true, SpriteEffects.None);
                animations.Add("knightIdle", tempKnightIdle);
            }

            string knightPath4 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies/" + "KnightOuchAnim.png";
            using (Stream textureStream = new FileStream(knightPath4, FileMode.Open))
            {
                knightOuch = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempKnightOuch = new Animation(knightOuch, 3, 1, true, SpriteEffects.None);
                animations.Add("knightOuch", tempKnightOuch);

                Animation knightFlipOuch = new Animation(knightOuch, 3, 1, true, SpriteEffects.FlipHorizontally);
                animations.Add("knightFlipOuch", knightFlipOuch);
            }
        }

        public void LoadFarmerTexture2D()
        {
            string farmerPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/FarmerIdlePic.png";
            using (Stream textureStream = new FileStream(farmerPath, FileMode.Open))
            {
                farmerIdle = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempFarmerIdle = new Animation(farmerIdle, 1, 1, true, SpriteEffects.None);
                animations.Add("farmerIdle", tempFarmerIdle);
            }

            string farmerPath1 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies/" + "FarmerAttackAnim.png";
            using (Stream textureStream = new FileStream(farmerPath1, FileMode.Open))
            {
                farmerAttack = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempFarmerAttack = new Animation(farmerAttack, 6, 8, true, SpriteEffects.None);
                animations.Add("farmerAttack", tempFarmerAttack);

                Animation knightFlipAttack = new Animation(farmerAttack, 6, 8, true, SpriteEffects.FlipHorizontally);
                animations.Add("farmerFlipAttack", knightFlipAttack);
            }

            string farmerPath2 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies/" + "FarmerWalkAnim.png";
            using (Stream textureStream = new FileStream(farmerPath2, FileMode.Open))
            {
                farmerWalk = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempFarmerWalkRight = new Animation(farmerWalk, 4, 5, true, SpriteEffects.None);
                animations.Add("farmerWalkRight", tempFarmerWalkRight);

                Animation tempFarmerWalkLeft = new Animation(farmerWalk, 4, 5, true, SpriteEffects.FlipHorizontally);
                animations.Add("farmerWalkLeft", tempFarmerWalkLeft);
            }

            string farmerPath3 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies/" + "FarmerOuchAnim.png";
            using (Stream textureStream = new FileStream(farmerPath3, FileMode.Open))
            {
                farmerOuch = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempFarmerOuch = new Animation(farmerOuch, 3, 10, true, SpriteEffects.None);
                animations.Add("farmerOuch", tempFarmerOuch);

                Animation farmerFlipOuch = new Animation(farmerOuch, 3, 10, true, SpriteEffects.FlipHorizontally);
                animations.Add("farmerFlipOuch", farmerFlipOuch);
            }
        }

        public void LoadGodTexture2D()
        {
            string bossPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/GodIdlePic.png";
            using (Stream textureStream = new FileStream(bossPath, FileMode.Open))
            {
                godIdle = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempGodIdle = new Animation(godIdle, 1, 1, true, SpriteEffects.None);
                animations.Add("godIdle", tempGodIdle);
            }

            string bossPath1 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/GodOuchAnim.png";
            using (Stream textureStream = new FileStream(bossPath1, FileMode.Open))
            {
                godOuch = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempGodOuch = new Animation(godOuch, 3, 8, true, SpriteEffects.None);
                animations.Add("godOuch", tempGodOuch);
            }

            string bossPath2 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/GodAttackAnim.png";
            using (Stream textureStream = new FileStream(bossPath2, FileMode.Open))
            {
                godFirstAttack = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempGodFirstAttack = new Animation(godFirstAttack, 4, 5, true, SpriteEffects.None);
                animations.Add("godFirstAttack", tempGodFirstAttack);
            }

            string bossPath3 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/GodAttackAnimTwo.png";
            using (Stream textureStream = new FileStream(bossPath3, FileMode.Open))
            {
                godSecondAttack = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempGodSecondAttack = new Animation(godSecondAttack, 4, 5, true, SpriteEffects.None);
                animations.Add("godSecondAttack", tempGodSecondAttack);
            }

            string rockPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/BigRock.png";
            using (Stream textureStream = new FileStream(rockPath, FileMode.Open))
            {
                bigRockTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

                Animation tempBigRockTexture = new Animation(bigRockTexture, 4, 5, true, SpriteEffects.None);
                animations.Add("bigRock", tempBigRockTexture);
            }
        }
    }
}