using PR211.Models;

namespace PR211.Parsing
{
    public interface IPassParser
    {
        VehiclePass? ParseLine(string line);
    }
}