﻿using System;
using System.Linq;
using GW2SDK.Features.Achievements;
using GW2SDK.Tests.Features.Achievements.Fixtures;
using Xunit;

namespace GW2SDK.Tests.Features.Achievements
{
    [Collection(nameof(AchievementDbCollection))]
    public class AchievementFlagTest
    {
        public AchievementFlagTest(AchievementFixture fixture)
        {
            _fixture = fixture;
        }

        private readonly AchievementFixture _fixture;

        [Fact]
        public void DefaultMember_ShouldBeUndefined()
        {
            var actual = Enum.IsDefined(typeof(AchievementFlag), default(AchievementFlag));

            Assert.False(actual);
        }

        [Fact]
        [Trait("Feature",  "Achievements")]
        [Trait("Category", "Integration")]
        public void AllMembers_ShouldHaveNoMissingMembers()
        {
            var expected = Enum.GetNames(typeof(AchievementFlag)).ToHashSet();

            var actual = _fixture.Db.GetAchievementFlags().ToHashSet();

            Assert.Equal(expected, actual);
        }
    }
}