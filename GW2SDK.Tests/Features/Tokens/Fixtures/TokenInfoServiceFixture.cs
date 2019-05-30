﻿using System.Threading.Tasks;
using GW2SDK.Features.Subtokens;
using GW2SDK.Tests.Shared;
using Xunit;

namespace GW2SDK.Tests.Features.Tokens.Fixtures
{
    public class TokenInfoServiceFixture : IAsyncLifetime
    {
        public CreatedSubtoken SubtokenBasic { get; private set; }

        public async Task InitializeAsync()
        {
            var http = HttpClientFactory.CreateDefault();

            var subtokenService = new SubtokenService(http);

            SubtokenBasic = await subtokenService.CreateSubtoken(ConfigurationManager.Instance.ApiKeyBasic);
        }

        public Task DisposeAsync() => Task.CompletedTask;
    }
}