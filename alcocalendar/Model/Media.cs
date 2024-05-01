using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace alcocalendar.Model
{
    internal class Media
    {
        private SoundPlayer player;

        public Media(string filePath)
        {
            this.player = new SoundPlayer(filePath);
        }

        public void Play()
        {
            player.Play();
        }

        public void Stop()
        {
            player.Stop();
        }
    }
}
