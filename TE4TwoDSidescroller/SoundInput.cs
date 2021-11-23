using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Media;

namespace TE4TwoDSidescroller
{
    class SoundInput: Game1
    {
        Song song;



        public SoundInput()
        {

            
            

        }
        public void PlaySound()
        {


            using (song = Content.Load<Song>("sound.mp3"))
            {
                MediaPlayer.Play(song);
                MediaPlayer.IsRepeating = true;
            }

        }



    }
}
