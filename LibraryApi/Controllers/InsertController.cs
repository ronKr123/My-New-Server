using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;


namespace LibraryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InsertController : ControllerBase
    {
        [HttpPost]
        [ActionName("InsertACity")]
        public int InsertACity([FromBody] City city)
        {
            CityDB db = new CityDB();
            db.Insert(city);
            int x = db.SaveChanges();
            return x;
        }


        [HttpPost]
        [ActionName("InsertAGenre")]
        public int InsertAGenre([FromBody] Genre genre)
        {
            GenreDB db = new GenreDB();
            db.Insert(genre);
            int x = db.SaveChanges();
            return x;
        }


        [HttpPost]
        [ActionName("InsertABook")]
        public int InsertABook([FromBody] Books book)
        {
            BooksDB db = new BooksDB();
            db.Insert(book);
            int x = db.SaveChanges();
            return x;
        }


        [HttpPost]
        [ActionName("InsertADigitalBook")]
        public int InsertADigitalBook([FromBody] DigitalBooks digiBook)
        {
            DigitalBooksDB db = new DigitalBooksDB();
            db.Insert(digiBook);
            int x = db.SaveChanges();
            return x;
        }


        [HttpPost]
        [ActionName("InsertALendingAndReturnBook")]
        public int InsertALendingAndReturnBook([FromBody] LendingAndReturnsBooks lendAndRetBook)
        {
            LendingAndReturnsBooksDB db = new LendingAndReturnsBooksDB();
            db.Insert(lendAndRetBook);
            int x = db.SaveChanges();
            return x;
        }


        [HttpPost]
        [ActionName("InsertAUser")]
        public int InsertAUser([FromBody] Users user)
        {
            UsersDB db = new UsersDB();
            db.Insert(user);
            int x = db.SaveChanges();
            return x;
        }


        [HttpPost]
        [ActionName("InsertAWriter")]
        public int InsertAWriter([FromBody] Writers writer)
        {
            WritersDB db = new WritersDB();
            db.Insert(writer);
            int x = db.SaveChanges();
            return x;
        }


        [HttpPost]
        [ActionName("InsertAManger")]
        public int InsertAManger([FromBody] MangerLibrary manger)
        {
            MangersDB db = new MangersDB();
            db.Insert(manger);
            int x = db.SaveChanges();
            return x;
        }


    }
}
