namespace PR211.Models
{
    public class CarPass : VehiclePass
    {
        public int Passengers { get; set; }
        public string Brand { get; set; } = string.Empty;

        public override string Describe()
            => $"Легковой: {Data:yyyy.MM.dd}, номер {CarNumber}, " +
               $"пассажиров {Passengers}, марка {Brand}";
    }
}