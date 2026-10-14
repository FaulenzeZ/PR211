using System;
using PR211.Models;
using PR211.Parsing;
using Xunit;

namespace PR211.Tests
{
    public class PassParserTests
    {
        private readonly PassParser _parser = new PassParser();

        [Fact]
        public void ParseFixation_ValidLine_ReturnsFixation()
        {
            var result = _parser.ParseLine(
                "Фиксация проезда автомобилей: 2026.10.26 \"АН508А124\"");
            var fix = Assert.IsType<Fixation>(result);
            Assert.Equal("АН508А124", fix.CarNumber);
            Assert.Equal(new DateTime(2026, 10, 26), fix.Data);
        }

        [Fact]
        public void ParseTruck_ValidLine_ReturnsTruckPass()
        {
            var result = _parser.ParseLine(
                "Грузовой автомобиль: 2026.10.26 \"В123ВВ99\" 15.5 \"Песок\"");
            var truck = Assert.IsType<TruckPass>(result);
            Assert.Equal(15.5, truck.CargoWeight);
            Assert.Equal("Песок", truck.CargoType);
        }

        [Fact]
        public void ParseCar_ValidLine_ReturnsCarPass()
        {
            var result = _parser.ParseLine(
                "Легковой автомобиль: 2026.10.27 \"Е456ЕЕ77\" 4 \"Toyota\"");
            var car = Assert.IsType<CarPass>(result);
            Assert.Equal(4, car.Passengers);
            Assert.Equal("Toyota", car.Brand);
        }

        [Fact]
        public void ParseLine_UnknownType_Throws()
        {
            Assert.Throws<PassParseException>(() =>
                _parser.ParseLine("Самокат: 2026.10.26 \"А001АА01\""));
        }

        [Fact]
        public void ParseFixation_TooFewFields_Throws()
        {
            Assert.Throws<PassParseException>(() =>
                _parser.ParseLine("Фиксация проезда: 2026.10.26"));
        }

        [Fact]
        public void ParseFixation_BadDate_Throws()
        {
            Assert.Throws<PassParseException>(() =>
                _parser.ParseLine("Фиксация: 2026-13-99 \"А001АА01\""));
        }

        [Fact]
        public void ParseCar_BadPassengers_Throws()
        {
            Assert.Throws<PassParseException>(() =>
                _parser.ParseLine("Легковой: 2026.10.27 \"Е456ЕЕ77\" abc \"Toyota\""));
        }

        [Fact]
        public void ParseFixation_NoColon_Throws()
        {
            Assert.Throws<PassParseException>(() =>
                _parser.ParseLine("Фиксация 2026.10.26 \"АН508А124\""));
        }

        [Fact]
        public void ParseFixation_ExtraSpaces_Works()
        {
            var result = _parser.ParseLine(
                "Фиксация:    2026.10.26    \"АН508А124\"   ");
            Assert.IsType<Fixation>(result);
        }

        [Fact]
        public void ParseFixation_NoQuotes_Works()
        {
            var result = _parser.ParseLine(
                "Фиксация: 2026.10.26 АН508А124");
            var fix = Assert.IsType<Fixation>(result);
            Assert.Equal("АН508А124", fix.CarNumber);
        }
    }
}