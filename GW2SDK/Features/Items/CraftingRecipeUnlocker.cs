﻿using GW2SDK.Infrastructure;

namespace GW2SDK.Features.Items
{
    [PublicAPI]
    public sealed class CraftingRecipeUnlocker : Unlocker
    {
        public int RecipeId { get; set; }

        [CanBeNull]
        public int[] ExtraRecipeIds { get; set; }
    }
}