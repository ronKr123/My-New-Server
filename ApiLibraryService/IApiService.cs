using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;
using LibraryApi;


namespace ApiLibraryService
{
    public interface IApiService
    {
        // City :

        public Task<CityList> SelectAllCities();
        public Task<int> InsertACity(City city);
        public Task<int> UpdateACity(City city);
        public Task<int> DeleteACity(City city);

        public Task<City> SelectCityById(int id);

        // Genre :

        public Task<GenreList> SelectAllGeneres();
        public Task<int> InsertAGenre(Genre genre);
        public Task<int> UpdateAGenre(Genre genre);
        public Task<int> DeleteAGenre(Genre genre);
        public Task<Genre> SelectGenreById(int id);

        
        // Books :
        public Task<BooksList> SelectAllBooks();
        public Task<int> InsertABook(Books book);
        public Task<int> UpdateABook(Books book);
        public Task<int> DeleteABook(Books book);

        public Task<Books> SelectBookById(int id);

        public Task<string> GetBookPicByte64(int id);

        // Filter - Action
        public Task<BooksList> SelectAllBooksWithFilter(string sqlSentence);


        // DigitalBooks :
        public Task<DigitalBooksList> SelectAllDigitalBooks();
        public Task<int> InsertADigitalBook(DigitalBooks digitalBook);
        public Task<int> UpdateADigitalBook(DigitalBooks digitalBook);
        public Task<int> DeleteADigitalBook(DigitalBooks digitalBook);

        public Task<DigitalBooks> SelectDigitalBookById(int id);


        // LendingAndReturnsBooks :
        public Task<LendingAndReturnsBooksList> SelectAllLendingAndReturnsBooks();
        public Task<int> InsertALendingAndReturnBook(LendingAndReturnsBooks lendAndRetBook);
        public Task<int> UpdateALendingAndReturnBook(LendingAndReturnsBooks lendAndRetBook);
        public Task<int> DeleteALendingAndReturnBook(LendingAndReturnsBooks lendAndRetBook);

        public Task<LendingAndReturnsBooks> SelectLendingAndReturnsBookById(int id);

        // Users :
        public Task<UsersList> SelectAllUsers();
        public Task<int> InsertAUser(Users user);
        public Task<int> UpdateAUser(Users user);
        public Task<int> DeleteAUser(Users user);
        public Task<Users> SelectUserById(int id);
        public Task<Users> SelectUserByUserName(string userName);



        // Writers :
        public Task<WritersList> SelectAllWriters();
        public Task<int> InsertAWriter(Writers writer);
        public Task<int> UpdateAWriter(Writers writer);
        public Task<int> DeleteAWriter(Writers writer);
        public Task<Writers> SelectWriterById(int id);

        // Mangers :

        public Task<MangerLibraryList> SelectAllMangers();
        public Task<int> InsertAManger(MangerLibrary manger);
        public Task<int> UpdateAManger(MangerLibrary manger);
        public Task<int> DeleteAManger(MangerLibrary manger);
        public Task<MangerLibrary> SelectMangerById(int id);




    }
}
