using System;
using System.Collections.Generic;
using PR211.Models;

namespace PR211.Output
{
    public class PassPrinter : IPassPrinter
    {
        public void Print(VehiclePass pass)
        {
            Console.WriteLine(pass.Describe());
        }

        public void PrintAll(List<VehiclePass> passes)
        {
            foreach (VehiclePass pass in passes)
                Print(pass);
        }
    }
}