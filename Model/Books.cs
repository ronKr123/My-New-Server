using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Books: BaseEntity
    {
        private string bookName;

        private Genre genreCode;

        private Writers writerCode;

        private string pictureBook;
        
        private DateTime dateOfPublishBook;
        
        private string bookPic;
        

        public string BookName { get => bookName; set => bookName = value; }
        public Genre GenreCode { get => genreCode; set => genreCode = value; }
        public Writers WriterCode { get => writerCode; set => writerCode = value; }
        public string PictureBook { get => pictureBook; set => pictureBook = value; }
        public DateTime DateOfPublishBook { get => dateOfPublishBook; set => dateOfPublishBook = value; }
        public string BookPic { get => bookPic; set => bookPic = value; }

    }
}
