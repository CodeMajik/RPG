using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class SoundManager
    {
        MediaLibrary mMediaLibrary;
        Random r;
        Song s;
        bool muted;

        public SoundManager()
        {
            mMediaLibrary = new MediaLibrary();
            r = new Random();
            muted = false;
            // play the first track from the album
            //MediaPlayer.Play(mMediaLibrary.Albums[r.Next(0, mMediaLibrary.Albums.Count - 1)].Songs[0]);

            s = Constants.content.Load<Song>(".\\audio\\Solar Sailer");
            MediaPlayer.Play(s);
            MediaPlayer.IsRepeating = true;
        }

        public void playNewRandomSound(){
            MediaPlayer.Play(mMediaLibrary.Albums[r.Next(0, mMediaLibrary.Albums.Count - 1)].Songs[0]);
        }

        public void update(KeyboardState k)
        {
            if (k.IsKeyDown(Keys.M))
            {
                muted = true;
            }
            if (k.IsKeyUp(Keys.M) && muted)
            {
                MediaPlayer.IsMuted ^= Convert.ToBoolean(1);
                muted = false;
            }
        }
    }
}
