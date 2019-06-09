﻿using System.Linq;
using GW2SDK.Infrastructure.Items;
using GW2SDK.Tests.Features.Items.Fixtures;
using Xunit;

namespace GW2SDK.Tests.Features.Items
{
    [Collection(nameof(ItemDbCollection))]
    public class WeaponDiscriminatorOptionsTest
    {
        public WeaponDiscriminatorOptionsTest(ItemFixture fixture)
        {
            _fixture = fixture;
        }

        private readonly ItemFixture _fixture;

        [Fact]
        [Trait("Feature",  "Items")]
        [Trait("Category", "Integration")]
        public void GetDiscriminatedTypes_ShouldReturnEveryTypeName()
        {
            var sut = new WeaponDiscriminatorOptions();

            var expected = _fixture.Db.GetWeaponTypeNames().ToHashSet();

            var actual = sut.GetDiscriminatedTypes().Select(x => x.TypeName).ToHashSet();

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Feature",  "Items")]
        [Trait("Category", "Integration")]
        public void Create_ShouldReturnExpectedObject()
        {
            var sut = new WeaponDiscriminatorOptions();

            var actual = sut.GetDiscriminatedTypes().Select(x => x.Type).ToList();

            Assert.All(actual, type => Assert.IsType(type, sut.Create(type)));
        }

        [Fact]
        [Trait("Feature",  "Items")]
        [Trait("Category", "Integration")]
        public void Create_ShouldReturnObjectAssignableFromBaseType()
        {
            var sut = new WeaponDiscriminatorOptions();

            var actual = sut.GetDiscriminatedTypes().Select(x => x.Type).ToList();

            Assert.All(actual, type => Assert.IsAssignableFrom(sut.BaseType, sut.Create(type)));
        }
    }
}