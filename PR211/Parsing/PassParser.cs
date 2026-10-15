using System;
using System.Globalization;
using PR211.Models;

namespace PR211.Parsing
{
    public class PassParser
    {
        public VehiclePass? ParseLine(string line)
        {
            if (line.StartsWith("Фиксация"))
                return ParseFixation(line);
            if (line.StartsWith("Грузовой"))
                return ParseTruck(line);
            if (line.StartsWith("Легковой"))
                return ParseCar(line);
            return null;
        }

        private Fixation ParseFixation(string line)
        {
            string[] parts = SplitFields(line);
            return new Fixation
            {
                Data = ParseDate(parts[0]),
                CarNumber = ParseNumber(parts[1])
            };
        }

        private TruckPass ParseTruck(string line)
        {
            string[] parts = SplitFields(line);
            return new TruckPass
            {
                Data = ParseDate(parts[0]),
                CarNumber = ParseNumber(parts[1]),
                CargoWeight = double.Parse(parts[2], CultureInfo.InvariantCulture),
                CargoType = parts[3].Trim('"')
            };
        }

        private CarPass ParseCar(string line)
        {
            string[] parts = SplitFields(line);
            return new CarPass
            {
                Data = ParseDate(parts[0]),
                CarNumber = ParseNumber(parts[1]),
                Passengers = int.Parse(parts[2]),
                Brand = parts[3].Trim('"')
            };
        }

        private string[] SplitFields(string line)
        {
            int colon = line.IndexOf(':');
            string rest = colon >= 0 ? line.Substring(colon + 1) : line;
            return rest.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private DateTime ParseDate(string s)
            => DateTime.ParseExact(s, "yyyy.MM.dd", CultureInfo.InvariantCulture);

        private string ParseNumber(string s)
            => s.Trim('"');
    }
}