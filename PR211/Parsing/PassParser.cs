using System;
using System.Globalization;
using PR211.Models;

namespace PR211.Parsing
{
    public class PassParser : IPassParser
    {
        public VehiclePass? ParseLine(string line)
        {
            if (line.StartsWith("Фиксация"))
                return ParseFixation(line);
            if (line.StartsWith("Грузовой"))
                return ParseTruck(line);
            if (line.StartsWith("Легковой"))
                return ParseCar(line);
            throw new PassParseException(
                $"Неизвестный тип объекта: \"{line}\"");
        }

        private Fixation ParseFixation(string line)
        {
            string[] parts = SplitFields(line);
            RequireFields(parts, 2, "Фиксация");
            return new Fixation
            {
                Data = ParseDate(parts[0]),
                CarNumber = ParseNumber(parts[1])
            };
        }

        private TruckPass ParseTruck(string line)
        {
            string[] parts = SplitFields(line);
            RequireFields(parts, 4, "Грузовой");
            return new TruckPass
            {
                Data = ParseDate(parts[0]),
                CarNumber = ParseNumber(parts[1]),
                CargoWeight = ParseDouble(parts[2]),
                CargoType = ParseString(parts[3])
            };
        }

        private CarPass ParseCar(string line)
        {
            string[] parts = SplitFields(line);
            RequireFields(parts, 4, "Легковой");
            return new CarPass
            {
                Data = ParseDate(parts[0]),
                CarNumber = ParseNumber(parts[1]),
                Passengers = ParseInt(parts[2]),
                Brand = ParseString(parts[3])
            };
        }

        private string[] SplitFields(string line)
        {
            int colon = line.IndexOf(':');
            if (colon < 0)
                throw new PassParseException(
                    $"Отсутствует двоеточие: \"{line}\"");

            string rest = line.Substring(colon + 1);
            return rest.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
        }

        private void RequireFields(string[] parts, int min, string type)
        {
            if (parts.Length < min)
                throw new PassParseException(
                    $"Тип \"{type}\" требует минимум {min} полей, " +
                    $"найдено {parts.Length}");
        }

        private DateTime ParseDate(string s)
        {
            if (!DateTime.TryParseExact(s, "yyyy.MM.dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime result))
            {
                throw new PassParseException(
                    $"Некорректная дата: \"{s}\"");
            }
            return result;
        }

        private int ParseInt(string s)
        {
            if (!int.TryParse(s, NumberStyles.Integer,
                CultureInfo.InvariantCulture, out int result))
            {
                throw new PassParseException(
                    $"Некорректное целое число: \"{s}\"");
            }
            return result;
        }

        private double ParseDouble(string s)
        {
            if (!double.TryParse(s, NumberStyles.Float,
                CultureInfo.InvariantCulture, out double result))
            {
                throw new PassParseException(
                    $"Некорректное дробное число: \"{s}\"");
            }
            return result;
        }

        private string ParseString(string s)
        {
            return s.Trim('"');
        }
        private string ParseNumber(string s)
        {
            return s.Trim('"');
        }
    }
}