using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections.Generic;
using ViewModel;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SelectController : ControllerBase
    {
        // City

        [HttpGet]
        [ActionName("CitySelector")]
        public CityList SelectAllCities()
        {
            CityDB db = new CityDB();
            CityList cities = db.SelectAll();
            return cities;
        }

        [HttpGet("{id}")]
        [ActionName("SelectCityById")]
        public City SelectCityById(int id)
        {
            City city = CityDB.SelectById(id);
            return city;
        }

        
        // Genre 

        [HttpGet]
        [ActionName("GenreSelector")]
        public GenreList SelectAllGeneres()
        {
            GenreDB db = new GenreDB();
            GenreList geners = db.SelectAll();
            return geners;
        }

        [HttpGet("{id}")]
        [ActionName("SelectGenreById")]
        public Genre SelectGenreById(int id)
        {
            Genre genre = GenreDB.SelectById(id);
            return genre;
        }

        
        //Books

        [HttpGet]
        [ActionName("BooksSelector")]
        public BooksList SelectAllBooks()
        {
            BooksDB db = new BooksDB();
            BooksList books = db.SelectAll();
            return books;
        }

        [HttpGet("{id}")]
        [ActionName("SelectBookById")]
        public Books SelectBookById(int id)
        {
            Books book = BooksDB.SelectById(id);
            return book;
        }

        [HttpGet("{id}")]
        [ActionName("SelectBookByIdAction")]
        public IActionResult SelectBookById1(int id)
        {
            Books book = BooksDB.SelectById(id);

            if (book == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }

            return Ok(book);
        }


        [HttpGet]
        [ActionName("DigitalBooksSelector")]
        public DigitalBooksList SelectAllDigitalBooks()
        {
            DigitalBooksDB db = new DigitalBooksDB();
            DigitalBooksList books = db.SelectAll();
            return books;
        }

        [HttpGet("{id}")]
        [ActionName("SelectDigitalBookById")]
        public DigitalBooks SelectDigitalBookById(int id)
        {
            DigitalBooks digitalBook = DigitalBooksDB.SelectById(id);
            return digitalBook;
        }




        [HttpGet]
        [ActionName("LendingAndReturnsBooksSelector")]
        public LendingAndReturnsBooksList SelectAllLendingAndReturnsBooks()
        {
            LendingAndReturnsBooksDB db = new LendingAndReturnsBooksDB();
            LendingAndReturnsBooksList lendAndRetBooks = db.SelectAll();
            return lendAndRetBooks;
        }

        [HttpGet("{id}")]
        [ActionName("SelectLendingAndReturnsBookById")]
        public LendingAndReturnsBooks SelectLendingAndReturnsBookById(int id)
        {
            LendingAndReturnsBooks lendAndRetBook = LendingAndReturnsBooksDB.SelectById(id);
            return lendAndRetBook;
        }



        [HttpGet]
        [ActionName("UsersSelector")]
        public UsersList SelectAllUsers()
        {
            UsersDB db = new UsersDB();
            UsersList users = db.SelectAll();
            return users;
        }

        [HttpGet("{id}")]
        [ActionName("SelectUserById")]
        public Users SelectUserById(int id)
        {
            Users user = UsersDB.SelectById(id);
            return user;
        }

        [HttpGet("{userName}")]
        [ActionName("SelectUserByUserName")]
        public Users SelectUserByUserName(string userName)
        {
            UsersDB db = new UsersDB();
            UsersList listOfUsers = db.SelectAll();
            Users user = listOfUsers.Find(item => item.UserName == userName);
            return user;
        }

        [HttpGet]
        [ActionName("WritersSelector")]
        public WritersList SelectAllWriters()
        {
            WritersDB db = new WritersDB();
            WritersList writers = db.SelectAll();
            return writers;
        }


        [HttpGet("{id}")]
        [ActionName("SelectWriterById")]
        public Writers SelectWriterById(int id)
        {
            Writers writer = WritersDB.SelectById(id);
            return writer;
        }


        [HttpGet]
        [ActionName("MangersSelector")]
        public MangerLibraryList SelectAllMangers()
        {
            MangersDB dB = new MangersDB();
            MangerLibraryList mangers = dB.SelectAll();
            return mangers;
        }


        [HttpGet("{id}")]
        [ActionName("SelectMangerById")]
        public MangerLibrary SelectMangerById(int id)
        {
            MangerLibrary manger = MangersDB.SelectById(id);
            return manger;
        }


        [HttpGet("{id}")]
        [ActionName("BookPictureSelector64byte")]
        public string GetABookPictureById64Byte(int id)
        {
            BooksDB db = new BooksDB();
            string str = db.SelectBookPicByBookId(id);
            return str;
        }

        [HttpGet("{sqlSentence}")]
        [ActionName("SelectorBooksWithFilter")]
        public BooksList SelectorBooksWithFilter(string sqlSentence)
        {
            BooksDB db = new BooksDB();
            BooksList booksList = db.SelectAllWithFilter(sqlSentence);
            return booksList;
        }


    }
}
