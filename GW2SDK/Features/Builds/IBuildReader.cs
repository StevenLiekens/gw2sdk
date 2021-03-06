﻿using JetBrains.Annotations;
using GW2SDK.Json;

namespace GW2SDK.Builds
{
    [PublicAPI]
    public interface IBuildReader : IJsonReader<Build>
    {
    }
}
