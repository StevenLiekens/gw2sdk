﻿using GW2SDK.Features.Accounts;
using GW2SDK.Infrastructure;
using GW2SDK.Tests.Features.Accounts.Fixtures;
using GW2SDK.Tests.Shared;
using JsonDiffPatchDotNet;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace GW2SDK.Tests.Features.Accounts
{
    public class AccountTest : IClassFixture<AccountBasicFixture>, IClassFixture<AccountFullFixture>
    {
        public AccountTest(AccountBasicFixture basicFixture, AccountFullFixture fullFixture, ITestOutputHelper output)
        {
            _basicFixture = basicFixture;
            _fullFixture = fullFixture;
            _output = output;
        }

        private readonly AccountBasicFixture _basicFixture;

        private readonly AccountFullFixture _fullFixture;

        private readonly ITestOutputHelper _output;

        private Account CreateBasicSut(JsonSerializerSettings jsonSerializerSettings)
        {
            var sut = new Account();
            JsonConvert.PopulateObject(_basicFixture.AccountJsonObjectLatestSchemaBasic, sut, jsonSerializerSettings);
            return sut;
        }

        private Account CreateFullSut(JsonSerializerSettings jsonSerializerSettings)
        {
            var sut = new Account();
            JsonConvert.PopulateObject(_fullFixture.AccountJsonObjectLatestSchemaFull, sut, jsonSerializerSettings);
            return sut;
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        [Trait("Importance", "Critical")]
        public void Basic_Account_ShouldHaveNoMissingMembers()
        {
            _ = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseMissingMemberHandling(MissingMemberHandling.Error)
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        [Trait("Importance", "Critical")]
        public void Full_Account_ShouldHaveNoMissingMembers()
        {
            _ = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseMissingMemberHandling(MissingMemberHandling.Error)
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        [Trait("Importance", "Critical")]
        public void Basic_Account_SchemaDiff_ShouldBeEmpty()
        {
            var jdp = new JsonDiffPatch();

            var diff = jdp.Diff(_basicFixture.AccountJsonObjectKnownSchemaBasic,
                _basicFixture.AccountJsonObjectLatestSchemaBasic);

            _output.WriteLine(diff ?? "Basic schema is unchanged.");

            Assert.Null(diff);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        [Trait("Importance", "Critical")]
        public void Full_Account_SchemaDiff_ShouldBeEmpty()
        {
            var jdp = new JsonDiffPatch();

            var diff = jdp.Diff(_fullFixture.AccountJsonObjectKnownSchemaFull,
                _fullFixture.AccountJsonObjectLatestSchemaFull);

            _output.WriteLine(diff ?? "Full schema is unchanged.");

            Assert.Null(diff);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_Id_ShouldNotBeDefaultValue()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEqual(default, sut.Id);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_Id_ShouldNotBeDefaultValue()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEqual(default, sut.Id);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_Name_ShouldNotBeEmpty()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEmpty(sut.Name);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_Name_ShouldNotBeEmpty()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEmpty(sut.Name);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_Access_ShouldNotBeEmpty()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEmpty(sut.Access);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_Access_ShouldNotBeEmpty()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEmpty(sut.Access);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_Access_ShouldNotContainNone()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.DoesNotContain(ProductName.None, sut.Access);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_Access_ShouldNotContainNone()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.DoesNotContain(ProductName.None, sut.Access);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_Age_ShouldNotBeDefaultValue()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEqual(default, sut.Age);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_Age_ShouldNotBeDefaultValue()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEqual(default, sut.Age);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_LastModified_ShouldNotBeDefaultValue()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEqual(default, sut.LastModified);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_LastModified_ShouldNotBeDefaultValue()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEqual(default, sut.LastModified);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_World_ShouldBeValidId()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.Contains(sut.World, _fullFixture.WorldIds);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_World_ShouldBeValidId()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.Contains(sut.World, _fullFixture.WorldIds);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_Guilds_ShouldNotBeNull()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotNull(sut.Guilds);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_Guilds_ShouldNotBeNull()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotNull(sut.Guilds);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_GuildLeader_ShouldBeNull()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.Null(sut.GuildLeader);
        }


        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_GuildLeader_ShouldNotBeNull()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotNull(sut.GuildLeader);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_Created_ShouldNotBeDefaultValue()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEqual(default, sut.Created);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_Created_ShouldNotBeDefaultValue()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotEqual(default, sut.Created);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_FractalLevel_ShouldBeNull()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.Null(sut.FractalLevel);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_FractalLevel_ShouldNotBeNull()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotNull(sut.FractalLevel);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_DailyAp_ShouldBeNull()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.Null(sut.DailyAp);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_DailyAp_ShouldNotBeNull()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotNull(sut.DailyAp);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_MonthlyAp_ShouldBeNull()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.Null(sut.MonthlyAp);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_MonthlyAp_ShouldNotBeNull()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotNull(sut.MonthlyAp);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Basic_Account_WvwRank_ShouldBeNull()
        {
            var sut = CreateBasicSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.Null(sut.WvwRank);
        }

        [Fact]
        [Trait("Feature", "Accounts")]
        [Trait("Category", "Integration")]
        public void Full_Account_WvwRank_ShouldNotBeNull()
        {
            var sut = CreateFullSut(new JsonSerializerSettingsBuilder()
                .UseTraceWriter(new XunitTraceWriter(_output))
                .Build());

            Assert.NotNull(sut.WvwRank);
        }
    }
}
