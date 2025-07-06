using Model;
using ViewModel;

 CityDB dB= new CityDB();
CityList cityList= dB.SelectAll();
foreach (City c in cityList)
{
    Console.WriteLine( c.Id + " "  + c.CityName );

}
