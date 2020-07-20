﻿using GW2SDK.Builds;
using GW2SDK.Builds.Impl;
using GW2SDK.Tests.Features.Builds.Fixtures;
using Xunit;

namespace GW2SDK.Tests.Features.Builds
{
    public class BuildJsonReaderTest : IClassFixture<BuildFixture>
    {
        public BuildJsonReaderTest(BuildFixture fixture)
        {
            _fixture = fixture;
        }

        private readonly BuildFixture _fixture;

        private static class BuildFact
        {
            public static void Id_is_positive(Build actual) => Assert.InRange(actual.Id, 1, int.MaxValue);
        }

        [Fact]
        [Trait("Feature",    "Builds")]
        [Trait("Category",   "Integration")]
        [Trait("Importance", "Critical")]
        public void Build_can_be_created_from_json()
        {
            var sut = BuildJsonReader.Instance;

            var actual = sut.Read(_fixture.Build);

            BuildFact.Id_is_positive(actual);
        }
    }
}