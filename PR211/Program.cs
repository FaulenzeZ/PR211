using System.Data;
using System.Globalization;

abstract class VehiclePass
{
    public DateTime Data { get; set; }
    public string CarNumber { get; set; } = string.Empty;
    public abstract string Describe();
}
class Fixation : VehiclePass
{
    public override string Describe()
    {
        return $"Фиксация: {Data:yyyy.MM.dd}, номер: {CarNumber}";
    }
}

class TruckPass : VehiclePass
{
    public double CargoWeight { get; set; }
    public string CargoType { get; set; } = string.Empty;
    public override string Describe()
    {
        return $"Грузовик: {Data:yyyy.MM.dd}, номер {CarNumber}, " +
        $"груз {CargoWeight}т., тип {CargoType}";
    }
}

class CarPass : VehiclePass
{
    public int Passengers { get; set; }
    public string Brand { get; set; } = string.Empty;

    public override string Describe()
    {
        return $"Легковой: {Data:yyyy.MM.dd}, номер {CarNumber}, " +
        $"пассажиров {Passengers}, марка {Brand}";
    }
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