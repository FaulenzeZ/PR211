using System.Data;
using System.Diagnostics;
using System.Globalization;

class Received_good
{
    //private string? _name;        // Допускает возможность свойтво быть null
    //public required string Name { get; set; }     // Модифмкатор required обязывать заполнить свойтво при создании экземпляра

    private string _name = string.Empty;
    public string Name
    {
        get {  return _name; }
        set { if (!string.IsNullOrEmpty(value)) _name = value;}
    }
    public int Quantity {get; set;}  
    public DateTime DeliveryTime { get; set; }

}

class main
{
    static void Main()
    {
        Received_good one = new Received_good();
        Console.Write("Введите название товара: ");
        string good_name = Console.ReadLine() ?? "";
        one.Name = good_name;
        Console.Write("Введите количество товара: ");
        int q = Convert.ToInt32(Console.ReadLine());
        one.Quantity = q;
        Console.Write("Введите дату прихода товара: ");
        string data_time = Console.ReadLine();
        one.DeliveryTime = DateTime.ParseExact(data_time, "yyyy.MM.dd", CultureInfo.InvariantCulture);

        Console.WriteLine($" Название: {one.Name}, Кол-во: {one.Quantity}, Дата прихода: {one.DeliveryTime}");
    }
}
