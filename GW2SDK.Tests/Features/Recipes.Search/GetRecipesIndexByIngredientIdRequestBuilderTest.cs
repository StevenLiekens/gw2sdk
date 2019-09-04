﻿using System;
using System.Net.Http;
using GW2SDK.Recipes.Search.Impl;
using Xunit;

namespace GW2SDK.Tests.Features.Recipes.Search
{
    public class GetRecipesIndexByIngredientIdRequestBuilderTest
    {
        [Fact]
        [Trait("Feature",  "Recipes.Search")]
        [Trait("Category", "Unit")]
        public void GetRequest_MethodShouldBeGet()
        {
            var id = 1;

            var sut = new GetRecipesIndexByIngredientIdRequest.Builder(id);

            var actual = sut.GetRequest();

            Assert.Equal(HttpMethod.Get, actual.Method);
        }

        [Fact]
        [Trait("Feature",  "Recipes.Search")]
        [Trait("Category", "Unit")]
        public void GetRequest_ShouldSerializeIdAsQueryString()
        {
            var id = 1;

            var sut = new GetRecipesIndexByIngredientIdRequest.Builder(id);

            var actual = sut.GetRequest();

            var expected = new Uri("/v2/recipes/search?input=1", UriKind.Relative);

            Assert.Equal(expected, actual.RequestUri);
        }
    }
}