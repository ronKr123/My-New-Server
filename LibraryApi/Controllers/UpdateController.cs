using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;


namespace LibraryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        [HttpPut]
        [ActionName("UpdateACity")]
        public int UpdateACity([FromBody] City city)
        {
            CityDB db = new CityDB();
            db.Update(city);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateAGenre")]
        public int UpdateAGenre([FromBody] Genre genre)
        {
            GenreDB db = new GenreDB();
            db.Update(genre);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateABook")]
        public int UpdateABook([FromBody] Books book)
        {
            BooksDB db = new BooksDB();
            db.Update(book);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateADigitalBook")]
        public int UpdateADigitalBook([FromBody] DigitalBooks digiBook)
        {
            DigitalBooksDB db = new DigitalBooksDB();
            db.Update(digiBook);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UpdateALendingAndReturnBook")]
        public int UpdateALendingAndReturnBook([FromBody] LendingAndReturnsBooks lendAndRetBook)
        {
            LendingAndReturnsBooksDB db = new LendingAndReturnsBooksDB();
            db.Update(lendAndRetBook);
            int x = db.SaveChanges();
            return x;
        }
        

        [HttpPut]
        [ActionName("UpdateAUser")]
        public int UpdateAUser([FromBody] Users user)
        {
            UsersDB db = new UsersDB();
            db.Update(user);
            int x = db.SaveChanges();
            return x;
        }


        [HttpPut]
        [ActionName("UpdateAWriter")]
        public int UpdateAWriter([FromBody] Writers writer)
        {
            WritersDB db = new WritersDB();
            db.Update(writer);
            int x = db.SaveChanges();
            return x;
        }


        [HttpPut]
        [ActionName("UpdateAManger")]
        public int UpdateAManger([FromBody] MangerLibrary manger)
        {
            MangersDB db = new MangersDB();
            db.Update(manger);
            int x = db.SaveChanges();
            return x;
        }


    }
}
