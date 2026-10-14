namespace PR211.Models
{
    public class Fixation : VehiclePass
    {
        public override string Describe()
            => $"Фиксация: {Data:yyyy.MM.dd}, номер {CarNumber}";
    }
}