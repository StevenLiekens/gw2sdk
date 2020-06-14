﻿using System.Threading.Tasks;
using GW2SDK.Accounts.Banks;
using GW2SDK.Exceptions;
using GW2SDK.Tests.TestInfrastructure;
using Xunit;

namespace GW2SDK.Tests.Features.Accounts.Banks
{
    public class BankServiceTest
    {
        [Fact]
        public async Task Get_the_bank()
        {
            await using var services = new Container();
            var sut = services.Resolve<BankService>();

            var actual = await sut.GetBank(ConfigurationManager.Instance.ApiKeyFull);

            Assert.IsType<Bank>(actual);
        }

        [Fact]
        public async Task The_bank_requires_a_valid_access_token()
        {
            await using var services = new Container();
            var sut = services.Resolve<BankService>();

            var actual = await Record.ExceptionAsync(async() =>
            {
                var _ = await sut.GetBank(accessToken: null);
            });

            var reason = Assert.IsType<UnauthorizedOperationException>(actual);

            Assert.Equal("Invalid access token", reason.Message);
        }

        [Fact]
        public async Task The_bank_requires_inventories_scope()
        {
            await using var services = new Container();
            var sut = services.Resolve<BankService>();

            var actual = await Record.ExceptionAsync(async() =>
            {
                var _ = await sut.GetBank(ConfigurationManager.Instance.ApiKeyBasic);
            });

            var reason = Assert.IsType<UnauthorizedOperationException>(actual);

            Assert.Equal("requires scope inventories", reason.Message);
        }
    }
}