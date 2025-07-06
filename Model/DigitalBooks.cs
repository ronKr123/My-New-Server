using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DigitalBooks: Books
    {
        private string bookAudioFile;

        private int duration;

        private string audioPath;

        public string BookAudioFile { get => bookAudioFile; set => bookAudioFile = value; }
        public int Duration { get => duration; set => duration = value; }
        public string AudioPath { get => audioPath; set => audioPath = value; }

    }
}
