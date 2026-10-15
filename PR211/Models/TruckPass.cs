namespace PR211.Models
{
    public class TruckPass : VehiclePass
    {
        public double CargoWeight { get; set; }
        public string CargoType { get; set; } = string.Empty;

        public override string Describe()
            => $"Грузовик: {Data:yyyy.MM.dd}, номер {CarNumber}, " +
               $"груз {CargoWeight} т, тип {CargoType}";
    }
}