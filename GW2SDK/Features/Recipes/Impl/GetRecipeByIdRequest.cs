﻿using System;
using System.Net.Http;
using GW2SDK.Annotations;

namespace GW2SDK.Recipes.Impl
{
    public sealed class GetRecipeByIdRequest : HttpRequestMessage
    {
        private GetRecipeByIdRequest([NotNull] Uri requestUri)
            : base(HttpMethod.Get, requestUri)
        {
        }

        public sealed class Builder
        {
            private readonly int _recipeId;

            public Builder(int recipeId)
            {
                _recipeId = recipeId;
            }

            public GetRecipeByIdRequest GetRequest()
            {
                var resource = new Uri($"/v2/recipes?id={_recipeId}", UriKind.Relative);
                return new GetRecipeByIdRequest(resource);
            }
        }
    }
}