using System;

namespace PR211.Models
{
    public abstract class VehiclePass
    {
        public DateTime Data { get; set; }
        public string CarNumber { get; set; } = string.Empty;

        public abstract string Describe();
    }
}