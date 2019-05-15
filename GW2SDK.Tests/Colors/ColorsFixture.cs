using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GW2SDK.Colors.Infrastructure;
using Xunit;

namespace GW2SDK.Tests.Colors
{
    public class ColorsFixture : IAsyncLifetime
    {
        public ISet<string> ColorCategories { get; private set; }

        public async Task InitializeAsync()
        {
            var configuration = new ConfigurationFixture();
            var http = new HttpClient
            {
                BaseAddress = configuration.BaseAddress
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