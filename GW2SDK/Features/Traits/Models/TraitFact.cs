﻿using GW2SDK.Annotations;
using JetBrains.Annotations;

namespace GW2SDK.Traits
{
    [PublicAPI]
    [Inheritable]
    [DataTransferObject(RootObject = false)]
    public record TraitFact
    {
        public string Text { get; init; } = "";

        public string Icon { get; init; } = "";
    }
}