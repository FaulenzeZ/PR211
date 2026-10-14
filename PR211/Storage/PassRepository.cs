using System.Collections.Generic;
using System.IO;
using PR211.Models;
using PR211.Parsing;

namespace PR211.Storage
{
    public class PassRepository : IPassRepository
    {
        private readonly IPassParser _parser;
        private readonly List<string> _errors = new List<string>();

        public PassRepository(IPassParser parser)
        {
            _parser = parser;
        }

        public IReadOnlyList<string> Errors => _errors;

        public List<VehiclePass> LoadFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(
                    $"Файл не найден: \"{path}\"", path);

            string[] lines = File.ReadAllLines(path);
            return LoadFromLines(lines);
        }

        public List<VehiclePass> LoadFromLines(string[] lines)
        {
            _errors.Clear();
            var result = new List<VehiclePass>();

            foreach (string line in lines)
            {
                TryParseLine(line, result);
            }
            return result;
        }

        private void TryParseLine(string line, List<VehiclePass> result)
        {
            if (string.IsNullOrWhiteSpace(line))
                return;

            try
            {
                VehiclePass? pass = _parser.ParseLine(line);
                if (pass != null)
                    result.Add(pass);
            }
            catch (PassParseException ex)
            {
                _errors.Add($"{line} → {ex.Message}");
            }
        }
    }
}