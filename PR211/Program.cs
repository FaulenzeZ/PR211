using System.Globalization;

class Received_good
{
    private string _name = string.Empty;
    //private string? _name;        // Допускает возможность свойтво быть null
    //public required string Name { get; set; }     // Модифмкатор required обязывать заполнить свойтво при создании экземпляра
    private int _quantity;

    public string Name
    {
        get {  return _name; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _name = value;
            }
        }
    }
    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }
  
    public DateTime DeliveryTime { get; set; }

}

class main
{
    static void Main()
    {
        Received_good one = new Received_good();
        one.Name = "Рамен";
        one.Quantity = 100;
        one.DeliveryTime = new DateTime(2026, 4, 01);
        one.DeliveryTime = DateTime.Now;

        Console.WriteLine(one.Name);
        Console.WriteLine(one.Quantity);
        Console.WriteLine(one.DeliveryTime);


    }

}