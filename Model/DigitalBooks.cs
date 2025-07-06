using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DigitalBooks: Books
    {
		public string BookAudioFile { get; set; } = string.Empty;

		public int Duration { get; set; }

		public string AudioPath { get; set; } = string.Empty;

	}
}
