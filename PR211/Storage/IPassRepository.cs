using System.Collections.Generic;
using PR211.Models;

namespace PR211.Storage
{
    public interface IPassRepository
    {
        List<VehiclePass> LoadFromFile(string path);
        List<VehiclePass> LoadFromLines(string[] lines);
    }
}