using System.Collections.Generic;
using PR211.Models;
using PR211.Storage;
using PR211.Parsing;
using Xunit;

namespace PR211.Tests
{
    public class PassRepositoryTests
    {
        private readonly PassRepository _repo =
            new PassRepository(new PassParser());

        [Fact]
        public void LoadFromLines_AllValid_ReturnsAll()
        {
            var lines = new[]
            {
                "Фиксация: 2026.10.26 \"АН508А124\"",
                "Грузовой: 2026.10.26 \"В123ВВ99\" 15.5 \"Песок\"",
                "Легковой: 2026.10.27 \"Е456ЕЕ77\" 4 \"Toyota\""
            };
            var result = _repo.LoadFromLines(lines);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void LoadFromLines_WithBadLine_CollectsError()
        {
            var lines = new[]
            {
                "Фиксация: 2026.10.26 \"АН508А124\"",
                "Битая строка",
                "Легковой: 2026.10.27 \"Е456ЕЕ77\" 4 \"Toyota\""
            };
            var result = _repo.LoadFromLines(lines);
            Assert.Equal(2, result.Count);
            Assert.Single(_repo.Errors);
        }

        [Fact]
        public void LoadFromLines_EmptyLines_Ignored()
        {
            var lines = new[] { "", "   ", "Фиксация: 2026.10.26 \"АН508А124\"" };
            var result = _repo.LoadFromLines(lines);
            Assert.Single(result);
        }

        [Fact]
        public void LoadFromFile_MissingFile_Throws()
        {
            Assert.Throws<System.IO.FileNotFoundException>(() =>
                _repo.LoadFromFile("нет_такого_файла.txt"));
        }
    }
}