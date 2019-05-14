using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GW2SDK.Colors.Infrastructure;
using Xunit;

namespace GW2SDK.Tests
{
    public class ColorsFixture : IAsyncLifetime
    {
        public ISet<string> ColorCategories { get; private set; }

        public async Task InitializeAsync()
        {
            var http = new HttpClient
            {
                BaseAddress = new Uri("https://api.guildwars2.com")
            };

            // TODO: ideally we should use persistent storage for this
            // LiteDB looks like a good candidate for storage
            var service = new JsonColorService(http);
            ColorCategories = await service.GetAllColorCategories();
        }

        public Task DisposeAsync()
        {
            // Nothing to do here (yet!)
            return Task.CompletedTask;
        }
    }
}