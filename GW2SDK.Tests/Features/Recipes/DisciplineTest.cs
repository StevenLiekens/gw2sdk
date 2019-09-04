﻿using System;
using System.Linq;
using GW2SDK.Enums;
using GW2SDK.Tests.Features.Recipes.Fixtures;
using Xunit;

namespace GW2SDK.Tests.Features.Recipes
{
    [Collection(nameof(RecipeDbCollection))]
    public class DisciplineTest
    {
        public DisciplineTest(RecipeFixture fixture)
        {
            _fixture = fixture;
        }

        private readonly RecipeFixture _fixture;

        [Fact]
        [Trait("Feature",  "Recipes")]
        [Trait("Category", "Unit")]
        public void DefaultMember_ShouldBeUndefined()
        {
            Assert.False(Enum.IsDefined(typeof(CraftingDiscipline), default(CraftingDiscipline)));
        }

        [Fact]
        [Trait("Feature",    "Recipes")]
        [Trait("Category",   "Integration")]
        [Trait("Importance", "Critical")]
        public void Enum_ShouldHaveNoMissingMembers()
        {
            var expected = _fixture.Db.GetRecipeDisciplines().ToHashSet();

            var actual = Enum.GetNames(typeof(CraftingDiscipline)).ToHashSet();

            Assert.Equal(expected, actual);
        }
    }
}