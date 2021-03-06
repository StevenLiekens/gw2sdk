﻿using System;
using System.Net.Http;
using JetBrains.Annotations;
using GW2SDK.Http;
using static System.Net.Http.HttpMethod;

namespace GW2SDK.Worlds.Http
{
    [PublicAPI]
    public sealed class WorldByIdRequest
    {
        public WorldByIdRequest(int worldId)
        {
            WorldId = worldId;
        }

        public int WorldId { get; }

        public static implicit operator HttpRequestMessage(WorldByIdRequest r)
        {
            var search = new QueryBuilder();
            search.Add("id", r.WorldId);
            var location = new Uri($"/v2/worlds?{search}", UriKind.Relative);
            return new HttpRequestMessage(Get, location);
        }
    }
}
