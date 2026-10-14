using System.Data;
using System.Globalization;

class Fixation
{
    public DateTime Data {get; set;}
    public string CarNumber {get; set;} = string.Empty;
}
class Programm 
{
    static void Main()
    {
        Fixation avto_fix = new Fixation();

        Console.WriteLine("Введите описание объекта (например: Фиксация проезда автомобилей: 2026.10.26 \"АН508А124\")");
        string line = Console.ReadLine() ?? "";

        int colon = line.IndexOf(':');
        if (colon >= 0)
            line = line.Substring(colon + 1);

        string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string data = parts[0];
        string car = parts[1].Trim('"');

        avto_fix.Data = DateTime.ParseExact(data, "yyyy.MM.dd", CultureInfo.InvariantCulture);
        avto_fix.CarNumber = car;
        Console.WriteLine($"Время: {avto_fix.Data}, Номер: {avto_fix.CarNumber}");
    }
    
}