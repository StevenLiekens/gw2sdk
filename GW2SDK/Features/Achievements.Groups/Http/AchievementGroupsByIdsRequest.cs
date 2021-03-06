﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using JetBrains.Annotations;
using GW2SDK.Http;
using static System.Net.Http.HttpMethod;

namespace GW2SDK.Achievements.Groups.Http
{
    [PublicAPI]
    public sealed class AchievementGroupsByIdsRequest
    {
        public AchievementGroupsByIdsRequest(IReadOnlyCollection<string> achievementGroupIds)
        {
            if (achievementGroupIds is null)
            {
                throw new ArgumentNullException(nameof(achievementGroupIds));
            }

            if (achievementGroupIds.Count == 0)
            {
                throw new ArgumentException("Achievement group IDs cannot be an empty collection.", nameof(achievementGroupIds));
            }

            if (achievementGroupIds.Any(string.IsNullOrEmpty))
            {
                throw new ArgumentException("Achievement group IDs collection cannot contain empty values.", nameof(achievementGroupIds));
            }

            AchievementGroupIds = achievementGroupIds;
        }

        public IReadOnlyCollection<string> AchievementGroupIds { get; }

        public static implicit operator HttpRequestMessage(AchievementGroupsByIdsRequest r)
        {
            var search = new QueryBuilder();
            search.Add("ids", r.AchievementGroupIds);
            var location = new Uri($"/v2/achievements/groups?{search}", UriKind.Relative);
            return new HttpRequestMessage(Get, location);
        }
    }
}
