﻿using System;
using System.Net.Http;
using JetBrains.Annotations;
using GW2SDK.Http;
using static System.Net.Http.HttpMethod;

namespace GW2SDK.Traits.Http
{
    [PublicAPI]
    public sealed class TraitsByPageRequest
    {
        public TraitsByPageRequest(int pageIndex, int? pageSize = null)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; }

        public int? PageSize { get; }

        public static implicit operator HttpRequestMessage(TraitsByPageRequest r)
        {
            var search = new QueryBuilder();
            search.Add("page", r.PageIndex);
            if (r.PageSize.HasValue) search.Add("page_size", r.PageSize.Value);
            var location = new Uri($"/v2/traits?{search}", UriKind.Relative);
            return new HttpRequestMessage(Get, location);
        }
    }
}
