using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;


namespace LibraryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpDelete("{id}")]
        [ActionName("DeleteACity")]
        public int DeleteACity(int id)
        {
            City city = CityDB.SelectById(id);
            CityDB db = new CityDB();
            db.Delete(city);
            int x = db.SaveChanges();
            return x;
        }


        [HttpDelete("{id}")]
        [ActionName("DeleteAGenre")]
        public int DeleteAGenre(int id)
        {
            Genre genre = GenreDB.SelectById(id);
            GenreDB db = new GenreDB();
            db.Delete(genre);
            int x = db.SaveChanges();
            return x;
        }


        [HttpDelete("{id}")]
        [ActionName("DeleteABook")]
        public int DeleteABook(int id)
        {
            Books book = BooksDB.SelectById(id);
            BooksDB db = new BooksDB();
            db.Delete(book);
            int x = db.SaveChanges();
            return x;
        }


        [HttpDelete("{id}")]
        [ActionName("DeleteADigitalBook")]
        public int DeleteADigitalBook(int id)
        {
            DigitalBooks digiBook = DigitalBooksDB.SelectById(id);
            DigitalBooksDB db = new DigitalBooksDB();
            db.Delete(digiBook);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteALendingAndReturnBook")]
        public int DeleteALendingAndReturnBook(int id)
        {
            LendingAndReturnsBooks lendAndRetBook = LendingAndReturnsBooksDB.SelectById(id);
            LendingAndReturnsBooksDB db = new LendingAndReturnsBooksDB();
            db.Delete(lendAndRetBook);
            int x = db.SaveChanges();
            return x;
        }


        [HttpDelete("{id}")]
        [ActionName("DeleteAUser")]
        public int DeleteAUser(int id)
        {
            Users user = UsersDB.SelectById(id);
            UsersDB db = new UsersDB();
            db.Delete(user);
            int x = db.SaveChanges();
            return x;
        }


        [HttpDelete("{id}")]
        [ActionName("DeleteAWriter")]
        public int DeleteAWriter(int id)
        {
            Writers writer = WritersDB.SelectById(id);
            WritersDB db = new WritersDB();
            db.Delete(writer);
            int x = db.SaveChanges();
            return x;
        }


        [HttpDelete("{id}")]
        [ActionName("DeleteAManger")]
        public int DeleteAManger(int id)
        {
            MangerLibrary manger = MangersDB.SelectById(id);
            MangersDB db = new MangersDB();
            db.Delete(manger);
            int x = db.SaveChanges();
            return x;
        }



    }
}
