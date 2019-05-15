﻿using System.Net.Http;
using System.Threading.Tasks;
using GW2SDK.Features.Builds;
using GW2SDK.Features.Builds.Infrastructure;
using GW2SDK.Tests.Shared.Fixtures;
using Xunit;

namespace GW2SDK.Tests.Features.Builds
{
    public class BuildServiceTest : IClassFixture<ConfigurationFixture>
    {
        public BuildServiceTest(ConfigurationFixture fixture)
        {
            _fixture = fixture;
        }

        private readonly ConfigurationFixture _fixture;

        private BuildService CreateSut() =>
            new BuildService(new JsonBuildService(new HttpClient
            {
                BaseAddress = _fixture.BaseAddress
            }));

        [Fact]
        [Trait("Feature", "Builds")]
        [Trait("Category", "Integration")]
        public async Task GetBuild_ShouldNotReturnNull()
        {
            var sut = CreateSut();

            var actual = await sut.GetBuild();

            Assert.NotNull(actual);
        }
    }
}
