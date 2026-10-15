using System.Collections.Generic;
using System.IO;
using PR211.Models;
using PR211.Parsing;

namespace PR211.Storage
{
    public class PassRepository
    {
        private readonly PassParser _parser = new PassParser();

        public List<VehiclePass> LoadFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return ParseLines(lines);
        }

        public List<VehiclePass> LoadFromLines(string[] lines)
        {
            return ParseLines(lines);
        }

        private List<VehiclePass> ParseLines(string[] lines)
        {
            var result = new List<VehiclePass>();
            foreach (string line in lines)
            {
                VehiclePass? pass = _parser.ParseLine(line);
                if (pass != null)
                    result.Add(pass);
            }
            return result;
        }
    }
}