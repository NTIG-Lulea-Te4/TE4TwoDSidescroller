using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class SoundInput: Game1
    {

        SoundEffect aboba;

        public SoundInput()
        {

            aboba = Content.Load<SoundEffect>("sound");

        }
        public void PlaySound()
        {
            //SoundEffect effect;
            aboba.Play();

            //effect = Content.Load<SoundEffect>("effect");
        }

        

    }
}
