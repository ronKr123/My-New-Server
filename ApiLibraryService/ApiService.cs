using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;
using LibraryApi;
using System.Net.Http.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Windows.UI.Notifications;
using System.Drawing;

namespace ApiLibraryService
{
    public class ApiService : IApiService
    {

        public static HttpClient client;
        public static string uri;


        public ApiService()
        {
            client = new HttpClient();
            uri = "http://localhost:5198/api/";
        }


        // City :
        public async Task<CityList> SelectAllCities()
        {
            CityList cities = null;
            try
            {
                cities = await client.GetFromJsonAsync<CityList>(uri + "Select/CitySelector");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return cities;
        }


        public async Task<int> InsertACity(City city)
        {
            var x = await client.PostAsJsonAsync<City>(uri + "Insert/InsertACity", city);
            return x.IsSuccessStatusCode ? 1 : 0;
        }


        public async Task<int> DeleteACity(City city)
        {
            int numOfRowsChanged = 0;
            try
            {
                using (HttpClient cli = new HttpClient())
                {
                    string url = uri + "Delete/DeleteACity/";
                    url += city.Id.ToString();

                    string strJson = JsonSerializer.Serialize<City>(city);

                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(strJson,

                    Encoding.UTF8, "application/json");

                    var apiResponse = await cli.SendAsync(request);
                    if (apiResponse.StatusCode ==

                    System.Net.HttpStatusCode.OK)
                    {
                        numOfRowsChanged = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return numOfRowsChanged;
        }


       
        public async Task<int> UpdateACity(City city)
        {
            var x = await client.PutAsJsonAsync<City>(uri + "Update/UpdateACity", city);
            return x.IsSuccessStatusCode ? 1 : 0;
        }


        // -------------
        // Genre :
        public async Task<GenreList> SelectAllGeneres()
        {
            GenreList geners = null;
            try
            {
                geners = await client.GetFromJsonAsync<GenreList>(uri + "Select/GenreSelector");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return geners;
        }

        public async Task<int> InsertAGenre(Genre genre)
        {
            var x = await client.PostAsJsonAsync<Genre>(uri + "Insert/InsertAGenre", genre);
            return x.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateAGenre(Genre genre)
        {
            var x = await client.PutAsJsonAsync<Genre>(uri + "Update/UpdateAGenre", genre);
            return x.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteAGenre(Genre genre)
        {
            HttpClient client = new HttpClient();
            int numOfRowsChanged = 0;
            try
            {
                using (var cli = new HttpClient())
                {
                    string url = uri + "Delete/DeleteAGenre/";

                    url += genre.Id.ToString();

                    string strJson = JsonSerializer.Serialize<Genre>(genre);

                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(strJson,

                    Encoding.UTF8, "application/json");

                    var apiResponse = await cli.SendAsync(request);
                    if (apiResponse.StatusCode ==

                    System.Net.HttpStatusCode.OK)
                    {
                        numOfRowsChanged = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return numOfRowsChanged;
        }



        // -------------
        // Books :

        public async Task<BooksList> SelectAllBooks()
        {
            BooksList books = null;
            try
            {
                books = await client.GetFromJsonAsync<BooksList>(uri + "Select/BooksSelector");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return books;
        }

        public async Task<int> InsertABook(Books book)
        {
            try
            {
                var x = await client.PostAsJsonAsync<Books>(uri + "Insert/InsertABook", book);
                return x.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> UpdateABook(Books book)
        {
            var x = await client.PutAsJsonAsync<Books>(uri + "Update/UpdateABook", book);
            return x.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteABook(Books book)
        {
            int numOfRowsChanged = 0;
            try
            {
                using (var cli = new HttpClient())
                {
                    string url = uri + 

                   "Delete/DeleteABook/";

                    url += book.Id.ToString();


                    string strJson = JsonSerializer.Serialize<Books>(book);


                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(strJson,

                    Encoding.UTF8, "application/json");

                    var apiResponse = await cli.SendAsync(request);
                    if (apiResponse.StatusCode ==

                    System.Net.HttpStatusCode.OK)
                    {
                        numOfRowsChanged = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return numOfRowsChanged;
        }


        //-----------------
        // DigitalBooks :

        public async Task<DigitalBooksList> SelectAllDigitalBooks()
        {
            DigitalBooksList digitalBooks = null;
            try
            {
                digitalBooks = await client.GetFromJsonAsync<DigitalBooksList>(uri + "Select/DigitalBooksSelector");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return digitalBooks;
        }

        public async Task<int> InsertADigitalBook(DigitalBooks digitalBook)
        {
            var x = await client.PostAsJsonAsync<DigitalBooks>(uri + "Insert/InsertADigitalBook", digitalBook);
            return x.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateADigitalBook(DigitalBooks digitalBook)
        {
            var x = await client.PutAsJsonAsync<DigitalBooks>(uri + "Update/UpdateADigitalBook", digitalBook);
            return x.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteADigitalBook(DigitalBooks digitalBook)
        {
            int numOfRowsChanged = 0;
            try
            {
                using (var cli = new HttpClient())
                {
                    string url = uri +

                   "Delete/DeleteADigitalBook/";

                    url += digitalBook.Id.ToString();


                    string strJson = JsonSerializer.Serialize<DigitalBooks>(digitalBook);


                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(strJson,

                    Encoding.UTF8, "application/json");

                    var apiResponse = await cli.SendAsync(request);
                    if (apiResponse.StatusCode ==

                    System.Net.HttpStatusCode.OK)
                    {
                        numOfRowsChanged = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return numOfRowsChanged;
        }


        // ---------------------------
        // LendingAndReturnsBooks :

        public async Task<LendingAndReturnsBooksList> SelectAllLendingAndReturnsBooks()
        {
            LendingAndReturnsBooksList lendingAndReturns = null;
            try
            {
                lendingAndReturns = await client.GetFromJsonAsync<LendingAndReturnsBooksList>(uri + "Select/LendingAndReturnsBooksSelector");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lendingAndReturns;
        }

        public async Task<int> InsertALendingAndReturnBook(LendingAndReturnsBooks lendAndRetBook)
        {
            var x = await client.PostAsJsonAsync<LendingAndReturnsBooks>(uri + "Insert/InsertALendingAndReturnBook", lendAndRetBook);
            return x.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateALendingAndReturnBook(LendingAndReturnsBooks lendAndRetBook)
        {
            var x = await client.PutAsJsonAsync<LendingAndReturnsBooks>(uri + "Update/UpdateALendingAndReturnBook", lendAndRetBook);
            return x.IsSuccessStatusCode ? 1 : 0;
        }
      

        public async Task<int> DeleteALendingAndReturnBook(LendingAndReturnsBooks lendAndRetBook)
        {
            int numOfRowsChanged = 0;
            try
            {
                using (var cli = new HttpClient())
                {
                    string url = uri +

                   "Delete/DeleteALendingAndReturnBook/";

                    url += lendAndRetBook.Id.ToString();


                    string strJson = JsonSerializer.Serialize<LendingAndReturnsBooks>(lendAndRetBook);


                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(strJson,

                    Encoding.UTF8, "application/json");

                    var apiResponse = await cli.SendAsync(request);
                    if (apiResponse.StatusCode ==

                    System.Net.HttpStatusCode.OK)
                    {
                        numOfRowsChanged = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return numOfRowsChanged;
        }




        // -----------
        // Users :
        public async Task<UsersList> SelectAllUsers()
        {
            UsersList users = null;
            try
            {
                string r = uri + "Select/UsersSelector";
                users = await client.GetFromJsonAsync<UsersList>(r);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return users;
        }

       

        public async Task<Users> SelectUserByUserName(string userName)
        {
            Users user = null;
            try
            {
                string URI = uri + "Select/SelectUserByUserName/";
                URI += userName;
                    
                user = await client.GetFromJsonAsync<Users>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return user;
        }

        

        public async Task<int> InsertAUser(Users user)
        {
            var x = await client.PostAsJsonAsync<Users>(uri + "Insert/InsertAUser", user);
            return x.IsSuccessStatusCode ? 1 : 0;
        }


        public async Task<int> UpdateAUser(Users user)
        {
            var x = await client.PutAsJsonAsync<Users>(uri + "Update/UpdateAUser", user);
            return x.IsSuccessStatusCode ? 1 : 0;
        }


        public async Task<int> DeleteAUser(Users user)
        {
            int numOfRowsChanged = 0;
            try
            {
                using (var cli = new HttpClient())
                {
                    string url = uri +

                   "Delete/DeleteAUser/";

                    url += user.Id.ToString();


                    string strJson = JsonSerializer.Serialize<Users>(user);

                    HttpRequestMessage request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(strJson,

                    Encoding.UTF8, "application/json");

                    HttpResponseMessage apiResponse = await cli.SendAsync(request);
                    if (apiResponse.StatusCode ==

                    System.Net.HttpStatusCode.OK)
                    {
                        numOfRowsChanged = 2;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return numOfRowsChanged;
        }




        //-----------------
        // Writers :

        public async Task<WritersList> SelectAllWriters()
        {
            WritersList writers = null;
            try
            {
                writers = await client.GetFromJsonAsync<WritersList>(uri + "Select/WritersSelector");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return writers;
        }

        public async Task<int> InsertAWriter(Writers writer)
        {
            var x = await client.PostAsJsonAsync<Writers>(uri + "Insert/InsertAWriter", writer);
            return x.IsSuccessStatusCode ? 1 : 0;
        }


        public async Task<int> UpdateAWriter(Writers writer)
        {
            var x = await client.PutAsJsonAsync<Writers>(uri + "Update/UpdateAWriter", writer);
            return x.IsSuccessStatusCode ? 1 : 0;
        }


        public async Task<int> DeleteAWriter(Writers writer)
        {
            int numOfRowsChanged = 0;
            try
            {
                using (var cli = new HttpClient())
                {
                    string url = uri + "Delete/DeleteAWriter/";

                    url += writer.Id.ToString();

                    string strJson = JsonSerializer.Serialize<Writers>(writer);

                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(strJson,

                    Encoding.UTF8, "application/json");

                    var apiResponse = await cli.SendAsync(request);
                    if (apiResponse.StatusCode ==

                    System.Net.HttpStatusCode.OK)
                    {
                        numOfRowsChanged = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return numOfRowsChanged;
        }





        //---------------------------
        // select By Id : 

        public async Task<City> SelectCityById(int id)
        {
            City city = null;
            try
            {
                string URI = uri + "Select/SelectCityById/";
                URI += id.ToString();
                city = await client.GetFromJsonAsync<City>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return city;
        }

        
        public async Task<Genre> SelectGenreById(int id)
        {
            Genre genre = null;
            try
            {
                string URI = uri + "Select/SelectGenreById/";
                URI += id.ToString();
                genre = await client.GetFromJsonAsync<Genre>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return genre;
        }


        public async Task<Books> SelectBookById(int id)
        {
            Books book = null;
            try
            {
                string URI = uri + "Select/SelectBookById/";
                URI += id.ToString();
                book = await client.GetFromJsonAsync<Books>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return book;
        }

        public async Task<DigitalBooks> SelectDigitalBookById(int id)
        {
            DigitalBooks digiBook = null;
            try
            {
                string URI = uri + "Select/SelectDigitalBookById/";
                URI += id.ToString();
                digiBook = await client.GetFromJsonAsync<DigitalBooks>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return digiBook;
        }


        public async Task<LendingAndReturnsBooks> SelectLendingAndReturnsBookById(int id)
        {
            LendingAndReturnsBooks lendAndRetBook = null;
            try
            {
                string URI = uri + "SelectLendingAndReturnsBookById/";
                URI += id.ToString();
                lendAndRetBook = await client.GetFromJsonAsync<LendingAndReturnsBooks>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return lendAndRetBook;
        }



        public async Task<Users> SelectUserById(int id)
        {
            Users user = null;
            try
            {
                string URI = uri + "SelectUserById/";
                URI += id.ToString();

                user = await client.GetFromJsonAsync<Users>(URI);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return user;
        }


        public async Task<Writers> SelectWriterById(int id)
        {
            Writers writer = null;
            try
            {
                string URI = uri + "Select/SelectWriterById/";
                URI += id.ToString();
                writer = await client.GetFromJsonAsync<Writers>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return writer;
        }




        public async Task<string> GetBookPicByte64(int id)
        {
            string st = null;

            string URI = uri + "Select/BookPictureSelector64byte/";
            URI += id.ToString();

            HttpResponseMessage response = await client.GetAsync(URI);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                json = '"' + json + '"';
                try
                {
                    st = JsonSerializer.Deserialize<string>(json);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return st;
        }



        


        public async Task<BooksList> SelectAllBooksWithFilter(string sqlSentence)
        {
            BooksList booksList = null;
            try
            {
                string URI = uri + "Select/SelectorBooksWithFilter/";
                URI += sqlSentence;

                booksList = await client.GetFromJsonAsync<BooksList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return booksList;
        }




        public async Task<MangerLibraryList> SelectAllMangers()
        {
            MangerLibraryList mangers = null;
            try
            {
                mangers = await client.GetFromJsonAsync<MangerLibraryList>(uri + "Select/MangersSelector");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return mangers;
        }

        public async Task<int> InsertAManger(MangerLibrary manger)
        {
            var x = await client.PostAsJsonAsync<MangerLibrary>(uri + "Insert/InsertAManger", manger);
            return x.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateAManger(MangerLibrary manger)
        {
            var x = await client.PutAsJsonAsync<MangerLibrary>(uri + "Update/UpdateAManger", manger);
            return x.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteAManger(MangerLibrary manger)
        {
            int numOfRowsChanged = 0;
            try
            {
                using (var cli = new HttpClient())
                {
                    string url = uri + "Delete/DeleteAManger/";


                    url += manger.Id.ToString();


                    string strJson = JsonSerializer.Serialize<MangerLibrary>(manger);


                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(strJson,

                    Encoding.UTF8, "application/json");

                    var apiResponse = await cli.SendAsync(request);
                    if (apiResponse.StatusCode ==

                    System.Net.HttpStatusCode.OK)
                    {
                        numOfRowsChanged = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return numOfRowsChanged;
        }

        public async Task<MangerLibrary> SelectMangerById(int id)
        {
            MangerLibrary manger = null;
            try
            {
                string URI = uri + "Select/SelectMangerById/";
                URI += id.ToString();
                manger = await client.GetFromJsonAsync<MangerLibrary>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return manger;
        }




        public static void SaveImages(byte[] imageArray, string pathTofileName)
        {
            string fileName = System.IO.Path.GetFileName(pathTofileName);

            string str = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location 
                + "/../../../../../ViewModel/BooksPictures/" + fileName);

            string newPath = str.Replace("ViewModel", @"RonLibraryProject-master (1)\RonLibraryProject-master\ViewModel");

            using (MemoryStream ms = new MemoryStream(imageArray))
            {
                ms.Position = 0;
                using (Image image = Image.FromStream(ms))
                {
                    image.Save(newPath);
                }
            }

        }


        //Saving The AudioFile
        public static void SaveAudioFiles(string pathTofileName)
        {
            string fileAudioName = System.IO.Path.GetFileName(pathTofileName);

            string filePath = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../../../../ViewModel/AudioBooksFiles/" + fileAudioName);
            string newPath = filePath.Replace("ViewModel", @"RonLibraryProject-master (1)\RonLibraryProject-master\ViewModel");

            File.Copy(pathTofileName, newPath, true);

            //save into app project also:

            string appAudioFilesPath = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../../../../MyLibraryApp/Resources/Raw/" + fileAudioName);
            File.Copy(pathTofileName, appAudioFilesPath, true);
        }


        //public static string GetSomePath()
        //{
        //    string filePath = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../../../ViewModel/AudioBooksFiles/");
        //    return filePath;
        //}


        public static void DeleteImage(string fileName)
        {
            string path = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../../../../ViewModel/BooksPictures/" + fileName);
            string newPath = path.Replace("ViewModel", @"RonLibraryProject-master (1)\RonLibraryProject-master\ViewModel");

            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }
        }


        public static void DeleteAudioFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string fileName = System.IO.Path.GetFileName(filePath);

                File.Delete(filePath);

                string pathAppToDelete = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../../../../MyLibraryApp/Resources/Raw/" + fileName);

                if (File.Exists(pathAppToDelete))
                {
                    File.Delete(pathAppToDelete);
                }

            }
        }

    }
}
