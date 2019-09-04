﻿using System.Linq;
using GW2SDK.Skins.Impl;
using GW2SDK.Tests.Features.Skins.Fixtures;
using Xunit;

namespace GW2SDK.Tests.Features.Skins
{
    [Collection(nameof(SkinDbCollection))]
    public class ArmorSkinDiscriminatorOptionsTest
    {
        public ArmorSkinDiscriminatorOptionsTest(SkinFixture fixture)
        {
            _fixture = fixture;
        }

        private readonly SkinFixture _fixture;

        [Fact]
        [Trait("Feature",  "Skins")]
        [Trait("Category", "Integration")]
        public void GetDiscriminatedTypes_ShouldReturnEveryTypeName()
        {
            var sut = new ArmorSkinDiscriminatorOptions();

            var expected = _fixture.Db.GetArmorTypeNames().ToHashSet();

            var actual = sut.GetDiscriminatedTypes().Select(x => x.TypeName).ToHashSet();

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Feature",  "Skins")]
        [Trait("Category", "Integration")]
        public void Create_ShouldReturnExpectedObject()
        {
            var sut = new ArmorSkinDiscriminatorOptions();

            var actual = sut.GetDiscriminatedTypes().Select(x => x.Type).ToList();

            Assert.All(actual, type => Assert.IsType(type, sut.Create(type)));
        }

        [Fact]
        [Trait("Feature",  "Skins")]
        [Trait("Category", "Integration")]
        public void Create_ShouldReturnObjectAssignableFromBaseType()
        {
            var sut = new ArmorSkinDiscriminatorOptions();

            var actual = sut.GetDiscriminatedTypes().Select(x => x.Type).ToList();

            Assert.All(actual, type => Assert.IsAssignableFrom(sut.BaseType, sut.Create(type)));
        }
    }
}