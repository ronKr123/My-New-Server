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

        public string BookAudioFile { get => bookAudioFile; set => bookAudioFile = value; }
        public int Duration { get => duration; set => duration = value; }


    }
}
