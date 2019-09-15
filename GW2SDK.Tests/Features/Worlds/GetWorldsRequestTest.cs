﻿using System;
using System.Net.Http;
using GW2SDK.Worlds.Impl;
using Xunit;

namespace GW2SDK.Tests.Features.Worlds
{
    public class GetWorldsRequestTest
    {
        [Fact]
        [Trait("Feature",  "Worlds")]
        [Trait("Category", "Unit")]
        public void Method_is_GET()
        {
            var sut = new GetWorldsRequest();

            Assert.Equal(HttpMethod.Get, sut.Method);
        }

        [Fact]
        [Trait("Feature",  "Worlds")]
        [Trait("Category", "Unit")]
        public void RequestUri_is_v2_worlds_bulk()
        {
            var sut = new GetWorldsRequest();

            var expected = new Uri("/v2/worlds?ids=all", UriKind.Relative);

            Assert.Equal(expected, sut.RequestUri);
        }
    }
}
