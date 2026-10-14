using System;
using System.Collections.Generic;
using PR211.Models;
using PR211.Output;
using PR211.Parsing;
using PR211.Storage;

namespace PR211
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите имя файла (например, input.txt):");
            string fileName = Console.ReadLine() ?? "";

            try
            {
                var parser = new PassParser();
                var repository = new PassRepository(parser);
                List<VehiclePass> passes = repository.LoadFromFile(fileName);

                var printer = new PassPrinter();
                printer.PrintAll(passes);

                PrintErrors(repository.Errors);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void PrintErrors(IReadOnlyList<string> errors)
        {
            if (errors.Count == 0)
                return;

            Console.WriteLine();
            Console.WriteLine($"Ошибок при разборе: {errors.Count}");
            foreach (string e in errors)
                Console.WriteLine($"  • {e}");
        }
    }
}