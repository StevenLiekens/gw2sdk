﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using JetBrains.Annotations;
using GW2SDK.Http;
using static System.Net.Http.HttpMethod;

namespace GW2SDK.Colors.Http
{
    [PublicAPI]
    public sealed class ColorsByIdsRequest
    {
        public ColorsByIdsRequest(IReadOnlyCollection<int> colorIds)
        {
            if (colorIds is null)
            {
                throw new ArgumentNullException(nameof(colorIds));
            }

            if (colorIds.Count == 0)
            {
                throw new ArgumentException("Color IDs cannot be an empty collection.", nameof(colorIds));
            }

            ColorIds = colorIds;
        }

        public IReadOnlyCollection<int> ColorIds { get; }

        public static implicit operator HttpRequestMessage(ColorsByIdsRequest r)
        {
            var search = new QueryBuilder();
            search.Add("ids", r.ColorIds);
            var location = new Uri($"/v2/colors?{search}", UriKind.Relative);
            return new HttpRequestMessage(Get, location);
        }
    }
}
