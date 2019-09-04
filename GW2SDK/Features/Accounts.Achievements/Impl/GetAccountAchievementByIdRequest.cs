﻿using System;
using System.Net.Http;
using GW2SDK.Annotations;

namespace GW2SDK.Accounts.Achievements.Impl
{
    public sealed class GetAccountAchievementByIdRequest : HttpRequestMessage
    {
        private GetAccountAchievementByIdRequest([NotNull] Uri requestUri)
            : base(HttpMethod.Get, requestUri)
        {
        }

        public sealed class Builder
        {
            private readonly int _achievementId;

            public Builder(int achievementId)
            {
                _achievementId = achievementId;
            }

            public GetAccountAchievementByIdRequest GetRequest()
            {
                var resource = new Uri($"/v2/account/achievements?id={_achievementId}", UriKind.Relative);
                return new GetAccountAchievementByIdRequest(resource);
            }
        }
    }
}