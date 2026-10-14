using System.Collections.Generic;
using PR211.Models;

namespace PR211.Output
{
    public interface IPassPrinter
    {
        void Print(VehiclePass pass);
        void PrintAll(List<VehiclePass> passes);
    }
}