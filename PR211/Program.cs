using System;
using System.Collections.Generic;
using System.IO;
using PR211.Models;
using PR211.Output;
using PR211.Storage;

namespace PR211
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите имя файла с данными (например, input.txt):");
            string fileName = Console.ReadLine() ?? "";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            var repository = new PassRepository();
            List<VehiclePass> passes = repository.LoadFromFile(fileName);

            var printer = new PassPrinter();
            printer.PrintAll(passes);
        }
    }
}