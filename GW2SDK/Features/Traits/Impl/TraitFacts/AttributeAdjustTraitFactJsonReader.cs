﻿using System;
using System.Text.Json;
using GW2SDK.Impl.JsonReaders;
using GW2SDK.Impl.JsonReaders.Mappings;

namespace GW2SDK.Traits.Impl.TraitFacts
{
    internal sealed class AttributeAdjustTraitFactJsonReader : TraitFactJsonReader<AttributeAdjustTraitFact>
    {
        private AttributeAdjustTraitFactJsonReader()
        {
        }

        public new static IJsonReader<AttributeAdjustTraitFact> Instance { get; } = new AttributeAdjustTraitFactJsonReader();

        protected override void ConfigureDerived(JsonObjectMapping<AttributeAdjustTraitFact> traitFact)
        {
            traitFact.Map("value", to => to.Value);
            traitFact.Map("target", to => to.Target, (in JsonElement element, in JsonPath path) => Enum.Parse<TraitTarget>(element.GetString(), false));
        }
    }
}
