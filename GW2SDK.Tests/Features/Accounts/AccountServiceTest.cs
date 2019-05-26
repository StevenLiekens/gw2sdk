﻿using System.Threading.Tasks;
using GW2SDK.Extensions;
using GW2SDK.Features.Accounts;
using GW2SDK.Infrastructure;
using GW2SDK.Tests.Shared;
using Xunit;
using Xunit.Abstractions;

namespace GW2SDK.Tests.Features.Accounts
{
    public class AccountServiceTest
    {
        public AccountServiceTest(ITestOutputHelper output)
        {
            _output = output;
        }

        private readonly ITestOutputHelper _output;

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public async Task GetAccount_ShouldReturnAccount()
        {
            var http = HttpClientFactory.CreateDefault();
            http.UseAccessToken(ConfigurationManager.Instance.ApiKeyFull);

            var sut = new AccountService(http);

            var settings = new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build();

            var actual = await sut.GetAccount(settings);

            Assert.IsType<Account>(actual);
        }
    }
}
