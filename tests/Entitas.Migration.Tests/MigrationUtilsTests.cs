﻿using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Entitas.Migration.Tests
{
    public class MigrationUtilsTests
    {
        static string FixturePath => Path.Combine(TestExtensions.GetProjectRoot(), "tests", "Entitas.Migration.Tests", "fixtures", "exclude", "M0180");

        [Fact]
        public void GetsSourceFilesOnly()
        {
            var files = MigrationUtils.GetFiles(FixturePath);
            files.Length.Should().Be(6);
            files.Any(file => file.fileName == Path.Combine(FixturePath, "SourceFile.cs")).Should().BeTrue();
            files.Any(file => file.fileName == Path.Combine(FixturePath, Path.Combine("SubFolder", "SourceFile2.cs"))).Should().BeTrue();
            files.Any(file => file.fileName == Path.Combine(FixturePath, "RenderPositionSystem.cs")).Should().BeTrue();
            files.Any(file => file.fileName == Path.Combine(FixturePath, "RenderRotationSystem.cs")).Should().BeTrue();
            files.Any(file => file.fileName == Path.Combine(FixturePath, Path.Combine("SubFolder", "RenderSelectedSystem.cs"))).Should().BeTrue();
            files.Any(file => file.fileName == Path.Combine(FixturePath, Path.Combine("SubFolder", "MoveSystem.cs"))).Should().BeTrue();
        }
    }
}
