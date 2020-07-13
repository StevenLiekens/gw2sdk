﻿using GW2SDK.Annotations;

namespace GW2SDK.Traits
{
    [PublicAPI]
    [DataTransferObject(RootObject = false)]
    public sealed class RangeTraitFact : TraitFact
    {
        public int Value { get; set; }
    }
}
