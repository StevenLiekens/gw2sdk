﻿using GW2SDK.Annotations;

namespace GW2SDK
{
    [PublicAPI]
    public interface IListContext
    {
        int ResultTotal { get; }

        int ResultCount { get; }
    }
}