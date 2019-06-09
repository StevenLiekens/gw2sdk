﻿using GW2SDK.Infrastructure;
using GW2SDK.Infrastructure.Items;
using Newtonsoft.Json;

namespace GW2SDK.Features.Items
{
    [Inheritable]
    [JsonConverter(typeof(DiscriminatedJsonConverter), typeof(TrinketDiscriminatorOptions))]
    public class Trinket : Equipment
    {
    }
}