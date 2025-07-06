//using Model;
//using ViewModel;
//using ApiLibraryService;

public class Program
{
    static async Task Main()
    { 

    }
}

//CityDB cityDB = new CityDB();
//CityList list=cityDB.SelectAll();
//foreach (City city in list)
//{
//    Console.WriteLine( city.CityName );
//}

//Console.WriteLine( "-----------");
//GenreDB genreDB = new GenreDB();
//GenreList genres = genreDB.SelectAll();
//foreach (Genre genre in genres)
//{
//    Console.WriteLine(genre.Id + " " + genre.GenreName );
//}
//Console.WriteLine("-----------");

//PersonDB personDB = new PersonDB();
//PersonList personList = personDB.SelectAll();
//foreach (Person person in personList)
//{
//    Console.WriteLine( person.FirstName + " " + person.LastName + " " + person.DateOfBirth.ToString());
//}

//Console.WriteLine("-----------");

////not working
//LendingAndReturnsBooksDB leDB = new LendingAndReturnsBooksDB();
//LendingAndReturnsBooksList leList = leDB.SelectAll();
//foreach (LendingAndReturnsBooks lendAndRet in leList)
//{
//    Console.WriteLine(lendAndRet.BookCode.BookName + " " + lendAndRet.UserCode.FirstName);
//}
//Console.WriteLine("----");
//Books y = BooksDB.SelectById(1);
//Console.WriteLine(y.BookName);
//Writers y1 = WritersDB.SelectById(1);
//Console.WriteLine(y1.FirstName);
//Genre y2 = GenreDB.SelectById(1);
//Console.WriteLine(y2.GenreName);


//Genre g = new Genre() { GenreName = "בישול ואפייה" };
//GenreDB db = new GenreDB();
//db.Insert(g);
//BooksDB db2 = new BooksDB();
//y.BookName = "מעשה בחמישה בלונים";
//db2.Update(y);
// int n = db2.SaveChanges();
//Console.WriteLine(n);


//

//UsersDB uDB = new UsersDB();
//Users user1 = UsersDB.SelectById(4);
//user1.LastName = "דוד";
//uDB.Update(user1);
//Console.WriteLine("Affected: " + uDB.SaveChanges());
////working

//WritersDB wrDB = new WritersDB();
//Writers wNew = new Writers() { FirstName = "דני", LastName = "מזרחי", GenreWriting =  GenreDB.SelectById(3) };
//wrDB.Insert(wNew);
//int num = wrDB.SaveChanges();
//Console.WriteLine(num);
////working

//DigitalBooks digiBook1 = DigitalBooksDB.SelectById(4);
//DigitalBooksDB digitalDB = new DigitalBooksDB();
//////digitalDB.Insert(digiBook);

//digitalDB.Delete(DigitalBooksDB.SelectById(4));
//int num2 = digitalDB.SaveChanges();
//Console.WriteLine(num2);
//working


//DigitalBooksList dList = new DigitalBooksDB().SelectAll();
//foreach (var booki in dList)
//{
//    Console.WriteLine(booki.BookName + "  " + booki.GenreCode.GenreName + "  " + booki.Duration);
//}
//working


//WritersDB wrDB = new WritersDB();
//wrDB.Delete(WritersDB.SelectById(5));
//int x = wrDB.SaveChanges();
//Console.WriteLine(x);
//working

//LendingAndReturnsBooks l = new LendingAndReturnsBooks() { BookCode = BooksDB.SelectById(3), UserCode = UsersDB.SelectById(3) };
//LendingAndReturnsBooksDB dB = new LendingAndReturnsBooksDB();
////dB.Insert(l);

//LendingAndReturnsBooks l2 = LendingAndReturnsBooksDB.SelectById(3);
//l2.DateOfReturn = new DateTime(2023 , 9 , 20);
//dB.Update(l2);

//int t = dB.SaveChanges();
//Console.WriteLine(t);
//working well

//ApiService apiService = new ApiService();
//CityList d = await apiService.SelectAllCities();
//foreach(City city in d)
//{
//    await Console.Out.WriteLineAsync(city.CityName);
//}