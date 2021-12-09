using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Media;
using System.Text;
using System.IO;
using System;

namespace TE4TwoDSidescroller
{
    class SoundInput : Game1
    {
        //hej där harry du ska ladda in alla filer här och sätta in dom  i sound players
        //sedan ska ddu skicak dem till en array i varje karakträ. 
        //sedam ska jag spela upp dem med metoden play array.sound skiut

        #region FilePaths

        public static string songPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Sound" + "/Song.wav";

        #endregion


        public static SoundEffect knigthWalk;
        public static SoundEffect mainCharacterJump;
        public static SoundEffect swordSwoosh;
        public static SoundEffect evilLaugh;
        public static SoundEffect startFireBall;
        public static SoundEffect activeFireBall;
        public static SoundEffect knigthSwosh;
        public static Song preBossMusic;
        public static Song ominousMusic;

        #region SoundPlayers


        public static SoundPlayer attack1;
        public static SoundPlayer attack2;
        public static SoundPlayer attack3;
        public static SoundPlayer attack4;

        #region Player

        public static SoundPlayer playerIdle;
        public static SoundPlayer playerWalk;
        public static SoundPlayer playerSprint;
        public static SoundPlayer playerJump;

        #endregion

        #region Enemy

        #region MobEnemy

        public static SoundPlayer enemyIdle1;
        public static SoundPlayer enemyWalk1;
        public static SoundPlayer enemySprint1;
        public static SoundPlayer enemyJump1;

        public static SoundPlayer enemyIdle2;
        public static SoundPlayer enemyWalk2;
        public static SoundPlayer enemySprint2;
        public static SoundPlayer enemyJump2;

        public static SoundPlayer enemyIdle3;
        public static SoundPlayer enemyWalk3;
        public static SoundPlayer enemySprint3;
        public static SoundPlayer enemyJump3;

        public static SoundPlayer enemyIdle4;
        public static SoundPlayer enemyWalk4;
        public static SoundPlayer enemySprint4;
        public static SoundPlayer enemyJump4;

        public static SoundPlayer enemyIdle5;
        public static SoundPlayer enemyWalk5;
        public static SoundPlayer enemySprint5;
        public static SoundPlayer enemyJump5;

        #endregion

        #region Bosses

        public static SoundPlayer BossDeath;
        public static SoundPlayer BossWalk;
        public static SoundPlayer BossAttack;
        public static SoundPlayer BossJump;

        #endregion

        #endregion

        #region DeathSound

        public static SoundPlayer death1;
        public static SoundPlayer death2;
        public static SoundPlayer death3;
        public static SoundPlayer death4;

        #endregion

        #endregion

        // här ska alla ljud som ska användas laddas in först.
        //kan välja att ladda in först eller bara säga filvägen och sedan ladda in med Playsync
        //men ljud som ska loppa ska laddas in först då det inte finns PlaySyncLooping.
        public SoundInput()
        {

            #region MakingSoundPlayerObjects

            attack1 = new SoundPlayer();
            attack2 = new SoundPlayer();
            attack3 = new SoundPlayer();
            attack4 = new SoundPlayer();

            playerIdle = new SoundPlayer();
            playerWalk = new SoundPlayer();
            playerSprint = new SoundPlayer();
            playerJump = new SoundPlayer();

            enemyIdle1 = new SoundPlayer();
            enemyWalk1 = new SoundPlayer();
            enemySprint1 = new SoundPlayer();
            enemyJump1 = new SoundPlayer();

            enemyIdle2 = new SoundPlayer();
            enemyWalk2 = new SoundPlayer();
            enemySprint2 = new SoundPlayer();
            enemyJump2 = new SoundPlayer();

            enemyIdle3 = new SoundPlayer();
            enemyWalk3 = new SoundPlayer();
            enemySprint3 = new SoundPlayer();
            enemyJump3 = new SoundPlayer();

            enemyIdle4 = new SoundPlayer();
            enemyWalk4 = new SoundPlayer();
            enemySprint4 = new SoundPlayer();
            enemyJump4 = new SoundPlayer();

            enemyIdle5 = new SoundPlayer();
            enemyWalk5 = new SoundPlayer();
            enemySprint5 = new SoundPlayer();
            enemyJump5 = new SoundPlayer();

            BossDeath = new SoundPlayer();
            BossWalk = new SoundPlayer();
            BossAttack = new SoundPlayer();
            BossJump = new SoundPlayer();

            death1 = new SoundPlayer();
            death2 = new SoundPlayer();
            death3 = new SoundPlayer();
            death4 = new SoundPlayer();

            #endregion

            #region Loading

            

            #endregion
        }

        public static void ContentLoad(ContentManager content)
        {

            knigthWalk = content.Load<SoundEffect>("Audio/ChainmailWalk");
            mainCharacterJump = content.Load<SoundEffect>("Audio/ShadowJump");
            swordSwoosh = content.Load<SoundEffect>("Audio/swoosh");
            evilLaugh = content.Load<SoundEffect>("Audio/EvilLaugh");
            startFireBall = content.Load<SoundEffect>("Audio/Fireball");
            activeFireBall = content.Load<SoundEffect>("Audio/FireballFire");
            knigthSwosh = content.Load<SoundEffect>("Audio/KnightSwordSwoosh");
            preBossMusic = content.Load<Song>("Audio/PreBossLevelMusic");
            ominousMusic = content.Load<Song>("Audio/CreepyBGMusic");

        }

        //public static SoundPlayer LoadSound(string loadingSoundFile, SoundPlayer load)
        //{

        //    load.SoundLocation = loadingSoundFile;
        //    load.Load();
        //    return load;

        //}

        //public static void PlaySound(SoundPlayer playingFile)
        //{

        //    playingFile.PlaySync();

        //}

        public static void SoundEffectPlayed(SoundEffect fileBeingPlayed, float fileVolume, float filePitch, float filePan)
        {
            
            fileBeingPlayed.Play(volume: fileVolume, pitch: filePitch, pan: filePan);
           
        }

        public static void SongPlay(Song songFileBeingPlayed)
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(songFileBeingPlayed);

            if (MediaPlayer.IsRepeating == false)
            {

                MediaPlayer.IsRepeating = true;

            }
        }



        //public void MusicPlayer(SoundPlayer playingMusicFile)
        //{
        //    playingMusicFile.Stop();
        //    playingMusicFile.PlayLooping();
        //}
    }
}
