﻿using GW2SDK.Annotations;

namespace GW2SDK.Traits
{
    [PublicAPI]
    [DataTransferObject(RootObject = false)]
    public sealed class BuffConversionTraitFact : TraitFact
    {
        public int Percent { get; set; }

        public TraitTarget Source { get; set; }

        public TraitTarget Target { get; set; }
    }
}
