﻿using JetBrains.Annotations;
using GW2SDK.Json;

namespace GW2SDK.Achievements
{
    [PublicAPI]
    public interface IAchievementReader : IJsonReader<Achievement>
    {
        IJsonReader<int> Id { get; }
    }
}
