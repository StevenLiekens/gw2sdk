﻿using GW2SDK.Infrastructure;

namespace GW2SDK.Features.Achievements
{
    [DataTransferObject(RootObject = false)]
    public sealed class AchievementTier
    {
        public int Count { get; set; }

        public int Points { get; set; }
    }
}